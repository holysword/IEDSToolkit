using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IEDSToolkit.IED
{
    class ST570 : DeviceBase
    {
        public ST570(CRTDB _RTDB)
        {
            this.RTDB = _RTDB;
        }

        public override int Parse(byte[] _Data, int Count, CMessage message, byte[] SendData)
        {
            //报文解析
            if (Count > 256)
                return 1;   //报文太长

            //首先查看地址和功能码是否正确
            if (_Data[0] != (byte)this.Address || _Data[1] != message.Schema[1])
            {
                if (message.Schema[1] == 0x14 && _Data[1] == (byte)0x94 && _Data[2] == 0x05)
                {
                    //录波文件读取时需要等待并重试
                    return -1;
                }
                else
                    return 2;   //地址或者功能码错误
            }

            //然后查看CRC是否正确
            int crc = CRC16.calcCrc16(_Data, 0, Count - 2);
            byte crclow = (byte)(crc & 0x00FF);
            byte crchight = (byte)((crc & 0xFF00) >> 8);
            if (_Data[Count - 2] != crclow || _Data[Count - 1] != crchight)
                return 3;   //CRC错误

            for (int i = 0; i < Count; i++)
            {
                message.Response[i] = CommonUtility.ByteToInt(_Data[i]);
            }

            if (message.Response[1] != 3 && message.Response[1] != 4)
                return 0;   //非03或者04功能码，不需要继续处理

            int StartOffSet = 3;
            for (int i = 0; i < message.Vars.Count; i++)
            {
                CVar var = message.Vars[i];

                int RawValue = 0;
                if (var.BitOffset < 0)
                {
                    if (var.Length == 16)
                    {
                        RawValue = message.Response[var.ByteOffset + StartOffSet] * 256 + message.Response[var.ByteOffset + 1 + StartOffSet];
                    }
                    else if (var.Length == 32)
                    {
                        if (this.DoubleWordMode == "LH")
                            RawValue = message.Response[var.ByteOffset + StartOffSet] * 256 + message.Response[var.ByteOffset + 1 + StartOffSet] + 65536 * (message.Response[var.ByteOffset + 2 + StartOffSet] * 256 + message.Response[var.ByteOffset + 3 + StartOffSet]);
                        else
                            RawValue = 65536 * (message.Response[var.ByteOffset + StartOffSet] * 256 + message.Response[var.ByteOffset + 1 + StartOffSet]) + message.Response[var.ByteOffset + 2 + StartOffSet] * 256 + message.Response[var.ByteOffset + 3 + StartOffSet];
                    }
                }
                else
                {
                    RawValue = message.Response[var.ByteOffset + StartOffSet] * 256 + message.Response[var.ByteOffset + 1 + StartOffSet];
                    RawValue = RawValue << (16 - var.Length - var.BitOffset);
                    RawValue = RawValue & 0x0000FFFF;
                    RawValue = RawValue >> (16 - var.Length);
                }

                double value = RawValue * var.Multiple;
                if (var.Memo == ("最高位为1扩大100倍，为0扩大10倍"))
                {
                    if (RawValue < 32768)
                        value = RawValue * 0.1;
                    else
                        value = (RawValue - 32768) * 0.01;
                }

                String VarName = var.Name;
                if (message.Type == 2)
                {
                    int MessageAddress = CommonUtility.ByteToInt(SendData[3]);
                    int OriginAddress = CommonUtility.ByteToInt(this.GetMessage(message.Index).Schema[3]);
                    int IndexV = (MessageAddress - OriginAddress) / 0x08;
                    if (message.Index == 35)
                        IndexV = (MessageAddress - OriginAddress) / 0x10;
                    VarName = VarName + IndexV;
                }

                if (var.Table)
                {
                    //查表
                    Object TableValue = var.SearchTableValue(RawValue);
                    if (TableValue != null)
                        RTDB.SetVarValue(this.Name, VarName, TableValue);
                    else
                        RTDB.SetVarValue(this.Name, VarName, "#Error#");

                    continue;
                }

                if (var.Desc.IndexOf("年月日") >= 0)
                {
                    byte[] Date = new byte[3];
                    Date[0] = (byte)(RawValue >> 16);
                    Date[1] = (byte)((RawValue << 16) >> 24);
                    Date[2] = (byte)((RawValue << 24) >> 24);

                    String DateStr = CommonUtility.Bcd2Str(Date);
                    String DateValue = "20" + DateStr.Substring(0, 2) + "-" + DateStr.Substring(2, 2) + "-" + DateStr.Substring(4, 2);
                    RTDB.SetVarValue(this.Name, VarName, DateValue);
                }
                else if (var.Desc.IndexOf("时分秒") >= 0)
                {
                    byte[] Date = new byte[3];
                    Date[0] = (byte)(RawValue >> 16);
                    Date[1] = (byte)((RawValue << 16) >> 24);
                    Date[2] = (byte)((RawValue << 24) >> 24);

                    String DateStr = CommonUtility.Bcd2Str(Date);
                    String DateValue = DateStr.Substring(0, 2) + ":" + DateStr.Substring(2, 2) + ":" + DateStr.Substring(4, 2);
                    RTDB.SetVarValue(this.Name, VarName, DateValue);
                }
                else if (var.Desc.IndexOf("版本") >= 0)
                {
                    byte[] Version = new byte[4];
                    Version[0] = (byte)(RawValue >> 24);
                    Version[1] = (byte)(RawValue >> 16);
                    Version[2] = (byte)((RawValue << 16) >> 24);
                    Version[3] = (byte)((RawValue << 24) >> 24);

                    String VersionStr = CommonUtility.Bcd2Str(Version);
                    String VersionValue = VersionStr.Substring(0, 2) + "." + VersionStr.Substring(2, 2) + "." + VersionStr.Substring(4, 2) + "." + VersionStr.Substring(6, 2);
                    RTDB.SetVarValue(this.Name, VarName, VersionValue);
                }
                else if (var.Memo == ("有符号整型"))
                {
                    short ShortRawValue = (short)(CommonUtility.ByteToShort(_Data[var.ByteOffset + StartOffSet]) * 256 + CommonUtility.ByteToShort(_Data[var.ByteOffset + 1 + StartOffSet]));
                    value = ShortRawValue * var.Multiple;
                    RTDB.SetVarValue(this.Name, VarName, value);
                }
                else if (var.Name == ("PScale"))
                {
                    if (RawValue == 0)
                        this.GetVar("P").Unit = "kW";
                    else
                        this.GetVar("P").Unit = "W";
                    RTDB.SetVarValue(this.Name, VarName, value);
                }
                else if (var.Name == ("QScale"))
                {
                    if (RawValue == 0)
                        this.GetVar("Q").Unit = "kVar";
                    else
                        this.GetVar("Q").Unit = "Var";
                    RTDB.SetVarValue(this.Name, VarName, value);
                }
                else if (var.DataType == 9)
                {
                    String BoolStr = RawValue == 0 ? "否" : "是";
                    RTDB.SetVarValue(this.Name, VarName, BoolStr);
                }
                else
                    RTDB.SetVarValue(this.Name, VarName, value);
            }

            return 0;       //成功
        }

        public override byte[] GetSchema(CMessage message)
        {

            byte[] Schema = new byte[message.Schema.Length + 2];
            System.Array.Copy(message.Schema, 0, Schema, 0, message.Schema.Length);
            Schema[0] = (byte)this.Address;

            int crc = CRC16.calcCrc16(Schema, 0, message.Schema.Length);
            Schema[message.Schema.Length] = (byte)(crc & 0x00FF);
            Schema[message.Schema.Length + 1] = (byte)((crc & 0xFF00) >> 8);

            return Schema;
        }

        public override CMessage GetRecordMessage(CMessage message, int Index)
        {

            //获取记录相关报文，根据记录索引号
            CMessage RecordMessage = message.Clone();
            RecordMessage.Schema[0] = (byte)this.Address;

            if (message.Index == 35)
                RecordMessage.Schema[3] = (byte)(CommonUtility.ByteToInt(RecordMessage.Schema[3]) + Index * 0x10);
            else
                RecordMessage.Schema[3] = (byte)(CommonUtility.ByteToInt(RecordMessage.Schema[3]) + Index * 0x08);

            //int crc = CRC16.calcCrc16(RecordMessage.Schema, 0, message.Schema.length);
            //RecordMessage.Schema[message.Schema.length] = (byte) (crc & 0x00FF);
            //RecordMessage.Schema[message.Schema.length + 1] = (byte) ((crc & 0xFF00) >> 8);

            return RecordMessage;
        }

        public override bool WriteVar(CVar Var, String Value, AutoResetEvent objectNotify)
        {

            //写变量
            int RawValue = 0;
            if (Var.Table)
            {
                //查表
                bool ValidValue = false;
                for (int TableIndex = 0; TableIndex < Var.Tables.Count; TableIndex++)
                {
                    CTable table = Var.Tables[TableIndex];
                    if (table.Value.ToString() == (Value.ToString()))
                    {
                        RawValue = table.Index;
                        ValidValue = true;
                        break;
                    }
                }

                if (!ValidValue)
                    return false;
            }
            else
            {
                //根据数据类型分别处理
                switch (Var.DataType)
                {
                    case 1:
                        RawValue = (int)(Convert.ToDouble(Value.ToString()) / Var.Multiple);
                        break;
                    case 5:
                        double DoubleValue = Convert.ToDouble(Value.ToString());

                        RawValue = (int)(DoubleValue / Var.Multiple);

                        if (Var.Memo == ("最高位为1扩大100倍，为0扩大10倍"))
                        {
                            if (DoubleValue < 10)
                                RawValue = (int)(DoubleValue * 100 + 32768);
                            else
                                RawValue = (int)(DoubleValue * 10);
                        }
                        break;
                    case 9:
                        RawValue = (Value.ToString() == ("否") || Value.ToString().ToLower() == ("false")) ? 0 : 1;
                        break;
                    //case 10 : break;
                    default: return false;
                }
            }

            CMessage message = (CMessage)Var.OwnerMessage;
            CMessage WriteMessage = message.Clone();

            WriteMessage.Schema[0] = (byte)this.Address;
            WriteMessage.Schema[1] = 0x06;

            int VarAddress = CommonUtility.ByteToInt(WriteMessage.Schema[2]) * 256 + CommonUtility.ByteToInt(WriteMessage.Schema[3]) + Var.ByteOffset / 2;
            WriteMessage.Schema[2] = (byte)((VarAddress & 0xFF00) >> 8);
            WriteMessage.Schema[3] = (byte)(VarAddress & 0x00FF);

            if (Var.BitOffset < 0)
            {
                if (Var.Length == 16)
                {
                    WriteMessage.Schema[4] = (byte)((RawValue & 0xFF00) >> 8);
                    WriteMessage.Schema[5] = (byte)(RawValue & 0x00FF);
                }
            }
            else
            {
                int TotalWord = message.Response[Var.ByteOffset + 3] * 256 + message.Response[Var.ByteOffset + 4];
                int W = 0xFFFF;
                W = W << (16 - Var.Length - Var.BitOffset);
                W = W & 0x0000FFFF;
                W = W >> (16 - Var.Length);
                W = W & 0x0000FFFF;
                W = W << Var.BitOffset;
                W = W & 0x0000FFFF;
                W = ~W;
                W = W & 0x0000FFFF;
                TotalWord = TotalWord & W;
                RawValue = RawValue << Var.BitOffset;
                RawValue = TotalWord | RawValue;
                RawValue = RawValue & 0x0000FFFF;

                WriteMessage.Schema[4] = (byte)((RawValue & 0xFF00) >> 8);
                WriteMessage.Schema[5] = (byte)(RawValue & 0x00FF);
            }

            if (objectNotify != null)
            {
                return this.ExchangeMessage(WriteMessage, objectNotify);
            }
            else
            {
                this.AddUpdateMessage(WriteMessage);
                return true;
            }
        }

        public override bool SyncDateTime()
        {
            String DateString = DateTime.Now.ToString("yyMMdd");
            String TimeString = DateTime.Now.ToString("HHmmss");
            byte[] DateBytes = CommonUtility.str2Bcd(DateString);
            byte[] TimeBytes = CommonUtility.str2Bcd(TimeString);

            CMessage message = this.GetMessage(57);
            CMessage WriteMessage = message.Clone();

            WriteMessage.Schema[0] = (byte)this.Address;
            WriteMessage.Schema[8] = DateBytes[0];
            WriteMessage.Schema[9] = DateBytes[1];
            WriteMessage.Schema[10] = DateBytes[2];
            WriteMessage.Schema[12] = TimeBytes[0];
            WriteMessage.Schema[13] = TimeBytes[1];
            WriteMessage.Schema[14] = TimeBytes[2];

            AutoResetEvent NotifyObj = new AutoResetEvent(false);

            return this.ExchangeMessage(WriteMessage, NotifyObj);
        }
    }
}

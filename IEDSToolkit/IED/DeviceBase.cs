using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IEDSToolkit.IED
{
    abstract class DeviceBase
    {
        public class CTable
        {
            public int Index;
            public Object Value;
        }

        public class CVar
        {
            public String Name;
            public String Desc;
            public int DataType;
            public int Length;
            public int ByteOffset;
            public int BitOffset;
            public String Unit;
            public Object Default;
            public double Multiple;
            public bool Table;
            public String Memo;
            public double MinValue;
            public double MaxValue;

            public Object OwnerMessage;

            public List<CTable> Tables;

            public Object SearchTableValue(int Index)
            {
                //查表
                for (int TableIndex = 0; TableIndex < this.Tables.Count; TableIndex++)
                {
                    CTable table = this.Tables[TableIndex];
                    if (table.Index == Index)
                    {
                        return table.Value;
                    }
                }

                return null;
            }

            public CVar Clone()
            {
                CVar varClone = new CVar();
                varClone.Name = this.Name;
                varClone.Desc = this.Desc;
                varClone.DataType = this.DataType;
                varClone.Length = this.Length;
                varClone.BitOffset = this.BitOffset;
                varClone.ByteOffset = this.ByteOffset;
                varClone.Unit = this.Unit;
                varClone.Default = this.Default;
                varClone.Multiple = this.Multiple;
                varClone.Table = this.Table;
                varClone.Memo = this.Memo;
                varClone.MinValue = this.MinValue;
                varClone.MaxValue = this.MaxValue;
                varClone.OwnerMessage = this.OwnerMessage;

                if (this.Tables != null)
                {
                    varClone.Tables = new List<CTable>();
                    varClone.Tables.AddRange(this.Tables);
                }

                return varClone;
            }
        }

        public enum EMessageType
        {
            RealTime,
            CommonParam,
            AdvancedParam,
            Maintenance,
            Events,
            Oscillogram
        }

        public class CMessage
        {
            public int Index = -1;
            public int Type = 0;
            public int Count = 0;
            public String Name = "";
            public String Desc = "";
            public String Memo = "";
            public byte[] Schema;

            public int[] Response = new int[256];        //响应报文
            public bool SendAndRecieveSuccess = false;   //是否收发成功
            public AutoResetEvent NotifyObj = null;      //用于异步等待

            public List<CVar> Vars = new List<CVar>();

            public CMessage Clone()
            {
                CMessage messageClone = new CMessage();
                messageClone.Index = this.Index;
                messageClone.Type = this.Type;
                messageClone.Count = this.Count;
                messageClone.Name = this.Name;
                messageClone.Desc = this.Desc;
                if (this.Schema != null)
                {
                    messageClone.Schema = new byte[this.Schema.Length];
                    System.Array.Copy(this.Schema, 0, messageClone.Schema, 0, this.Schema.Length);
                }
                if (this.Vars != null)
                {
                    messageClone.Vars = new List<CVar>();
                    messageClone.Vars.AddRange(this.Vars);
                }
                return messageClone;
            }

            public CVar GetVar(String VarName)
            {
                foreach (CVar var in this.Vars)
                {
                    if (var.Name == VarName)
                        return var;
                }

                return null;
            }
        }

        public String Name;
        public String DoubleWordMode = "LH";
        public int Address;

        public CRTDB RTDB;
        
        private XmlDocument ParamDocument = null;
        private String ParamFileName;
        //private Hashtable ParamValue = new Hashtable();
        public AutoResetEvent UpdateFileHandler = null;

        private bool IsConnected = false;  //是否已连接
        public List<CMessage> Messages = new List<CMessage>();

        private Mutex rwl = new Mutex();
        private Mutex readWriteLockExchangeMsg = new Mutex();
        private List<CMessage> UpdateMessages = new List<CMessage>();

        abstract public int Parse(byte[] Data, int Count, CMessage message, byte[] SendData);
        abstract public byte[] GetSchema(CMessage message);
        abstract public CMessage GetRecordMessage(CMessage message, int Index);
        abstract public bool WriteVar(CVar Var, String Value, AutoResetEvent objectNotify);
        public bool WriteVar(String VarName, String Value, AutoResetEvent objectNotify)
        {
            foreach (CMessage message in this.Messages)
            {
                CVar var = message.GetVar(VarName);
                if (var != null)
                {
                    return WriteVar(var, Value, objectNotify);
                }
            }

            return false;
        }
        abstract public bool SyncDateTime();

        public CVar GetVar(String VarName)
        {

            for (int i = 0; i < this.Messages.Count; i++)
            {
                CMessage message = this.Messages[i];

                for (int j = 0; j < message.Vars.Count; j++)
                {
                    CVar Var = message.Vars[j];
                    if (Var.Name == VarName)
                    {
                        return Var;
                    }
                }
            }

            return null;
        }

        public CMessage GetMessage(String MessageName)
        {
            for (int i = 0; i < this.Messages.Count; i++)
            {
                if (this.Messages[i].Name == MessageName)
                    return this.Messages[i];
            }

            return null;
        }

        public CMessage GetMessage(int MessageIndex)
        {
            for (int i = 0; i < this.Messages.Count; i++)
            {
                if (this.Messages[i].Index == MessageIndex)
                    return this.Messages[i];
            }

            return null;
        }

        public void ParseDeviceFromXml(string IEDType)
        {
            //读取XML
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\IED\\" + IEDType + ".xml");
                XmlNode root = doc.SelectSingleNode("Device");
                this.Name = root.Attributes["Name"].Value;
                this.DoubleWordMode = root.Attributes["DoubleWordMode"].Value;
                this.Address = Convert.ToInt32(root.Attributes["Address"].Value);

                XmlNodeList messageList = root.SelectNodes("Message");
                foreach (XmlNode messageNode in messageList)
                {
                    CMessage message = new CMessage();
                    message.Index = Convert.ToInt32(messageNode.Attributes["Index"].Value);
                    message.Name = messageNode.Attributes["Name"].Value;
                    message.Type = Convert.ToInt32(messageNode.Attributes["Type"].Value);
                    message.Desc = messageNode.Attributes["Desc"].Value;
                    String schema = messageNode.Attributes["Schema"].Value;
                    String[] Bytes = schema.Split(' ');
                    message.Schema = new byte[Bytes.Length];
                    for (int i = 0; i < Bytes.Length; i++)
                    {
                        message.Schema[i] = (byte)Convert.ToInt16(Bytes[i], 16);
                    }
                    message.Vars = new List<CVar>();

                    //如果类型是记录则获取其数量
                    if (messageNode.Attributes["Count"] != null)
                        message.Count = Convert.ToInt32(messageNode.Attributes["Count"].Value);

                    message.Memo = messageNode.Attributes["Memo"].Value;

                    this.Messages.Add(message);

                    XmlNodeList varList = messageNode.SelectNodes("Var");
                    foreach (XmlNode varNode in varList)
                    {
                        CVar var = new CVar();
                        var.Name = varNode.Attributes["Name"].Value;
                        var.Desc = varNode.Attributes["Desc"].Value;
                        var.Length = Convert.ToInt32(varNode.Attributes["Length"].Value);
                        var.ByteOffset = Convert.ToInt32(varNode.Attributes["ByteOffset"].Value);
                        var.BitOffset = Convert.ToInt32(varNode.Attributes["BitOffset"].Value);
                        var.Unit = varNode.Attributes["Unit"].Value;
                        var.DataType = Convert.ToInt32(varNode.Attributes["DataType"].Value);
                        var.Default = varNode.Attributes["Default"].Value;
                        var.Multiple = Convert.ToDouble(varNode.Attributes["Multiple"].Value);
                        var.Table = Convert.ToBoolean(varNode.Attributes["Table"].Value);
                        var.Memo = varNode.Attributes["Memo"].Value;

                        if (varNode.Attributes["Min"] != null)
                        {
                            var.MinValue = Convert.ToDouble(varNode.Attributes["Min"].Value);
                            var.MaxValue = Convert.ToDouble(varNode.Attributes["Max"].Value);
                        }

                        if (var.Table)
                            var.Tables = new List<CTable>();

                        var.OwnerMessage = message;
                        message.Vars.Add(var);

                        XmlNodeList tableList = varNode.SelectNodes("T");
                        foreach (XmlNode tableNode in tableList)
                        {
                            CTable table = new CTable();
                            table.Index = Convert.ToInt32(tableNode.Attributes["Index"].Value);
                            table.Value = tableNode.Attributes["Value"].Value;

                            var.Tables.Add(table);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }

        public bool ExchangeMessage(CMessage message, AutoResetEvent objectNotify)
        {
            readWriteLockExchangeMsg.WaitOne();

            message.NotifyObj = objectNotify;
            message.SendAndRecieveSuccess = false;
            this.AddUpdateMessage(message);

            try
            {
                objectNotify.WaitOne(3000);        //报文交换最长等待时间
            }
            catch (ThreadInterruptedException)
            {
            }

            readWriteLockExchangeMsg.ReleaseMutex();

            return message.SendAndRecieveSuccess;
        }

        public void AddUpdateMessage(CMessage message)
        {

            rwl.WaitOne();

            if (UpdateMessages.IndexOf(message) < 0)
                UpdateMessages.Add(message);

            rwl.ReleaseMutex();
        }

        public List<CMessage> GetUpdateMessages()
        {

            List<CMessage> _Messages = new List<CMessage>();

            rwl.WaitOne();

            _Messages.AddRange(UpdateMessages);
            UpdateMessages.Clear();

            rwl.ReleaseMutex();

            return _Messages;
        }

        public int GetUpdateMessageCount()
        {
            int Count = 0;
            rwl.WaitOne();
            Count = UpdateMessages.Count;
            rwl.ReleaseMutex();
            return Count;
        }

        public void SetConnected(bool _Connected)
        {
            rwl.WaitOne();
            this.IsConnected = _Connected;
            rwl.ReleaseMutex();
        }

        public bool Connected()
        {
            bool _Connected = false;
            rwl.WaitOne();
            _Connected = this.IsConnected;
            rwl.ReleaseMutex();
            return _Connected;
        }

        public bool LoadParameterFile(String Filepath)
        {
            try
            {
                ParamFileName = Filepath;

                ParamDocument = new XmlDocument();
                ParamDocument.Load(ParamFileName);
                XmlNode device = ParamDocument.SelectSingleNode("Device");
                String DeviceName = device.Attributes["Name"].Value;
                if (DeviceName != this.Name)
                {
                    MessageBox.Show("设备类型错误，定值文件加载失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ParamDocument = null;
                    return false;
                }
            }
            catch (Exception e)
            {                
                ParamDocument = null;
                return false;
            }

            return true;
        }

        public bool NewParameterFile(String Filepath)
        {
            try
            {
                ParamFileName = Filepath;

                ParamDocument = new XmlDocument();
                                
                XmlDeclaration declaration = ParamDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
                ParamDocument.AppendChild(declaration);

                XmlElement device = ParamDocument.CreateElement("Device");
                device.SetAttribute("Name", this.Name);
                device.SetAttribute("UpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ParamDocument.AppendChild(device);
                ParamDocument.Save(ParamFileName);
            }
            catch (Exception e)
            {
                ParamDocument = null;
                return false;
            }

            return true;
        }

        public String GetParamValue(String VarName)
        {
            if (ParamDocument == null)
                return null;

            XmlNode varNode = ParamDocument.SelectSingleNode("/Device/Message/Var[@Name='" + VarName + "']");
            if (varNode != null)
                return varNode.Attributes["Value"].Value;
            else
                return null;
        }

        public void SetParamValue(CVar Var, Object VarValue)
        {
            if (ParamDocument == null)
                return;

            XmlNode deviceNode = ParamDocument.SelectSingleNode("Device");
            XmlElement varNode = (XmlElement)deviceNode.SelectSingleNode("Message/Var[@Name='" + Var.Name + "']");
            if (varNode != null)
                varNode.SetAttribute("Value", VarValue.ToString());
            else
            {
                XmlElement messageNode = (XmlElement)deviceNode.SelectSingleNode("Message[@Index=" + (((CMessage)Var.OwnerMessage).Index).ToString() + "]");
                if (messageNode == null)
                {
                    messageNode = ParamDocument.CreateElement("Message");
                    messageNode.SetAttribute("Index", (((CMessage)Var.OwnerMessage).Index).ToString());
                    deviceNode.AppendChild(messageNode);
                }

                varNode = ParamDocument.CreateElement("Var");
                varNode.SetAttribute("Name", Var.Name);
                varNode.SetAttribute("Value", VarValue.ToString());

                messageNode.AppendChild(varNode);
            }           
        }

        public bool HasLoadFromFile()
        {
            return ParamDocument != null;
        }

        public void SaveParameterFile()
        {
            if (ParamDocument == null)
                return;

            try
            {
                ParamDocument.Save(ParamFileName);
            }
            catch (Exception e)
            {
                ParamDocument = null;
            }
        }

        public bool SaveAllToFile(System.Windows.Forms.ProgressBar progressBar)
        {
            if (ParamDocument == null)
                return false;

            progressBar.Maximum = 0;
            for (int i = 0; i < this.Messages.Count; i++)
            {
                DeviceBase.CMessage message = this.Messages[i];
                if (message.Type == 1)
                {
                    progressBar.Maximum++;
                }
            }
            
            for (int i = 0; i < this.Messages.Count; i++)
            {
                DeviceBase.CMessage message = this.Messages[i];
                if (message.Type == 1)
                {
                    DeviceBase.CMessage msgClone = message.Clone();
                    if (!ExchangeMessage(msgClone, new AutoResetEvent(false)))
                        return false;

                    progressBar.Value++;
                }
            }            

            for (int i = 0; i < this.Messages.Count; i++)
            {
                DeviceBase.CMessage message = this.Messages[i];
                if (message.Type == 1)
                {
                    for (int j = 0; j < message.Vars.Count; j++)
                    {
                        DeviceBase.CVar Var = message.Vars[j];
                        Object VarValue = RTDB.GetVarValue(this.Name, Var.Name);
                        if (VarValue != null)
                        {
                            this.SetParamValue(Var, VarValue);
                        }
                    }
                }
            }

            this.SaveParameterFile();

            return true;
        }

        public bool SaveAllToDevice(System.Windows.Forms.ProgressBar progressBar)
        {
            if (ParamDocument == null)
                return false;

            List<CMessage> readMessageList = new List<CMessage>();

            progressBar.Maximum = 0;
            XmlNodeList varList = ParamDocument.SelectNodes("/Device/Message/Var");
            foreach (XmlNode varNode in varList)
            {
                String VarName = varNode.Attributes["Name"].Value;
                String RefValue = varNode.Attributes["Value"].Value;

                DeviceBase.CVar Var = this.GetVar(VarName);
                Object VarValue = RTDB.GetVarValue(this.Name, VarName);

                if (VarValue != null && VarValue.ToString() == RefValue)
                    continue;

                if (readMessageList.IndexOf((CMessage)Var.OwnerMessage) < 0)
                    readMessageList.Add((CMessage)Var.OwnerMessage);

                progressBar.Maximum++;
            }

            foreach (XmlNode varNode in varList)
            {
                String VarName = varNode.Attributes["Name"].Value;
                String RefValue = varNode.Attributes["Value"].Value;

                DeviceBase.CVar Var = this.GetVar(VarName);
                Object VarValue = RTDB.GetVarValue(this.Name, VarName);

                if (VarValue != null && VarValue.ToString() == RefValue)
                    continue;

                if (!WriteVar(Var, RefValue, new AutoResetEvent(false)))
                    return false;

                progressBar.Value++;
            }

            foreach (CMessage readMessage in readMessageList)
            {
                this.AddUpdateMessage(readMessage);
            }

            return true;
        }
}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IEDSToolkit.IED
{
    class CRTDB
    {
        private Mutex rwl = new Mutex();
        private Hashtable RTDB = new Hashtable();

        public string IEDType;
        private DeviceBase Device;

        public CRTDB(String _IEDType)
        {
            this.IEDType = _IEDType;

            switch (_IEDType)
            {
                case "ST570":
                case "ST570L": this.Device = new ST570(this); break; 
                default: this.Device = new ST570(this); break;
            }

            this.Device.ParseDeviceFromXml(IEDType);

            SetVarValue(this.Device.Name, "_ConnectState_", CommTCPServerThread.DeviceDisConnected);
        }

        public DeviceBase GetDevice()
        {
            return Device;
        }

        /**
         * 根据设备名称和变量名称获取变量实时值
         * @param Device
         * @param Var
         * @return
         */
        public Object GetVarValue(String Device, String Var)
        {
            Object Value = null;
            rwl.WaitOne();

            Value = RTDB[Device + "##" + Var];

            rwl.ReleaseMutex();
            return Value;
        }

        /**
         * 根据设备和变量对象获取变量值，如果在RTDB中没有该变量值则使用报文从设备中读取
         * @param Device
         * @param Var
         * @param NotifyObj
         * @return
         */
        //public Object GetVarValue(DeviceBase Device, DeviceBase.CVar Var, Handler NotifyObj)
        //{
        //    Object Value = GetVarValue(Device.Name, Var.Name);
        //    if (Value == null && Var.OwnerMessage != null)
        //    {
        //        if (CRTDB.GetDevice().ExchangeMessage((DeviceBase.CMessage)Var.OwnerMessage, NotifyObj))
        //            Value = CRTDB.GetVarValue(Device.Name, Var.Name);
        //    }
        //    return Value;
        //}

        public void SetVarValue(String Device, String Var, Object Value)
        {
            rwl.WaitOne();

            //if (RTDB.get(Device + "##" + Var) != null)
            RTDB[Device + "##" + Var] = Value;

            rwl.ReleaseMutex();
        }
    }
}

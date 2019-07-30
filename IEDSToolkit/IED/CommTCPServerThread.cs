using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace IEDSToolkit.IED
{
    class CommTCPServerThread
    {
        public static int DeviceDisConnected = 0;  //设备连接断开
        public static int DeviceConnected = 1;     //设备已经连

        private Thread thread = null;

        public CRTDB RTDB;

        public CommTCPServerThread(CRTDB _RTDB)
        {
            this.RTDB = _RTDB;
        }

        public void Start()
        {
            if (thread == null)
                thread = new Thread(Run);
            thread.Start();
        }

        private bool terminated = false;
        private bool needDisconnectdevice = false;
        private Socket serverSocket = null;
        private Socket listenSocket = null;

        private Mutex rwl = new Mutex();

        private void Run()
        {
            IPAddress ip = IPAddress.Parse("0.0.0.0");
            IPEndPoint ipe = new IPEndPoint(ip, 8080);

            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ipe);
            listenSocket.Listen(int.MaxValue);

            byte[] data = new byte[1024 * 4];
            int recvCount = 0;

            DeviceBase device = RTDB.GetDevice();
            try
            {
                while (!terminated)
                {
                    RTDB.SetVarValue(device.Name, "_ConnectState_", DeviceDisConnected);
                    
                    serverSocket = listenSocket.Accept();
                    serverSocket.ReceiveTimeout = 3000;
                    serverSocket.SendTimeout = 3000;

                    Thread.Sleep(1000);

                    try
                    {
                        serverSocket.Receive(data); //扔掉无用数据
                    }
                    catch (Exception)
                    {
                        serverSocket = null;
                        continue;
                    }
                    
                    try
                    {
                        while (!terminated)
                        {
                            List<DeviceBase.CMessage> UpdateMessages = device.GetUpdateMessages();
                            for (int i = 0; i < UpdateMessages.Count; i++)
                            {
                                //断开连接
                                if (this.NeedDisconnectDevice())
                                    break;

                                DeviceBase.CMessage message = UpdateMessages[i];
                                byte[] sendData = device.GetSchema(message);

                                //重试一次
                                message.SendAndRecieveSuccess = false;
                                for (int CommCount = 0; CommCount < 2; CommCount++)
                                {
                                    serverSocket.Send(sendData);

                                    Thread.Sleep(100);

                                    OutputMessage(sendData, sendData.Length, 0);

                                    if ((recvCount = serverSocket.Receive(data)) != -1)
                                    {
                                        int ParseResult = device.Parse(data, recvCount, message, sendData);

                                        OutputMessage(data, recvCount, 1);

                                        if (ParseResult == -1)
                                        {
                                            //重试
                                            CommCount--;
                                            continue;
                                        }
                                        else if (ParseResult != 0)
                                        {
                                            //重试
                                            continue;
                                        }

                                        message.SendAndRecieveSuccess = true;
                                        break;
                                    }
                                }

                                if (message.NotifyObj != null)
                                {                                    
                                    message.NotifyObj.Set();                                    
                                }
                            }

                            for (int i = 0; i < device.Messages.Count; i++)
                            {

                                //断开连接
                                if (this.NeedDisconnectDevice())
                                    break;

                                DeviceBase.CMessage message = device.Messages[i];
                                if (message.Type != 0)
                                    continue;

                                byte[] sendData = device.GetSchema(message);

                                //重试一次
                                for (int CommCount = 0; CommCount < 2; CommCount++)
                                {

                                    serverSocket.Send(sendData);

                                    Thread.Sleep(100);

                                    OutputMessage(sendData, sendData.Length, 0);

                                    if ((recvCount = serverSocket.Receive(data)) != -1)
                                    {
                                        int ParseResult = device.Parse(data, recvCount, message, sendData);

                                        if (ParseResult != 0)
                                        {
                                            //重试
                                            continue;
                                        }

                                        OutputMessage(data, recvCount, 1);
                                        break;
                                    }
                                }

                                if (device.GetUpdateMessageCount() > 0)
                                    break;

                                break;
                            }

                            //断开连接
                            if (this.NeedDisconnectDevice())
                            {
                                needDisconnectdevice = false;
                                serverSocket.Close();
                                serverSocket = null;
                                break;
                            }
                            
                            RTDB.SetVarValue(device.Name, "_ConnectState_", DeviceConnected);

                            if (device.GetUpdateMessageCount() > 0)
                                continue;

                            Thread.Sleep(200);
                        }
                    }
                    catch (Exception e)
                    {
                        serverSocket = null;
                    }                    
                }
            }
            catch (Exception e)
            {
                serverSocket = null;
            }
            finally
            {
                try
                {
                    listenSocket.Close();
                }
                catch (Exception e)
                {
                }
            }
        }

        public void Terminate()
        {
            terminated = true;
            if (listenSocket != null)
            {
                try
                {
                    if (serverSocket != null)
                        serverSocket.Close();
                    listenSocket.Close();                    
                }
                catch (Exception)
                {
                }
            }
        }

        //public void SetMessageHandler(Handler _handler)
        //{

        //    rwl.writeLock().lock () ;

        //    this.MessageHandler = _handler;

        //    rwl.writeLock().unlock();
        //}

        private void OutputMessage(byte[] Data, int Length, int Type)
        {
        //    rwl.writeLock().lock () ;
        //    if (this.MessageHandler == null)
        //    {
        //        rwl.writeLock().unlock();
        //        return;
        //    }

        //    this.MessageString = StringUtility.byte2HexStr(Data, Length);

        //    Message message = MessageHandler.obtainMessage(0, Type, Type);
        //    MessageHandler.sendMessage(message);

        //    rwl.writeLock().unlock();
        }

        public void DisconnectDevice()
        {
            rwl.WaitOne();
            needDisconnectdevice = true;
            rwl.ReleaseMutex();
        }

        private bool NeedDisconnectDevice()
        {
            bool value = false;
            rwl.WaitOne();
            value = needDisconnectdevice;
            rwl.ReleaseMutex();
            return value;
        }
    }
}

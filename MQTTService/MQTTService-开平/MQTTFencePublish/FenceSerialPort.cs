using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTClient
{
    public partial class FenceSerialPort
    {
        private string Com = ConfigurationManager.AppSettings["Com"];
        private string Rate = ConfigurationManager.AppSettings["Rate"];
        private string Bits = ConfigurationManager.AppSettings["Bits"];
        private string Parity = ConfigurationManager.AppSettings["Parity"];
        private string StopBits = ConfigurationManager.AppSettings["StopBits"];

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort ComDevice = new SerialPort();

        MQTTClientModule mqttclient = new MQTTClientModule();

        /// <summary>
        /// 打开串口
        /// </summary>
        public void OpenSerial()
        {
            Task.Run(async () => { await mqttclient.ConnectMqttServerAsync(); });
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件
            if (Com == "")
            {
                Console.WriteLine("没有发现串口,请检查线路！");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = Com;
                ComDevice.BaudRate = Convert.ToInt32(Rate);
                ComDevice.Parity = (Parity)Convert.ToInt32(Parity);
                ComDevice.DataBits = Convert.ToInt32(Bits);
                ComDevice.StopBits = (StopBits)Convert.ToInt32(StopBits);
                try
                {
                    ComDevice.Open();
                    Console.WriteLine("开启串口成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("开启串口失败：" + ex.Message);
                    Trace.WriteLine("开启串口失败：" + ex.Message, "SerialConnectStatus");
                    return;
                }
            }
            else
            {
                try
                {
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("关闭串口失败：" + ex.Message, "SerialConnectStatus");
                    Console.WriteLine("关闭串口失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClearSelf()
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    ComDevice.Write(data, 0, data.Length);//发送数据
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发送数据失败:" + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("串口未打开");
            }
            return false;
        }

        /// <summary>
        /// 发送数据button事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendDataTo(string senddata)
        {
            byte[] sendData = null;
            sendData = strToHexByte(senddata.Trim());
            if (this.SendData(sendData))//发送数据成功计数
            {
                string count = senddata.Length.ToString();
                Console.WriteLine("发送数据计数："+ count);
            }
            else
            {

            }
        }

        /// <summary>
        /// 字符串转换16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private List<byte> buffer = new List<byte>(4096);
        private byte[] ReceiveBytes = new byte[8];//AA 44 05 01 02 03 04 05 EA 

        private string topic = ConfigurationManager.AppSettings["topic"];

        private async Task dealMsgAsync(string AlarmInfo)
        {
            await mqttclient.Publish(topic, AlarmInfo);
        }


        // 时间分量转换成实际的秒数 
        public static ulong GetDateTime(DateTime recordTime)
        {
            int year = recordTime.Year;
            int month = recordTime.Month;
            int day = recordTime.Day;
            int hour = recordTime.Hour;
            int minute = recordTime.Minute;
            int second = recordTime.Second;

            ulong dateVal = 0;
            try
            {
                DateTime dt = new DateTime(year, month, day, hour, minute, second);
                DateTime dt0 = new DateTime(1970, 1, 1);
                TimeSpan ts = new TimeSpan(dt.Ticks - dt0.Ticks);
                dateVal = (ulong)ts.TotalSeconds;
            }
            catch (Exception e)
            {

            }
            return dateVal;
        }
        Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
        //接收串口过来信息进行分析
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据
            buffer.AddRange(ReDatas);
            string alarmNum = "";
            DateTime currentTime = new DateTime();
            DateTime recordTime = new DateTime();


            List<Dictionary<string, DateTime>> list = new List<Dictionary<string, DateTime>>();

            while (buffer.Count >= 8)
            {
                if (buffer[0] == 0xDE && buffer[1] == 0xDE && buffer[2] == 0x81)
                {
                    int len = 4;
                    if (buffer.Count < len + 4) break;
                    buffer.CopyTo(0, ReceiveBytes, 0, len + 4);
                    buffer.RemoveRange(0, len + 4);
                    if (ReceiveBytes[4] == 0x05)
                    {
                        try
                        {
                            //TestJson(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "张力围栏向pc端发送数据");
                            if (ReceiveBytes[5] == 0x16 || ReceiveBytes[6] == 0x4F)//报警
                            {
                                alarmNum = ReceiveBytes[3].ToString();
                                //TestJson(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + alarmNum+"防区报警");

                                long recordSecond = recordTime.Ticks;
                                ulong currentSecond = GetDateTime(DateTime.Now);

                                //long differSecond = currentSecond - recordSecond;
                                if (!dic.ContainsKey(alarmNum))
                                {
                                    recordTime = DateTime.Now;
                                    dic.Add(alarmNum, recordTime);
                                    AlamrEntity entity = new AlamrEntity();
                                    entity.topic = topic;
                                    entity.deviceName = "围栏串口设备";
                                    entity.alarmName = "围栏报警";
                                    entity.alarmType = "围栏报警";
                                    entity.alarmNum = alarmNum;
                                    entity.alarmTime = recordTime.ToString("yyyy-MM-dd HH:mm:ss");
                                    string json = JsonConvert.SerializeObject(entity);

                                    Task.Run(async () => { await dealMsgAsync(json); });
                                }
                                else
                                {
                                    if (currentSecond - GetDateTime(dic[alarmNum]) > 60)
                                    {
                                        currentTime = DateTime.Now;
                                        dic[alarmNum] = currentTime;
                                        
                                        AlamrEntity entity = new AlamrEntity();
                                        entity.topic = topic;
                                        entity.deviceName = "围栏串口设备";
                                        entity.alarmName = "围栏报警";
                                        entity.alarmType = "围栏报警";
                                        entity.alarmNum = alarmNum;
                                        entity.alarmTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                                        string json = JsonConvert.SerializeObject(entity);

                                        Task.Run(async () => { await dealMsgAsync(json); });
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":推送数据失败——" + ex.Message);
                        }
                    }
                    else if (ReceiveBytes[4] == 0x02)
                    {
                        if (ReceiveBytes[5] == 0x61 || ReceiveBytes[6] == 0x37)//布防
                        {
                            string bfalarmNum = ReceiveBytes[3].ToString();

                            AlamrEntity entity = new AlamrEntity();
                            entity.topic = topic;
                            entity.deviceName = "围栏串口设备";
                            entity.alarmName = bfalarmNum+"防区布防";
                            entity.alarmType = "布防";
                            entity.alarmNum = alarmNum;
                            entity.alarmTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string json = JsonConvert.SerializeObject(entity);

                            Task.Run(async () => { await dealMsgAsync(json); });
                        }
                        else if (ReceiveBytes[5] == 0x0A || ReceiveBytes[6] == 0x5C)//撤防
                        {
                            string bfalarmNum = ReceiveBytes[3].ToString();

                            AlamrEntity entity = new AlamrEntity();
                            entity.topic = topic;
                            entity.deviceName = "围栏串口设备";
                            entity.alarmName = bfalarmNum + "防区撤防";
                            entity.alarmType = "撤防";
                            entity.alarmNum = alarmNum;
                            entity.alarmTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string json = JsonConvert.SerializeObject(entity);
                            Task.Run(async () => { await dealMsgAsync(json); });
                        }
                    }
                }
                else
                {
                    buffer.RemoveAt(0);
                }
            }

        }


    }
}

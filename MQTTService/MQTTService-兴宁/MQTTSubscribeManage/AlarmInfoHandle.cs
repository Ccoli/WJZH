using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MQTTSubscribeManage
{
    /// <summary>
    /// 报警信息结构
    /// </summary>
    public class AlarmMessage
    {
        public string CameraId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public int Type { set; get; }        //报警种类0：人，1：机动车，2：非机动车    3:人脸识别--另外加入的一个识别对象
        public string EventType { set; get; }   //报警类型
        public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
        public Dictionary<string,string> FaceInfo { set; get; } //人脸识别信息
    }

    public class AlarmInfoHandle
    {
        public string ParsingActionJson(string jsonstr)
        {
            AlarmMessage info = new AlarmMessage();
            string jsonData = "";
            try
            {
                JObject json = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonstr);
                info.CameraId = json["CameraId"].ToString();
                string imageUrl = json["imageUrl"].ToString();

                //获取本机名称
                string hostname = Dns.GetHostName();
                //获取本机DNS信息
                IPHostEntry localhost = Dns.GetHostEntry(hostname);
                //IPv6地址
                IPAddress myIP_v6 = localhost.AddressList[0];
                //IPv4地址
                IPAddress myIP_v4 = localhost.AddressList[1];
                string url = ConfigurationManager.AppSettings["PictureIP"];
                if (url == "" || url == null)
                {
                    url = myIP_v4.ToString();
                }
                string port = ConfigurationManager.AppSettings["PicturePort"];
                info.ImageUrl = string.Format("http://{0}:{1}/{2}", url, port,imageUrl);

                var obj = json["peopleInfo"];
                var obj1 = json["carInfo"];
                var obj2 = json["NonVehiclesInfo"];
                var obj3 = json["faceInfo"];
                if (obj.ToArray().Length>0 )
                {
                    info.Type = 0;
                    string EventType = obj[0]["eventType"].ToString();
                    if (EventType == "intrusion") {
                        EventType = "区域入侵";
                    }
                    else if (EventType== "wireCross")
                    {
                        EventType = "越线";
                    }
                    info.EventType= EventType;
                    if (obj[0]["Feature"] != null){
                        info.Feature = obj[0]["Feature"].ToString();
                    }
                    else
                    {
                        info.Feature = "";
                    }
                   
                }else if (obj1.ToArray().Length > 0)
                {
                    info.Type = 1;
                    string EventType = obj1[0]["eventType"].ToString();
                    if (EventType == "intrusion")
                    {
                        EventType = "区域入侵";
                    }
                    else if (EventType == "wireCross")
                    {
                        EventType = "越线";
                    }
                    info.EventType = EventType;
                    if (obj1[0]["Feature"] != null)
                    {
                        info.Feature = obj1[0]["Feature"].ToString();
                    }
                    else
                    {
                        info.Feature = "";
                    }
                }
                else if (obj2.ToArray().Length>0)
                {
                    info.Type = 2;
                    string EventType = obj2[0]["eventType"].ToString();
                    if (EventType == "intrusion")
                    {
                        EventType = "区域入侵";
                    }
                    else if (EventType == "wireCross")
                    {
                        EventType = "越线";
                    }
                    info.EventType = EventType;
                    if (obj2[0]["Feature"] != null)
                    {
                        info.Feature = obj2[0]["Feature"].ToString();
                    }
                    else
                    {
                        info.Feature = "";
                    }
                }
                else if (obj3.ToArray().Length > 0)
                {
                    info.Type = 3;
                    string EventType = "人脸识别";
                   
                    info.EventType = EventType;
                    var obj4 = obj3[0]["faceLibraryInfo"];
                    var dc = new Dictionary<string, string>();
                    dc.Add("FaceId", obj4[0]["custom1"].ToString());
                    dc.Add("Name", obj4[0]["name"].ToString());
                    dc.Add("Similar", obj4[0]["similar"].ToString());
                    info.FaceInfo = dc;
                }
                var time =Convert.ToDouble(json["time"]);
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddMilliseconds(time);
                info.time = dt.ToString("yyyy-MM-dd HH:mm:ss");
                jsonData = JsonConvert.SerializeObject(info);
            }
            catch(Exception ex)
            {
                Console.WriteLine("json解析失败：" + ex.Message);
                Trace.WriteLine("json转换数据失败！" + ex.Message + Environment.NewLine, "MqttConnectStatus");
            }
            return jsonData;
        }
    }
}

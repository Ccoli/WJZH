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
    public class ActionAlarmMessage
    {
        public string DeviceId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public string Type { set; get; }        //报警种类0：人，1：机动车，2：非机动车   
        public string EventType { set; get; }   //报警类型
        //public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
    }

    public class FaceAlarmMessage
    {
        public string DeviceId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public string Type { set; get; }        //报警种类  3:人脸识别--另外加入的一个识别对象
        public string EventType { set; get; }   //报警类型
        //public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
        public Dictionary<string, string> FaceInfo { set; get; } //人脸识别信息
    }

    public class TeZhenAlarmMessage
    {
        public string DeviceId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public string Type { set; get; }        //报警种类0：人，1：机动车，2：非机动车   
        public string EventType { set; get; }   //报警类型
                                                // public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
        public Dictionary<string, string> MixedDetect { set; get; } //混合检测信息
    }

    public class AlarmInfoHandle
    {
        ToolHelper tl = new ToolHelper();
        public string ParsingActionJson(string jsonstr)
        {
            ActionAlarmMessage info = new ActionAlarmMessage();
            string jsonData = "";
            try
            {
                //jsonstr = System.Web.HttpUtility.UrlDecode(jsonstr, Encoding.UTF8);
                JObject json = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonstr);
                info.DeviceId = json["DeviceId"].ToString();
                string imageUrl = json["ImageUrl"].ToString();

                string[] arr = tl.GetImgIp();
                string url = arr[0];
                string port = arr[1];
                info.ImageUrl = string.Format("http://{0}:{1}/{2}", url, port, imageUrl);

                var obj = json["peopleInfo"];
                var obj1 = json["carInfo"];
                var obj2 = json["NonVehiclesInfo"];
                var obj3 = json["faceInfo"];
                if (obj.ToArray().Length > 0)
                {
                    info.Type = "人";
                    string EventType = obj[0]["eventType"].ToString();
                    if (EventType == "intrusion")
                    {
                        EventType = "区域入侵";
                    }
                    else if (EventType == "wireCross")
                    {
                        EventType = "越线";
                    }
                    else if (EventType == "loitering")
                    {
                        EventType = "徘徊检测";
                    }
                    info.EventType = EventType;

                }
                else if (obj1.ToArray().Length > 0)
                {
                    info.Type = "机动车";
                    string EventType = obj1[0]["eventType"].ToString();
                    if (EventType == "intrusion")
                    {
                        EventType = "区域入侵";
                    }
                    else if (EventType == "wireCross")
                    {
                        EventType = "越线";
                    }
                    else if (EventType == "loitering")
                    {
                        EventType = "徘徊检测";
                    }
                    info.EventType = EventType;
                }
                else if (obj2.ToArray().Length > 0)
                {
                    info.Type = "非机动车";
                    string EventType = obj2[0]["eventType"].ToString();
                    if (EventType == "intrusion")
                    {
                        EventType = "区域入侵";
                    }
                    else if (EventType == "wireCross")
                    {
                        EventType = "越线";
                    }
                    else if (EventType == "loitering")
                    {
                        EventType = "徘徊检测";
                    }
                    info.EventType = EventType;
                }
                var time = Convert.ToDouble(json["time"]);
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddMilliseconds(time);
                info.time = dt.ToString("yyyy-MM-dd HH:mm:ss");
                jsonData = JsonConvert.SerializeObject(info);
            }
            catch (Exception ex)
            {
                Console.WriteLine("json解析失败：" + ex.Message);
                Trace.WriteLine("json转换数据失败！" + ex.Message + Environment.NewLine, "JsonStatus");
            }
            return jsonData;
        }

        public string ParsingFaceJson(string jsonstr)
        {
            FaceAlarmMessage info = new FaceAlarmMessage();
            string jsonData = "";
            try
            {
                //jsonstr = System.Web.HttpUtility.UrlDecode(jsonstr, Encoding.UTF8);
                JObject json = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonstr);
                info.DeviceId = json["DeviceId"].ToString();
                string imageUrl = json["ImageUrl"].ToString();

                string[] arr = tl.GetImgIp();
                string url = arr[0];
                string port = arr[1];
                info.ImageUrl = string.Format("http://{0}:{1}/{2}", url, port, imageUrl);

                var obj3 = json["faceInfo"];
                if (obj3.ToArray().Length > 0)
                {
                    info.Type = "人脸识别";
                    string EventType = "人脸识别";

                    info.EventType = EventType;
                    var obj4 = obj3[0]["faceLibraryInfo"];
                    if (obj4.ToArray().Length > 0)
                    {
                        var dc = new Dictionary<string, string>();
                        dc.Add("FaceId", obj4[0]["custom1"].ToString());
                        dc.Add("Name", obj4[0]["name"].ToString());
                        dc.Add("Similar", obj4[0]["similar"].ToString());
                        info.FaceInfo = dc;
                    }
                }
                var time = Convert.ToDouble(json["time"]);
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddMilliseconds(time);
                info.time = dt.ToString("yyyy-MM-dd HH:mm:ss");
                if (info.FaceInfo == null)
                {
                    jsonData = "";
                }
                else
                {
                    jsonData = JsonConvert.SerializeObject(info);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("json解析失败：" + ex.Message);
                Trace.WriteLine("json转换数据失败！" + ex.Message + Environment.NewLine, "JsonStatus");
            }
            return jsonData;
        }

        public string ParsingTeZhenJson(string jsonstr)
        {
            TeZhenAlarmMessage info = new TeZhenAlarmMessage();
            string jsonData = "";
            try
            {
                //jsonstr = System.Web.HttpUtility.UrlDecode(jsonstr, Encoding.UTF8);
                JObject json = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonstr);
                info.DeviceId = json["DeviceId"].ToString();
                string imageUrl = json["ImageUrl"].ToString();

                string[] arr = tl.GetImgIp();
                string url = arr[0];
                string port = arr[1];
                info.ImageUrl = string.Format("http://{0}:{1}/{2}", url, port, imageUrl);

                var obj = json["peopleInfo"];
                var obj1 = json["carInfo"];
                var obj2 = json["NonVehiclesInfo"];
                var obj3 = json["faceInfo"];
                //if (obj.ToArray().Length > 0)
                //{
                //    info.Type = "人";
                //    string EventType = obj[0]["eventType"].ToString();
                //    if (EventType == "mixedDetect")
                //    {
                //        EventType = "混合检测";

                //        var obj4 = obj[0]["attribute"];
                //        var dc = new Dictionary<string, string>();
                //        dc.Add("Type", "people");
                //        dc.Add("Age", obj4["Age"]["Name"].ToString());
                //        dc.Add("Baby", obj4["Baby"]["Name"].ToString());
                //        dc.Add("Bag", obj4["Bag"]["Name"].ToString());
                //        dc.Add("BottomColor", obj4["BottomColor"]["Name"].ToString());
                //        dc.Add("BottomType", obj4["BottomType"]["Name"].ToString());
                //        dc.Add("Glasses", obj4["Glasses"]["Name"].ToString());
                //        dc.Add("Hat", obj4["Hat"]["Name"].ToString());
                //        dc.Add("Knapsack", obj4["Knapsack"]["Name"].ToString());
                //        dc.Add("Orientation", obj4["Orientation"]["Name"].ToString());
                //        dc.Add("Sex", obj4["Sex"]["Name"].ToString());
                //        dc.Add("ShoulderBag", obj4["ShoulderBag"]["Name"].ToString());
                //        dc.Add("UpperColor", obj4["UpperColor"]["Name"].ToString());
                //        dc.Add("UpperType", obj4["UpperType"]["Name"].ToString());
                //        info.MixedDetect = dc;
                //    }

                //    info.EventType = EventType;

                //}
                //else 
                if (obj1.ToArray().Length > 0)
                {
                    info.Type = "机动车";
                    string EventType = obj1[0]["eventType"].ToString();
                    if (EventType == "mixedDetect")
                    {
                        EventType = "车辆检测";
                        var obj4 = obj1[0]["attribute"];
                        var dc = new Dictionary<string, string>();
                        dc.Add("Type", "car");
                        dc.Add("Brand", obj4["Brand"]["Name"].ToString());
                        dc.Add("Licence", obj4["Licence"]["Name"].ToString());
                        dc.Add("Mistake", obj4["Mistake"]["Name"].ToString());
                        dc.Add("PlateColor", obj4["PlateColor"]["Name"].ToString());
                        dc.Add("PlateRect", obj4["PlateRect"]["Name"].ToString());
                        dc.Add("PlateType", obj4["PlateType"]["Name"].ToString());
                        dc.Add("VehicleColor", obj4["VehicleColor"]["Name"].ToString());
                        dc.Add("VehicleType", obj4["VehicleType"]["Name"].ToString());
                        info.MixedDetect = dc;
                    }
                    info.EventType = EventType;
                }
                //else if (obj2.ToArray().Length > 0)
                //{
                //    info.Type = "非机动车";
                //    string EventType = obj2[0]["eventType"].ToString();
                //    if (EventType == "mixedDetect")
                //    {
                //        EventType = "混合检测";
                //    }
                //    info.EventType = EventType;
                //}
                var time = Convert.ToDouble(json["time"]);
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddMilliseconds(time);
                info.time = dt.ToString("yyyy-MM-dd HH:mm:ss");
                jsonData = JsonConvert.SerializeObject(info);
            }
            catch (Exception ex)
            {
                Console.WriteLine("json解析失败：" + ex.Message);
                Trace.WriteLine("json转换数据失败！" + ex.Message + Environment.NewLine, "JsonStatus");
            }
            return jsonData;
        }
    }
}

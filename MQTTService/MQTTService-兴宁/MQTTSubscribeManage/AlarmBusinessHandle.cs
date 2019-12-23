using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTSubscribeManage
{
    public class AlarmBusinessHandle
    {
        public string AnalysisTopic(string topic, byte[] bytes)
        {
            //工具类
            ToolHelper tl = new ToolHelper();
            //Dictionary<int, string> dc = new Dictionary<int, string>();
            string json = "";
            //行为分析盒子报警信息处理
            AlarmInfoHandle handle = new AlarmInfoHandle();
            if (topic == "Device/GuangXian")
            {
                json = tl.CondingHelp(bytes, 2);
                JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                //增加处置ID
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
                var AreaID = Convert.ToInt32(jsonObj["AreaID"]);
                var AlarmID = "";
                jsonObj.Add("AlarmID", AlarmID);
                json = jsonObj.ToString();
                //dc.Add(0,json);
                return json;
            }
            else if (topic == "Device/ShaoWeiAlarm")
            {
                json = tl.CondingHelp(bytes, 2);
                JObject jsonObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
                string businessID = "";
                if (businessID == "")
                {

                }
                json = jsonObj.ToString();
                //dc.Add(0, json);
                return json;
            }
            else if (topic == "Device/VideoAnalysis/YFT")
            {
                json = tl.CondingHelp(bytes, 2);
                json = handle.ParsingActionJson(json);
                JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
                json = jsonObj.ToString();
                //dc.Add(0, json);
                return json;
            }
            else if (topic == "Device/RenLian/YFT")
            {
                json = tl.CondingHelp(bytes, 2);
                json = handle.ParsingFaceJson(json);
                if (json != "")
                {
                    JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                    string ts = Guid.NewGuid().ToString();
                    jsonObj.Add("Guid", ts);
                    json = jsonObj.ToString();
                }
                //dc.Add(0, json);    
                return json;
            }
            else if (topic == "Device/CheLiang/YFT")
            {
                json = tl.CondingHelp(bytes, 2);
                json = handle.ParsingTeZhenJson(json);
                JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
               
                json = jsonObj.ToString();
                
                //dc.Add(0, json);
                return json;
            }
            else if (topic == "Device/ShaoWeiBox")
            {
                return "";
            }
            else if (topic == "Device/ShaoWeiZhiWen")
            {

            }
            else if (topic == "Device/RenLian/HK")
            {
                return "";
            }
            else if (topic == "Device/VideoAnalysis/HK")
            {
                json = tl.CondingHelp(bytes, 2);
                JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                //增加处置ID
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
               
                try
                {
                    string[] arr = tl.GetImgIp();
                    string url = arr[0];
                    string port = arr[1];
                    jsonObj["ImageUrl"]= string.Format("http://{0}:{1}/{2}", url, port, jsonObj["ImageUrl"].ToString());
                    json = jsonObj.ToString();
                }
                catch (Exception ex)
                {
                    json = "";
                }
                //dc.Add(0,json);
                return json;
            }
            else if (topic == "Device/CheLiang/HK")
            {
                json = tl.CondingHelp(bytes, 2);
                JObject jsonObj = (JObject)JsonConvert.DeserializeObject(json);
                //增加处置ID
                string ts = Guid.NewGuid().ToString();
                jsonObj.Add("Guid", ts);
                json = jsonObj.ToString();
                //dc.Add(0,json);
                try
                {
                    string[] arr = tl.GetImgIp();
                    string url = arr[0];
                    string port = arr[1];
                    jsonObj["ImageUrl"] = string.Format("http://{0}:{1}/{2}", url, port, jsonObj["ImageUrl"].ToString());
                    json = jsonObj.ToString();
                }
                catch (Exception ex)
                {
                    json = "";
                }
                return json;
            }

            return json;
        }

        public async Task<object> Data(string id)
        {
            APIHelper api = new APIHelper();
            return await api.GetData("api/d_video_base/" + id);
        }
    }
}

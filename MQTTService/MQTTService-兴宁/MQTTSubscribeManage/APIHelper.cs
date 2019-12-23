using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MQTTSubscribeManage
{
    public class APIHelper
    {
        HttpClient client = new HttpClient();
        private string baseUrl = ConfigurationManager.AppSettings["url"];

        //post
        public async Task<bool> InsertTable(string json, string topic)
        {
            //基本的API URL
            client.BaseAddress = new Uri(baseUrl);
            //默认希望响应使用Json序列化(内容协商机制，我接受json格式的数据)
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            object obj = JsonConvert.DeserializeObject<object>(json);
            string api = "api/d_alarm_info/" + topic.Replace("/", "").Trim();
            var result = false;
            try
            {
                result = await client.PostAsJsonAsync(api, obj)
                           //返回请求是否执行成功，即HTTP Code是否为2XX
                           .ContinueWith(x => x.Result.IsSuccessStatusCode);
                if (result)
                {
                    Console.WriteLine("主题" + topic + "数据入库成功！");
                }
                else
                {
                    Console.WriteLine("主题" + topic + "数据入库失败！");
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"主题{topic}数据入库失败{ex.InnerException}{Environment.NewLine}");
                Trace.WriteLine($"主题{topic}数据入库失败{ex.InnerException}{Environment.NewLine}", "APIConnectStatus");
            }

            return result;
        }
        //get
        public async Task<object> GetData(string route)
        {
            //基本的API URL
            client.BaseAddress = new Uri(baseUrl);
            //默认希望响应使用Json序列化(内容协商机制，我接受json格式的数据)
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data =new object();
            try
            {
                data = await await client.GetAsync(route)
                                    //获取返回Body，并根据返回的Content-Type自动匹配格式化器反序列化Body内容为对象
                                    .ContinueWith(x => x.Result.Content.ReadAsAsync<object>(
                   new List<MediaTypeFormatter>() {new JsonMediaTypeFormatter()/*这是Json的格式化器*/
                                                    ,new XmlMediaTypeFormatter()/*这是XML的格式化器*/}));
                Console.WriteLine($"接口{route}访问数据成功{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"接口{route}访问数据失败{ex.InnerException}{Environment.NewLine}");
                Trace.WriteLine($"接口{route}访问数据失败{ex.InnerException}{Environment.NewLine}", "APIConnectStatus");
            }
            //向Person发送GET请求
            return data;
        }


    }
}

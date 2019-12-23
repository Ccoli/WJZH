using MQTTClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MQTTSubscribeManage
{
    class Program
    {
        static void Main(string[] args)
        {
            MQTTClientModule mqttclient = new MQTTClientModule();
            try
            {
                //string topic = ConfigurationManager.AppSettings["topic"];
                //var topicArr = topic.Split('|');
               
                Task.Run(async () => {
                    await mqttclient.ConnectMqttServerAsync();
                    //for (int i = 0; i < topicArr.Length; i++)
                    //{
                    //    await mqttclient.Subscribe(topicArr[i]);
                    //}
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine("测试问题：" + ex.Message);
                Trace.WriteLine("测试问题：" + ex.Message);
            }
           
            Console.WriteLine("输入exit退出！");
            while (true)
            {
                if (Console.ReadLine().ToLower() == "exit")
                {
                    return;
                }
            }
        }
    }
}

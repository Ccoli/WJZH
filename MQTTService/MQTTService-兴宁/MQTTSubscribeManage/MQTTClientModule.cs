using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using MQTTSubscribeManage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;

namespace MQTTClient
{
    public class MQTTClientModule
    {
        public IMqttClient mqttClient = null;
        private bool isReconnect = true;


        private string ip = ConfigurationManager.AppSettings["ip"];
        private string port = ConfigurationManager.AppSettings["port"];
        private string clientId = Guid.NewGuid().ToString("D");

        /// <summary>
        /// 发布主题信息
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task Publish(string topic, string json)
        {
            if (string.IsNullOrEmpty(topic))
            {
                Console.Write("发布主题不能为空！");
                return;
            }
            //2.4.0版本的
            //var appMsg = new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(inputString), MqttQualityOfServiceLevel.AtMostOnce, false);
            //mqttClient.PublishAsync(appMsg);

            ///qos=0，WithAtMostOnceQoS,消息的分发依赖于底层网络的能力。
            ///接收者不会发送响应，发送者也不会重试。消息可能送达一次也可能根本没送达。
            ///感觉类似udp
            ///QoS 1: 至少分发一次。服务质量确保消息至少送达一次。
            ///QoS 2: 仅分发一次
            ///这是最高等级的服务质量，消息丢失和重复都是不可接受的。使用这个服务质量等级会有额外的开销。
            ///
            ///例如，想要收集电表读数的用户可能会决定使用QoS 1等级的消息，
            ///因为他们不能接受数据在网络传输途中丢失
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(json)
                .WithAtMostOnceQoS()
                .WithRetainFlag(false)
                .Build();

            await mqttClient.PublishAsync(message);
        }

        public async Task Subscribe(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                Console.WriteLine("订阅主题不能为空！");
                return;
            }

            if (!mqttClient.IsConnected)
            {
                Console.WriteLine("MQTT客户端尚未连接！");
                return;
            }

            // Subscribe to a topic
            await mqttClient.SubscribeAsync(new TopicFilterBuilder()
                .WithTopic(topic)
                .WithAtMostOnceQoS()
                .Build()
                );

            //2.4.0
            //await mqttClient.SubscribeAsync(new List<TopicFilter> {
            //    new TopicFilter(topic, MqttQualityOfServiceLevel.AtMostOnce)
            //});
            Console.WriteLine($"已订阅[{topic}]主题{Environment.NewLine}");

            //txtSubTopic.Enabled = false;
            //btnSubscribe.Enabled = false;
        }

        public async Task ConnectMqttServerAsync()
        {
            // Create a new MQTT client.
            if (mqttClient == null)
            {
                var factory = new MqttFactory();
                isReconnect = true;
                mqttClient = factory.CreateMqttClient();

                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;
            }

            //非托管客户端
            try
            {
                ////Create TCP based options using the builder.
                //var options1 = new MqttClientOptionsBuilder()
                //    .WithClientId("client001")
                //    .WithTcpServer("192.168.88.3")
                //    .WithCredentials("bud", "%spencer%")
                //    .WithTls()
                //    .WithCleanSession()
                //    .Build();

                //// Use TCP connection.
                //var options2 = new MqttClientOptionsBuilder()
                //    .WithTcpServer("192.168.88.3", 8222) // Port is optional
                //    .Build();

                //// Use secure TCP connection.
                //var options3 = new MqttClientOptionsBuilder()
                //    .WithTcpServer("192.168.88.3")
                //    .WithTls()
                //    .Build();

                //Create TCP based options using the builder.
                var options = new MqttClientOptionsBuilder()
                    .WithClientId(clientId)
                    .WithTcpServer(ip, Convert.ToInt32(port))

                    //.WithTls()//服务器端没有启用加密协议，这里用tls的会提示协议异常
                    .WithCleanSession()
                    .Build();

                //// For .NET Framwork & netstandard apps:
                //MqttTcpChannel.CustomCertificateValidationCallback = (x509Certificate, x509Chain, sslPolicyErrors, mqttClientTcpOptions) =>
                //{
                //    if (mqttClientTcpOptions.Server == "server_with_revoked_cert")
                //    {
                //        return true;
                //    }

                //    return false;
                //};

                //2.4.0版本的
                //var options0 = new MqttClientTcpOptions
                //{
                //    Server = "127.0.0.1",
                //    ClientId = Guid.NewGuid().ToString().Substring(0, 5),
                //    UserName = "u001",
                //    Password = "p001",
                //    CleanSession = true
                //};

                await mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
                Trace.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine, "MqttConnectStatus");
            }

            //托管客户端
            try
            {
                //// Setup and start a managed MQTT client.
                //var options = new ManagedMqttClientOptionsBuilder()
                //    .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                //    .WithClientOptions(new MqttClientOptionsBuilder()
                //        .WithClientId("Client_managed")
                //        .WithTcpServer("192.168.88.3", 8223)
                //        .WithTls()
                //        .Build())
                //    .Build();

                //var mqttClient = new MqttFactory().CreateManagedMqttClient();
                //await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("my/topic").Build());
                //await mqttClient.StartAsync(options);
            }
            catch (Exception)
            {

            }
        }

        public async Task<object> Data()
        {
            APIHelper api = new APIHelper();
            return await api.GetData("api/d_alarm_source/getname");
        }


        public Dictionary<string, bool> dcr = new Dictionary<string, bool>();
        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            //获取主题
            string topic = e.ApplicationMessage.Topic;

            if (topic == "ClientWeb/Alarm/Status")
            {
                dcr = new Dictionary<string, bool>();
                string data = Data().GetAwaiter().GetResult().ToString();
                JObject jobj = (JObject)JsonConvert.DeserializeObject(data);
                var obj = jobj["data"];

                foreach (var item in obj)
                {
                    var name = item["TopicName"].ToString();
                    var enabled = Convert.ToBoolean(item["Enabled"]);
                    dcr.Add(name, enabled);
                }
                return;
            }
            try
            {
                var flag = dcr[topic];
                if (!flag)
                {
                    //Console.WriteLine($"{topic},{dcr[topic]}");
                    return;
                }
            }
            catch (Exception ex)
            {

            }


            APIHelper ah = new APIHelper();
            AlarmBusinessHandle abh = new AlarmBusinessHandle();
            string json = abh.AnalysisTopic(topic, e.ApplicationMessage.Payload);
            if (json != "")
            {
                Task.Run(async () =>
                {
                    var result = ah.InsertTable(json, topic);
                    if (await result)
                    {
                        await Publish("Server/" + topic, json);
                    }
                });
            }
        }

        private void MqttClient_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("已连接到MQTT服务器！" + Environment.NewLine);
            Trace.WriteLine("已连接到MQTT服务器！" + Environment.NewLine, "MqttConnectStatus");
            string topic = ConfigurationManager.AppSettings["topic"];
            var topicArr = topic.Split('|');
            Task.Run(async () =>
            {
                for (int i = 0; i < topicArr.Length; i++)
                {
                    await Subscribe(topicArr[i]);
                }
                await Publish("CleintWeb/Alarm/Status", "123");
            });
        }
        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            DateTime curTime = new DateTime();
            curTime = DateTime.UtcNow;
            Console.WriteLine($">> [{curTime.ToLongTimeString()}]");
            Console.WriteLine("已断开MQTT连接！" + Environment.NewLine);
            Trace.WriteLine("已断开MQTT连接！" + Environment.NewLine, "MqttConnectStatus");


            //Reconnecting
            if (isReconnect)
            {
                Console.WriteLine("正在尝试重新连接" + Environment.NewLine);

                var options = new MqttClientOptionsBuilder()
                    .WithClientId(clientId)
                    .WithTcpServer(ip, Convert.ToInt32(port))
                    //.WithTls()
                    .WithCleanSession()
                    .Build();

                Task.Delay(TimeSpan.FromSeconds(5));
                try
                {
                    mqttClient.ConnectAsync(options);
                }
                catch
                {
                    Console.WriteLine("### RECONNECTING FAILED ###" + Environment.NewLine);
                }

            }
            else
            {

                Console.WriteLine("已下线！" + Environment.NewLine);

            }
        }
    }
}

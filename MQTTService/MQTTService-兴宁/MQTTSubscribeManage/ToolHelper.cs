using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MQTTSubscribeManage
{
    public class ToolHelper
    {
        public string CondingHelp(byte[] data,int type)
        {
            if (type==0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                return sb.ToString().ToUpper();
                //Console.WriteLine("HEX解码结果："+ sb.ToString().ToUpper());
            }
            else if (type == 1)
            {
                return new ASCIIEncoding().GetString(data);
                //Console.WriteLine("ASCII解码结果：" + new ASCIIEncoding().GetString(data));
            }
            else if (type == 2)
            {
                return new UTF8Encoding().GetString(data);
                //Console.WriteLine("UTF8解码结果：" + new UTF8Encoding().GetString(data));
            }
            else if (type == 3)
            {
                return new UnicodeEncoding().GetString(data);
                //Console.WriteLine("Unicode解码结果：" + new UnicodeEncoding().GetString(data));
            }
            else if (type == 4)
            {
                Encoding utf8;
                Encoding gb2312;
                utf8 = Encoding.GetEncoding("UTF-8");
                gb2312 = Encoding.GetEncoding("GB2312");
                byte[] gb = Encoding.Convert(gb2312, utf8, data);
                //Console.WriteLine("UTF8解码结果：" + utf8.GetString(gb));
                return utf8.GetString(gb);
            }
            else
            {
                return "";
            }
        }

        public string[] GetImgIp()
        {
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
            string[] arr = new string[2];
            arr[0] = url;
            arr[1] = port;
            return arr;
        }
    }
}

using MQTTClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTFencePublish
{
    class Program
    {
        static void Main(string[] args)
        {
            FenceSerialPort fsp = new FenceSerialPort();
            fsp.OpenSerial();
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

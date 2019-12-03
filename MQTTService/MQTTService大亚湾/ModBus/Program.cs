using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using MyUtil.log;

namespace ModBus
{
    class Program
    {
        public static MyUtil.log.Log logger = LogFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            byte[] bytes = new byte[4];
            bytes[0] = 223;
            bytes[1] = 25;
            bytes[2] = 172;
            bytes[3] = 64;
            double fa = BitConverter.ToSingle(bytes, 0);
            double fa2 = Math.Round(fa, 3, MidpointRounding.AwayFromZero);
            RecivedConfigurationTable r = new RecivedConfigurationTable();
            ComSetting c = new ComSetting();
            c.BaudRate = 9600;
            c.PortName = global.COM;
            c.Parity = Parity.Even;
            c.DataBits = Convert.ToInt32("8");
            c.StopBits = StopBits.One;

            RecivedData ia = new RecivedData();
            ia.Address = 00;
            ia.ExactNum = 35;
            List<RecivedData> a = new List<RecivedData>();
            a.Add(ia);

            ArrayList al = new ArrayList(a);
            r.DataList = al;
            r.ComSetting = c;
            r.SlaveID = 01;
            ModbusController s = new ModbusController(r);
            s.Start();
           
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

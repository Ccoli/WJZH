using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTClient
{
    public class AlamrEntity
    {
        public string topic { get; set; }
        public string deviceName { get; set; }
        public string alarmNum { get; set; }
        public string alarmName { get; set; }
        public string alarmType { get; set; }
        public string alarmTime { get; set; }
    }
}

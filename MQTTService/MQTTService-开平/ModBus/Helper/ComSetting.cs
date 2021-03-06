﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModBus
{
   public class ComSetting
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public System.IO.Ports.Parity Parity { get; set; }

        public System.IO.Ports.StopBits StopBits { get; set; }
    }
}

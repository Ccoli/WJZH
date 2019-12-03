using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModBus
{
  public  class RecivedConfigurationTable
    {
        public ArrayList DataList { get; set; }

        public ComSetting ComSetting { get; set; }

        public byte SlaveID { get; set; }
    }
}

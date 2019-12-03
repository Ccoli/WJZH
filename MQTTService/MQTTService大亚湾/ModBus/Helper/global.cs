using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBus
{
    class global
    {
        public static string sqlserver = System.Configuration.ConfigurationManager.AppSettings["sqlserver"];
        public static string COM = System.Configuration.ConfigurationManager.AppSettings["COM"];
        public static int CycleTime =int.Parse( System.Configuration.ConfigurationManager.AppSettings["cycletime"]);
    }
}

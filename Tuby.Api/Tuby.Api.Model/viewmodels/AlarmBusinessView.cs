using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuby.Api.Model;

namespace Tuby.Api.Model
{
    public class AlarmBusinessView : d_alarm_business
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SourceName { get; set; }
    }
}

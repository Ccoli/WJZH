using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model
{
    public class d_alarm_source
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }


        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 主题名称
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        
    }
}

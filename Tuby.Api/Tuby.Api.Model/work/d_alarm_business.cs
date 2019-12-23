using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model
{
    public class d_alarm_business
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 报警名称
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 报警来源id
        /// </summary>
        public int BySouceID { get; set; }

        /// <summary>
        /// 视频id
        /// </summary>
        public int VideoID { get; set; }

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

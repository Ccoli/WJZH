using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class HandAlarm
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
       /// <summary>
       /// x
       /// </summary>
        public string X { get; set; }
        /// <summary>
        /// y
        /// </summary>
        public string Y { get; set; }
        /// <summary>
        /// z
        /// </summary>
        public string Z { get; set; }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>

        public string alarm { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

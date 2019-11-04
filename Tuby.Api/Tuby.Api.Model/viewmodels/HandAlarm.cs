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
        public int ID { get; set; }
       /// <summary>
       /// x
       /// </summary>
        public double X { get; set; }
        /// <summary>
        /// y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// z
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// 报警内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>

        public string alarm { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime time { get; set; }
    }
}

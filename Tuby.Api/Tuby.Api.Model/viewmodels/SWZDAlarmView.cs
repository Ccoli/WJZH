using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    /// <summary>
    /// {"AlarmSourceID":14196190450402000896,"AlarmType":"自然灾害","Description":"一号哨发生自然灾害","DevIP":"182.167.10.110","OccurTime":"2019-12-07 16:49:26"}
    /// </summary>
    public class SWZDAlarmView 
    {
        /// <summary>
        /// 报警ID
        /// </summary>
        public string AlarmSourceID { get; set; }

        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设备ip
        /// </summary>
        public string DevIP { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime OccurTime { get; set; }

        /// <summary>
        /// 关联处置id
        /// </summary>
        public string StatusID { get; set; }
    }
}

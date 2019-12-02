using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class AlarmInfoView: d_alarm_info
    {
        /// <summary>
        /// 报警名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 报警描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 报警等级ID
        /// </summary>
        public int AlarmLevelID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 报警设备报警登记
        /// </summary>
        public int AlarmDeviceTypeID { get; set; }

        /// <summary>
        /// 报警等级名称
        /// </summary>
        public string LevelName { get; set; }

        /// <summary>
        /// 报警等级描述
        /// </summary>
        public string LevelDescription { get; set; }

        /// <summary>
        /// 输入时间
        /// </summary>
        public DateTime Entrytime { get; set; }

    }
}

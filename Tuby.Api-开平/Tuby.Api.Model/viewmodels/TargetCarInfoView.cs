using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class TargetCarInfoView
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 车名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarID { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        public int SecurityLevelID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RecStatus { get; set; }
        /// <summary>
        /// 是否黑名单
        /// </summary>
        public bool IsBlack { get; set; }

        /// <summary>
        /// 是否白名单
        /// </summary>
        public bool IsWhite { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class SoldierInfoView:d_soldier
    {

        /// <summary>
        /// 警衔
        /// </summary>
        public string RankName { get; set; }


        /// <summary>
        /// 职务
        /// </summary>
        public string PostName { get; set; }


        /// <summary>
        /// 健康状况
        /// </summary>
        public string HealthName { get; set; }


        /// <summary>
        /// 在位状态
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        public string MarialName { get; set; }

        /// <summary>
        /// 教育程度
        /// </summary>
        public string EducationName { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string PoloticName { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NationName { get; set; }
    }
}

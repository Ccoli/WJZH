using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class SoldierInfoView
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 军人证号
        /// </summary>
        public string SoldierID { get; set; }

        /// <summary>
        /// 入伍日期
        /// </summary>
        public string InductedDay { get; set; }

        /// <summary>
        /// 退伍日期
        /// </summary>
        public string LeaveDay { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace { get; set; }

        /// <summary>
        /// 警衔
        /// </summary>
        public int PoliceRankID { get; set; }

        /// <summary>
        /// 警衔
        /// </summary>
        public string RankName { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public int HealthID { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public string HealthName { get; set; }

        /// <summary>
        /// 在位状态
        /// </summary>
        public int SoilderStateID { get; set; }

        /// <summary>
        /// 在位状态
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 记录状态
        /// </summary>
        public int RecStatus { get; set; }

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
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
    }
}

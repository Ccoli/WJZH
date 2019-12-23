//-----------------------------------------------------------------------
// <copyright file=" d_target_people_control.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_target_people_control.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_target_people_control Entity Model
    /// </summary>   
    [Serializable]
    public class d_target_people_control
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 人员
        /// </summary>
        public int TargetPeopleID { get; set; }
   
        /// <summary>
        /// 进出事由
        /// </summary>
        public string Reason { get; set; }
   
        /// <summary>
        /// 进出时间
        /// </summary>
        public DateTime Time { get; set; }
   
        /// <summary>
        /// 批准人
        /// </summary>
        public string AuthorizeMan { get; set; }
   
        /// <summary>
        /// 登记人
        /// </summary>
        public string RecordMan { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int RecStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

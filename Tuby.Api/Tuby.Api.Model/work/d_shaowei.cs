//-----------------------------------------------------------------------
// <copyright file=" d_shaowei.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_shaowei.cs
// * history : Created by T4 06/26/2019 18:47:56
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_shaowei Entity Model
    /// </summary>   
    [Serializable]
    public class d_shaowei
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 哨位名
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 执勤单位
        /// </summary>
        public int DepartmentID { get; set; }
   
        /// <summary>
        /// 哨位类型
        /// </summary>
        public int ShaoweiTypeID { get; set; }
   
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
   
        /// <summary>
        /// 上勤时间
        /// </summary>
        public DateTime StartTime { get; set; }
   
        /// <summary>
        /// 撤勤时间
        /// </summary>
        public DateTime LeaveTime { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int RecStatus { get; set; }
    }
}

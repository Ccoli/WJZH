//-----------------------------------------------------------------------
// <copyright file=" d_pap_camera_record_car.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_pap_camera_record_car.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_pap_camera_record_car Entity Model
    /// </summary>   
    [Serializable]
    public class d_pap_camera_record_car
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 车辆
        /// </summary>
        public int CarID { get; set; }
   
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime RecTime { get; set; }
   
        /// <summary>
        /// 抓拍照片
        /// </summary>
        public string ImagePath { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int RecStatus { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}

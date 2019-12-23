//-----------------------------------------------------------------------
// <copyright file=" d_camera.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_camera.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_camera Entity Model
    /// </summary>   
    [Serializable]
    public class d_camera
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }
   
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
   
        /// <summary>
        /// 高度
        /// </summary>
        public double Altitude { get; set; }
   
        /// <summary>
        /// 摄像机类型
        /// </summary>
        public int CameraTypeID { get; set; }
   
        /// <summary>
        /// ip地址
        /// </summary>
        public string IPAddress { get; set; }
   
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
   
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int RecStatus { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

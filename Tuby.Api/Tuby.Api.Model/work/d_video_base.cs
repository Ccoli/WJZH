//-----------------------------------------------------------------------
// <copyright file=" a_data_access.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: a_data_access.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// a_data_access Entity Model
    /// </summary>   
    [Serializable]
    public class d_video_base
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CameraID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Channel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int VideoTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPTZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MainStream { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SubStream { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Coordinate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ViewPoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Geographic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string X { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Z { get; set; }
    }
}
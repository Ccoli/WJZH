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
    public class d_video_struct
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int PID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsVideo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

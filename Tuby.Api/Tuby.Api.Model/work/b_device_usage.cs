//-----------------------------------------------------------------------
// <copyright file=" b_device_usage.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: b_device_usage.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// b_device_usage Entity Model
    /// </summary>   
    [Serializable]
    public class b_device_usage
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
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

//-----------------------------------------------------------------------
// <copyright file=" b_education_level.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: b_education_level.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// b_education_level Entity Model
    /// </summary>   
    [Serializable]
    public class b_education_level
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string EducationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

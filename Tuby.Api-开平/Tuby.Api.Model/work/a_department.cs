//-----------------------------------------------------------------------
// <copyright file=" a_department.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: a_department.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// a_department Entity Model
    /// </summary>   
    [Serializable]
    public class a_department
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int Order { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentTypeID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public int ParentID { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
   
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

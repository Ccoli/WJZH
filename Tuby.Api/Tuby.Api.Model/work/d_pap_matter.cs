//-----------------------------------------------------------------------
// <copyright file=" d_pap_matter.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_pap_matter.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_pap_matter Entity Model
    /// </summary>   
    [Serializable]
    public class d_pap_matter
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 事件内容
        /// </summary>
        public string Content { get; set; }
   
        /// <summary>
        /// 离队时间
        /// </summary>
        public DateTime RecTime { get; set; }
   
        /// <summary>
        /// 审核人
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

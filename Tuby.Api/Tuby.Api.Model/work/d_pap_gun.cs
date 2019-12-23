//-----------------------------------------------------------------------
// <copyright file=" d_pap_gun.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_pap_gun.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_pap_gun Entity Model
    /// </summary>   
    [Serializable]
    public class d_pap_gun
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 枪名
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 照片
        /// </summary>
        public string ImagePath { get; set; }
   
        /// <summary>
        /// 类型
        /// </summary>
        public int GunTypeID { get; set; }
   
        /// <summary>
        /// 持有人
        /// </summary>
        public int SoldierID { get; set; }
   
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

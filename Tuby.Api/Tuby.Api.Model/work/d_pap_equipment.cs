//-----------------------------------------------------------------------
// <copyright file=" d_pap_equipment.cs" company="xxxx Enterprises">
// * Copyright (C) 2019 xxxx Enterprises All Rights Reserved
// * version : 4.0.30319.42000
// * author  : auto generated by T4
// * FileName: d_pap_equipment.cs
// * history : Created by T4 07/04/2019 10:24:10
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_pap_equipment Entity Model
    /// </summary>   
    [Serializable]
    public class d_pap_equipment
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
   
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
   
        /// <summary>
        /// 装备编号
        /// </summary>
        public string EquipmentID { get; set; }
   
        /// <summary>
        /// 装备类型
        /// </summary>
        public int EquipmentTypeID { get; set; }
   
        /// <summary>
        /// 状态
        /// </summary>
        public int EquipmentStatusID { get; set; }
   
        /// <summary>
        /// 照片
        /// </summary>
        public string ImagePath { get; set; }
   
        /// <summary>
        /// 入编时间
        /// </summary>
        public DateTime JoinTime { get; set; }
   
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

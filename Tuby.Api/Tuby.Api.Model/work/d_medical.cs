using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model
{
    /// <summary>
    ///d_medical Entity Model
    /// </summary>   
    [Serializable]
    public class d_medical
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 士兵id
        /// </summary>
        public int SoldierID { get; set; }

        /// <summary>
        /// 就诊内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 就诊地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 就诊时间
        /// </summary>
        public DateTime Time { get; set; }
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

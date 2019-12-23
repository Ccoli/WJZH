using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_handle_info Entity Model
    /// </summary>   
    [Serializable]
    public class d_handle_info
    {
        /// <summary>
        /// 处置人员
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 处置内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 处置结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
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

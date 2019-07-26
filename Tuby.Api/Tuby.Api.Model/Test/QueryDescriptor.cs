using System;
using System.Collections.Generic;
using System.Text;

#region << 版 本 注 释 >>
/*---------------------------------------------------------------- 
* 类 名 称 ：QueryDescriptor
* 类 描 述 ：    
* 作    者 ：xnlzg
* 创建时间 ：2018/11/7 14:15:04
* 更新时间 ：2018/11/7 14:15:04
* 说    明 ：
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ xnlzg 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Collections.Generic;

namespace XN.Common
{
    /// <summary>
    /// 查询集合
    /// </summary>
    public class QueryDescriptor
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public List<OrderByClause> OrderBys { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public List<QueryCondition> Conditions { get; set; }
    }
}


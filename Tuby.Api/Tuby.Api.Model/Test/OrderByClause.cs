
#region << 版 本 注 释 >>
/*---------------------------------------------------------------- 
* 类 名 称 ：OrderByClause
* 类 描 述 ：    
* 作    者 ：xnlzg
* 创建时间 ：2018/11/7 14:12:53
* 更新时间 ：2018/11/7 14:12:53
* 说    明 ：
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ xnlzg 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

namespace XN.Common
{
    /// <summary>
    /// 排序实体
    /// </summary>
    public class OrderByClause
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public OrderSequence Order { get; set; }
    }
}


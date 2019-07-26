

#region << 版 本 注 释 >>
/*---------------------------------------------------------------- 
* 类 名 称 ：QueryCondition
* 类 描 述 ：    
* 作    者 ：xnlzg
* 创建时间 ：2018/11/7 14:14:29
* 更新时间 ：2018/11/7 14:14:29
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
    /// 查询
    /// </summary>
    public class QueryCondition
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 查询操作
        /// </summary>
        public QueryOperator Operator { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

    }
}


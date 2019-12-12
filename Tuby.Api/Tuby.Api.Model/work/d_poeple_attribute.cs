using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_poeple_attribute Entity Model
    /// </summary>   
    [Serializable]
    public class d_poeple_attribute
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 是否抱小孩
        /// </summary>
        public string Baby { get; set; }
        /// <summary>
        /// 是否背包
        /// </summary>
        public string Bag { get; set; }
        /// <summary>
        /// 下装颜色
        /// </summary>
        public string BottomColor { get; set; }
        /// <summary>
        /// 下装款式
        /// </summary>
        public string BottomType { get; set; }
        /// <summary>
        /// 是否戴眼镜
        /// </summary>
        public string Glasses { get; set; }
        /// <summary>
        /// 双肩包
        /// </summary>
        public string Hat { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Knapsack { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Orientation { get; set; }
        /// <summary>
        /// 单肩包
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 是否抱小孩
        /// </summary>
        public string ShoulderBag { get; set; }
        /// <summary>
        /// 上装颜色
        /// </summary>
        public string UpperColor { get; set; }
        /// <summary>
        /// 上装款式
        /// </summary>
        public string UpperType { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string Type { get; set; }
    }
}

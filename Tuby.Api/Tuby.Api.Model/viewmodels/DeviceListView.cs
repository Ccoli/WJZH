using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    /// <summary>
    /// 设备管理列表
    /// </summary>
    public class DeviceListView
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 通道
        /// </summary>
        public string channel { get;set; }
        /// <summary>
        /// 时间长度
        /// </summary>
        public int timeLine { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool isParent { get; set; }
    }
}

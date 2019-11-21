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
        /// 视频地址
        /// </summary>
        public string videoaddress { get; set; }
        /// <summary>
        /// 主码流
        /// </summary>
        public  string mainstream { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool isParent { get; set; }
        /// <summary>
        /// 子码流
        /// </summary>
        public string substream { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public string coordinate { get; set; }
        /// <summary>
        /// 最佳视角
        /// </summary>
        public string view { get; set; }
        /// <summary>
        /// 是否使用播放地址
        /// </summary>
        public bool isAddress { get; set; }
        /// <summary>
        /// 账户id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string DeviceID { get; set; }
    }
}

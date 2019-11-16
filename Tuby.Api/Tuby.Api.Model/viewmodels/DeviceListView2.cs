using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    /// <summary>
    /// 设备管理列表
    /// </summary>
    public class DeviceListView2:DeviceListView
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 厂家（海康，大华）
        /// </summary>
        public string DeviceFrom { get; set; }
    }
}

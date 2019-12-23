using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tuby.Api.Model
{
   /// <summary>
   /// 摄像头账户信息
   /// </summary>
    public class b_device_account
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
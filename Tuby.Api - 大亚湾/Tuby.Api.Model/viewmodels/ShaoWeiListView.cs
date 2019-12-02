using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class ShaoWeiListView:d_shaowei
    {
        /// <summary>
        /// 哨位类型
        /// </summary>
        public string ShaoWeiTypeName { get; set; }
        /// <summary>
        /// 执勤单位
        /// </summary>
        public string DepartmentName { get; set; }
    }
}

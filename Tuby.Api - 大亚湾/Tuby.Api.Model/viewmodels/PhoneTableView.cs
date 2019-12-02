using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class PhoneTableView:d_phone_table
    {
        /// <summary>
        /// 电话本类型
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}

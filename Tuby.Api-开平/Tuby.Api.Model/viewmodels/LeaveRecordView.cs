using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class LeaveRecordView:d_soldier_leave
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 离队原因
        /// </summary>
        public string LeaveName { get; set; }
    }
}

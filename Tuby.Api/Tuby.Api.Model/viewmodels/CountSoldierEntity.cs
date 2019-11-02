using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class CountSoldierEntity
    {
        /// <summary>
        /// 在位统计
        /// </summary>
        public int StateCount { get; set; }
        /// <summary>
        /// 离位统计
        /// </summary>
        public int LeaveCount { get; set; }
        /// <summary>
        /// 借调统计
        /// </summary>
        public int ToLoanCount { get; set; }
        /// <summary>
        /// 培训统计
        /// </summary>
        public int TrainCount { get; set; }
    }
}

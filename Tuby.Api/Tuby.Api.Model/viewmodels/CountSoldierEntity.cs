using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    /// <summary>
    /// 士兵统计
    /// </summary>
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
        ///  借调统计
        /// </summary>
        public int ToLoanCount { get; set; }

        /// <summary>
        /// 培训统计
        /// </summary>
        public int TrainCount { get; set; }

        /// <summary>
        /// 休假统计
        /// </summary>
        public int VacationCount { get; set; }
 
        /// <summary>
        /// 集训统计
        /// </summary>
        public int AllTrainCount { get; set; }

    }
}

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
        /// 六中队在位统计
        /// </summary>
        public int SixStateCount { get; set; }
        /// <summary>
        /// 七中队在位统计
        /// </summary>
        public int SevenStateCount { get; set; }
        /// <summary>
        /// 离位统计
        /// </summary>
        public int LeaveCount { get; set; }
        /// <summary>
        /// 六中队离位统计
        /// </summary>
        public int SixLeaveCount { get; set; }
        /// <summary>
        /// 七中队离位统计
        /// </summary>
        public int SevenLeaveCount { get; set; }
        /// <summary>
        ///  借调统计
        /// </summary>
        public int ToLoanCount { get; set; }
        /// <summary>
        /// 六中队借调统计
        /// </summary>
        public int SixToLoanCount { get; set; }
        /// <summary>
        /// 七中队借调统计
        /// </summary>
        public int SevenToLoanCount { get; set; }
        /// <summary>
        /// 培训统计
        /// </summary>
        public int TrainCount { get; set; }
        /// <summary>
        /// 六中队培训统计
        /// </summary>
        public int SixTrainCount { get; set; }
        /// <summary>
        /// 七中队培训统计
        /// </summary>
        public int SevenTrainCount { get; set; }
        /// <summary>
        /// 休假统计
        /// </summary>
        public int VacationCount { get; set; }
        /// <summary>
        /// 六中队休假统计
        /// </summary>
        public int SixVacationCount { get; set; }
        /// <summary>
        /// 七中队休假统计
        /// </summary>
        public int SevenVacationCount { get; set; }
        /// <summary>
        /// 集训统计
        /// </summary>
        public int AllTrainCount { get; set; }
        /// <summary>
        /// 六中队集训统计
        /// </summary>
        public int SixAllTrainCount { get; set; }
        /// <summary>
        /// 七中队集训统计
        /// </summary>
        public int SevenAllTrainCount { get; set; }
    }
}

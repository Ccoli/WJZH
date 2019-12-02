using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class ShaoWeiTurnView:d_shaowei_turn
    {
        /// <summary>
        /// 哨位名
        /// </summary>
        public string ShaoWeiName { get; set; }

        /// <summary>
        /// 哨兵姓名
        /// </summary>
        public string Name { get; set; }
    }
}

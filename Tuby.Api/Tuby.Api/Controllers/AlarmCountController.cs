using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmCountController : ControllerBase
    {
        readonly Id_alarm_infoServices _d_alarm_infoServices;
        readonly IHandAlarmServices _HandAlarmServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AlarmCountController(Id_alarm_infoServices d_alarm_infoServices, IHandAlarmServices HandAlarmServices)
        {
            _d_alarm_infoServices = d_alarm_infoServices;
            _HandAlarmServices = HandAlarmServices;
        }
        /// <summary>
        /// 统计特定时间内报警次数
        /// </summary>
        /// <returns></returns>
        // GET: api/AlarmCount
        [HttpGet]
        public async Task<Dictionary<string, int>> Get()
        {
            List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
            DateTime dt = DateTime.Now;

            var jgList = await _d_alarm_infoServices.Query(a => a.AlarmTime > dt.AddDays(-1));
            var handList = await _HandAlarmServices.Query(a => Convert.ToDateTime(a.time) > dt.AddDays(-1));
            Dictionary<string, int> dc = new Dictionary<string, int>();
            dc.Add("dayjg", jgList.Count);
            dc.Add("dayhand", handList.Count);
            DateTime week =Convert.ToDateTime(dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).ToString("yyyy-MM-dd 00:00:00"));
            jgList = await _d_alarm_infoServices.Query(a => a.AlarmTime > week);
            handList = await _HandAlarmServices.Query(a => Convert.ToDateTime(a.time) >week);
            dc.Add("weekjg", jgList.Count);
            dc.Add("weekhand", handList.Count);
            DateTime month = dt.AddDays(1 - dt.Day);
            jgList = await _d_alarm_infoServices.Query(a => a.AlarmTime > month);
            handList = await _HandAlarmServices.Query(a => Convert.ToDateTime(a.time) > month);
            dc.Add("monthjg", jgList.Count);
            dc.Add("monthhand", handList.Count);
            return dc;
        }
    }
}

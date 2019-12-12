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
        readonly Id_target_camera_record_peopleServices _d_target_camera_record_peopleServices;
        readonly Id_car_attributeServices _d_car_attributeServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AlarmCountController(Id_alarm_infoServices d_alarm_infoServices, IHandAlarmServices HandAlarmServices, Id_target_camera_record_peopleServices d_target_camera_record_peopleServices, Id_car_attributeServices d_car_attributeServices)
        {
            _d_alarm_infoServices = d_alarm_infoServices;
            _HandAlarmServices = HandAlarmServices;
            _d_target_camera_record_peopleServices = d_target_camera_record_peopleServices;
            _d_car_attributeServices = d_car_attributeServices;
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
            var PeopleList = await _d_target_camera_record_peopleServices.Query(a => a.RecTime > dt.Date);
            var CarList = await _d_car_attributeServices.Query(a => a.Time >dt.Date);
            Dictionary<string, int> dc = new Dictionary<string, int>();
            dc.Add("dayPeople", PeopleList.Count);
            dc.Add("dayCar", CarList.Count);
            DateTime temp = new DateTime(dt.Year, dt.Month, dt.Day);
            int count = dt.DayOfWeek - DayOfWeek.Monday;
            if (count == -1) count = 6;
            temp.AddDays(-count);
            DateTime week =Convert.ToDateTime(temp.AddDays(-count).ToString("yyyy-MM-dd 00:00:00"));
            PeopleList = await _d_target_camera_record_peopleServices.Query(a => a.RecTime > week );
            CarList = await _d_car_attributeServices.Query(a => a.Time > week);
            dc.Add("weekPeople", PeopleList.Count);
            dc.Add("weekjg", CarList.Count);
            DateTime month = Convert.ToDateTime(dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd 00:00:00"));
            PeopleList = await _d_target_camera_record_peopleServices.Query(a => a.RecTime > month);
            CarList = await _d_car_attributeServices.Query(a => a.Time > month);
            dc.Add("monthzj", PeopleList.Count);
            dc.Add("monthjg", CarList.Count);
            return dc;
        }
    }
}

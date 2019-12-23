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
        //readonly Id_target_camera_record_peopleServices _d_target_camera_record_peopleServices;
        

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

        /// <summary>
        /// 统计特定时间内报警次数
        /// </summary>
        /// <returns></returns>
        // GET: api/AlarmCount
        [HttpGet]
        [Route("getalarm")]
        public async Task<Dictionary<string, int>> GetAlarmCount()
        {
            List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
            Dictionary<string, int> dc = new Dictionary<string, int>();
            DateTime dt = DateTime.Now;
            //当月
            DateTime month = Convert.ToDateTime(dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd 00:00:00"));
            var ZDGXList = await _d_alarm_infoServices.Query(a => a.AlarmTime > month&&a.AlarmTypeID==3);
            var VideoAlarmList = await _d_alarm_infoServices.Query(a => a.AlarmTime > month && (a.AlarmTypeID == 2|| a.AlarmTypeID == 15 || a.AlarmTypeID == 16 ));
            var FaceList = await _d_target_camera_record_peopleServices.Query(a => a.RecTime > month);
            var CarList = await _d_car_attributeServices.Query(a => a.Time > month);
            var ShaoWeiList = await _d_alarm_infoServices.Query(a => a.AlarmTime > month && (a.AlarmTypeID == 4 || a.AlarmTypeID == 5 || a.AlarmTypeID == 6 || a.AlarmTypeID == 7 || a.AlarmTypeID == 8));
            dc.Add("ZDGXListL", ZDGXList.Count);
            dc.Add("VideoAlarmListL", VideoAlarmList.Count);
            dc.Add("FaceListL", FaceList.Count);
            dc.Add("CarListL", CarList.Count);
            dc.Add("ShaoWeiListL", ShaoWeiList.Count);

            //上月
            int year = DateTime.Now.Year;//当前年  
            int mouth = DateTime.Now.Month;//当前月  

            int beforeYear = 0;
            int beforeMouth = 0;
            if (mouth <= 1)//如果当前月是一月，那么年份就要减1  
            {
                beforeYear = year - 1;
                beforeMouth = 12;//上个月  
            }
            else
            {
                beforeYear = year;
                beforeMouth = mouth - 1;//上个月  
            }
            DateTime beforeMouthOneDay = Convert.ToDateTime(beforeYear + "-" + beforeMouth + "-" + "01" + " 00:00:00");//上个月第一天  
            DateTime beforeMouthLastDay = Convert.ToDateTime(beforeYear + "-" + beforeMouth + "-" + DateTime.DaysInMonth(year, beforeMouth)+" 23:59:59");//上个月最后一天

            var ZDGXListO = await _d_alarm_infoServices.Query(a => a.AlarmTime > beforeMouthOneDay && a.AlarmTime < beforeMouthLastDay && a.AlarmTypeID == 3);
            var VideoAlarmListO = await _d_alarm_infoServices.Query(a => a.AlarmTime > beforeMouthOneDay && a.AlarmTime < beforeMouthLastDay && (a.AlarmTypeID == 2 || a.AlarmTypeID == 15 || a.AlarmTypeID == 16));
            var FaceListO = await _d_target_camera_record_peopleServices.Query(a => a.RecTime > beforeMouthOneDay && a.RecTime < beforeMouthLastDay);
            var CarListO = await _d_car_attributeServices.Query(a => a.Time > beforeMouthOneDay && a.Time < beforeMouthLastDay);
            var ShaoWeiListO = await _d_alarm_infoServices.Query(a => a.AlarmTime > beforeMouthOneDay && a.AlarmTime < beforeMouthLastDay && (a.AlarmTypeID == 4 || a.AlarmTypeID == 5 || a.AlarmTypeID == 6 || a.AlarmTypeID == 7 || a.AlarmTypeID == 8));
            dc.Add("ZDGXListO", ZDGXListO.Count);
            dc.Add("VideoAlarmListO", VideoAlarmListO.Count);
            dc.Add("FaceListO", FaceListO.Count);
            dc.Add("CarListO", CarListO.Count);
            dc.Add("ShaoWeiListO", ShaoWeiListO.Count);
            return dc;
        }
    }
}

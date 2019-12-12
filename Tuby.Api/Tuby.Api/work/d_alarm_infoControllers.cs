using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Microsoft.AspNetCore.Authorization;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_alarm_infoControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class d_alarm_infoController : ControllerBase
    { 
		 readonly Id_alarm_infoServices _d_alarm_infoServices;
        readonly Ib_alarm_typeServices _b_alarm_typeServices;
        readonly ItopicsdkjgServices _topicsdkjgServices;
        readonly IHandAlarmServices _HandAlarmServices;
        readonly Id_target_camera_record_peopleServices _d_target_camera_record_peopleServices;
        readonly IDeviceListServices _DeviceListServices;
        readonly Id_poeple_attributeServices _d_poeple_attributeServices;
        readonly Id_car_attributeServices _d_car_attributeServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_infoController(Id_alarm_infoServices d_alarm_infoServices, Ib_alarm_typeServices b_alarm_typeServices, ItopicsdkjgServices topicsdkjgServices, IHandAlarmServices HandAlarmServices, Id_target_camera_record_peopleServices d_target_camera_record_peopleServices, IDeviceListServices DeviceListServices, Id_poeple_attributeServices d_poeple_attributeServices, Id_car_attributeServices d_car_attributeServices)
        {
            _d_alarm_infoServices = d_alarm_infoServices;
            _b_alarm_typeServices = b_alarm_typeServices;
            _topicsdkjgServices = topicsdkjgServices;
            _HandAlarmServices = HandAlarmServices;
            _d_target_camera_record_peopleServices = d_target_camera_record_peopleServices;
            _DeviceListServices = DeviceListServices;
            _d_poeple_attributeServices = d_poeple_attributeServices;
            _d_car_attributeServices = d_car_attributeServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        [AllowAnonymous]
        public async Task<List<d_alarm_info>> Get()
        {
            return await _d_alarm_infoServices.Query("","updatetime desc");
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        [AllowAnonymous]
        public async Task<PageModel<d_alarm_info>> GetPage(int page)
        {
            return await _d_alarm_infoServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_alarm_info>> Get(int id)
        {
            return await _d_alarm_infoServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_alarm_info d_alarm_info)
        {
			var data = new MessageModel<string>();

            var id = (await _d_alarm_infoServices.Add(d_alarm_info));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// 使用post方法添加光纤报警
		/// </summary>
        [HttpPost]
        [Route("topicsdkzdgq_alarm_event")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostJG([FromBody] JGAlarmView JGAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list=await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("震动光纤"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            int alarmID = JGAlarmView.EventID;
            var jgAlarm = await _topicsdkjgServices.Query(c => c.ID == alarmID);
            dai.Content = jgAlarm.First().Name;
            dai.StatusID = JGAlarmView.StatusID;
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = DateTime.Now;
            var id = (await _d_alarm_infoServices.Add(dai));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

        /// <summary>
		/// 使用post方法添加哨位报警
		/// </summary>
        [HttpPost]
        [Route("topicsdksentry_alarm_event")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostSW([FromBody] SWZDAlarmView SWZDAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list = await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("脱逃"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }else if (item.Name.Contains("暴狱"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("劫持"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("袭击"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("灾害"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            dai.Content = SWZDAlarmView.Description;
            dai.StatusID = SWZDAlarmView.StatusID;
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = DateTime.Now;
            var id = (await _d_alarm_infoServices.Add(dai));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

        /// <summary>
        /// 使用post方法添加周界报警
        /// </summary>
        [HttpPost]
        [Route("SmartBICapture")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostZJ([FromBody] ZJAlarmView ZJAlarmView)
        {
            var data = new MessageModel<string>();

            var type = ZJAlarmView.Type;
            if (type == 3)
            {
                d_target_camera_record_people drp = new d_target_camera_record_people();
                var list = await _DeviceListServices.Query(c => c.DeviceID == ZJAlarmView.CameraId);
                drp.Position = list.FirstOrDefault().name;
                var dc = ZJAlarmView.FaceInfo;
                drp.PeopleID = Convert.ToInt32(dc["FaceId"]);
                drp.Name = dc["Name"];
                drp.Similar = Convert.ToInt32(dc["Similar"]);
                drp.ImagePath = ZJAlarmView.ImageUrl;
                drp.RecTime = Convert.ToDateTime(ZJAlarmView.time);
                var id = (await _d_target_camera_record_peopleServices.Add(drp));
                data.success = id > 0;
                if (data.success)
                {
                    data.response = id.ObjToString();
                    data.msg = "添加人脸识别信息成功";
                }
            }
            else if (ZJAlarmView.MixedDetect!=null)
            {
                var dc = ZJAlarmView.MixedDetect;
                var id = 0;
                if (dc["Type"] == "people")
                {
                    d_poeple_attribute dpa = new d_poeple_attribute();
                    var list = await _DeviceListServices.Query(c => c.DeviceID == ZJAlarmView.CameraId);
                    dpa.Position = list.FirstOrDefault().name;
                    dpa.Type = dc["Type"];
                    dpa.Age = dc["Age"];
                    dpa.Baby = dc["Baby"];
                    dpa.Bag = dc["Bag"];
                    dpa.BottomColor = dc["BottomColor"];
                    dpa.BottomType = dc["BottomType"];
                    dpa.BottomType = dc["BottomType"];
                    dpa.Hat = dc["Hat"];
                    dpa.Knapsack = dc["Knapsack"];
                    dpa.Orientation = dc["Orientation"];
                    dpa.Sex = dc["Sex"];
                    dpa.ShoulderBag = dc["ShoulderBag"];
                    dpa.UpperColor = dc["UpperColor"];
                    dpa.UpperType = dc["UpperType"];
                    id = (await _d_poeple_attributeServices.Add(dpa));
                }
                else if (dc["Type"] == "car")
                {
                    d_car_attribute dpa = new d_car_attribute();
                    var list = await _DeviceListServices.Query(c => c.DeviceID == ZJAlarmView.CameraId);
                    dpa.Position = list.FirstOrDefault().name;
                    dpa.Type = dc["Type"];
                    dpa.Mistake = dc["Mistake"];
                    dpa.Licence = dc["Licence"];
                    dpa.PlateColor = dc["PlateColor"];
                    dpa.PlateRect = dc["PlateRect"];
                    dpa.PlateType = dc["PlateType"];
                    dpa.VehicleColor = dc["VehicleColor"];
                    dpa.VehicleType = dc["VehicleType"];
                    dpa.Time = DateTime.Now;
                    id = (await _d_car_attributeServices.Add(dpa));
                }

                data.success = id > 0;
                if (data.success)
                {
                    data.response = id.ObjToString();
                    data.msg = "添加混合检测人员信息成功";
                }

            }
            else
            {
                d_alarm_info dai = new d_alarm_info();
                var list = await _b_alarm_typeServices.Query();
                foreach (var item in list)
                {
                    if (item.Name.Contains("越界"))
                    {
                        dai.AlarmTypeID = item.ID;
                        break;
                    }else if (item.Name.Contains("徘徊"))
                    {
                        dai.AlarmTypeID = item.ID;
                        break;
                    }
                }
                //dai.AlarmDeviceID = ZJAlarmView.CameraId;
                dai.VedioRecrdPath = ZJAlarmView.ImageUrl;
                dai.Content = ZJAlarmView.EventType;
                dai.UpdateTime = DateTime.Now;
                dai.AlarmTime = Convert.ToDateTime(ZJAlarmView.time);
                var id = (await _d_alarm_infoServices.Add(dai));
                data.success = id > 0;
                if (data.success)
                {
                    data.response = id.ObjToString();
                    data.msg = "添加周界报警信息成功";
                }
            }
            

            return data;
        }

        /// <summary>
		/// 使用post方法添加手动报警数据
		/// </summary>
        [HttpPost]
        [Route("topicvideohand")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostHand([FromBody] HandAlarm HandAlarm)
        {
            var data = new MessageModel<string>();

            var id = (await _HandAlarmServices.Add(HandAlarm));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

        /// <summary>
		/// 使用post方法添加车辆识别报警
		/// </summary>
        [HttpPost]
        [Route("topicsdkhikvision_gate_vehicle")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostCar([FromBody] JGAlarmView JGAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list = await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("震动光纤"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            int alarmID = JGAlarmView.EventID;
            var jgAlarm = await _topicsdkjgServices.Query(c => c.ID == alarmID);
            dai.Content = jgAlarm.First().Name;
            dai.StatusID = JGAlarmView.StatusID;
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = DateTime.Now;
            var id = (await _d_alarm_infoServices.Add(dai));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

        /// <summary>
        ///更新数据
        /// </summary>
        [HttpPost]
        [Route("update")]
        public async Task<MessageModel<string>> Update([FromBody] d_alarm_info d_alarm_info)
        {
			var data = new MessageModel<string>();
            if (d_alarm_info != null && d_alarm_info.ID > 0)
            {
                var id = (await _d_alarm_infoServices.Update(d_alarm_info));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_alarm_info.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_alarm_info.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// 根据id使用get方法删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_alarm_infoServices.DeleteById(id));
            var data = new MessageModel<string>();
            data.success = flag;
            if (flag)
            {
                data.response = id.ToString()+"数据删除";
                data.msg = "删除成功";
            }
            else
            {
                data.response ="id为"+ id.ToString() + "的数据找不到";
                data.msg = "删除失败";
            }

            return data;
        }

		/// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletemuch")]
        public async Task<MessageModel<string>> DeleteMuch([FromBody] object[] id)
        {
            var flag = (await _d_alarm_infoServices.DeleteByIds(id));
            var data = new MessageModel<string>();
            data.success = flag;
            if (flag)
            {
                data.response = string.Join(",", id) + "数据删除";
                data.msg = "删除成功";
            }
            else
            {
                data.response = "id为" + id.ToString() + "的数据找不到";
                data.msg = "删除失败";
            }

            return data;
        }
    }
}

	
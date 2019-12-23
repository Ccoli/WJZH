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
using System.Linq.Expressions;

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
        readonly Id_video_baseServices _d_viceo_baseServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_infoController(Id_alarm_infoServices d_alarm_infoServices, Ib_alarm_typeServices b_alarm_typeServices, ItopicsdkjgServices topicsdkjgServices, IHandAlarmServices HandAlarmServices, Id_target_camera_record_peopleServices d_target_camera_record_peopleServices, IDeviceListServices DeviceListServices, Id_poeple_attributeServices d_poeple_attributeServices, Id_car_attributeServices d_car_attributeServices, Id_video_baseServices d_viceo_baseServices)
        {
            _d_alarm_infoServices = d_alarm_infoServices;
            _b_alarm_typeServices = b_alarm_typeServices;
            _topicsdkjgServices = topicsdkjgServices;
            _HandAlarmServices = HandAlarmServices;
            _d_target_camera_record_peopleServices = d_target_camera_record_peopleServices;
            _DeviceListServices = DeviceListServices;
            _d_poeple_attributeServices = d_poeple_attributeServices;
            _d_car_attributeServices = d_car_attributeServices;
            _d_viceo_baseServices = d_viceo_baseServices;
        }
        /// <summary>
        ///查询所有数据
        /// </summary>	
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<d_alarm_info>> Get()
        {
            //return await _d_alarm_infoServices.Query("","updatetime desc");
            Expression<Func<d_alarm_info, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_infoServices.Query(whereExpression, "updatetime desc");
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
            Expression<Func<d_alarm_info, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_infoServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_alarm_info>> Get(string id)
        {
            return await _d_alarm_infoServices.Query(c => c.Guid == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
        public async Task<MessageModel<string>> Post([FromBody] d_alarm_info d_alarm_info)
        {
            var data = new MessageModel<string>();
            d_alarm_info.Guid = Guid.NewGuid().ToString();
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
        [Route("DeviceGuangXian")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostJG([FromBody] JGAlarmView JGAlarmView)
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
            ////string Position = "";
            ////var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == JGAlarmView.AlarmID);
            ////if (list2.Count > 0)
            ////{
            ////    foreach (var item in list2)
            ////    {
            ////        Position = Position + item.Name + ".";
            ////    }
            ////}
            //dai.Position = Position;
            int alarmID = JGAlarmView.EventID;
            var jgAlarm = await _topicsdkjgServices.Query(c => c.ID == alarmID);
            var alarmPosition = JGAlarmView.AreaID;
            dai.HandleID = JGAlarmView.Guid;
            dai.Content = alarmPosition.ToString() + "段区域" + jgAlarm.First().Name;
            dai.Guid = Guid.NewGuid().ToString();
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
        [Route("DeviceShaoWeiAlarm")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostSW([FromBody] SWZDAlarmView SWZDAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list = await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("逃"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("狱"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("劫"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("袭"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("灾"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            //string Position = "";
            //var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == SWZDAlarmView.AlarmID);
            //if (list.Count > 0)
            //{
            //    foreach (var item in list)
            //    {
            //        Position = Position + item.Name + ".";
            //    }
            //    dai.Position = Position;
            //}
            dai.Position = SWZDAlarmView.Description;
            dai.Content = SWZDAlarmView.Description;
            dai.Guid = Guid.NewGuid().ToString();
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = DateTime.Now;
            dai.HandleID = SWZDAlarmView.Guid;
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
        /// 使用post方法添加yft车辆报警
        /// </summary>
        [HttpPost]
        [Route("DeviceCheLiangYFT")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostFaceYFT([FromBody] CheLiangAlarmYFTView CheLiangAlarmYFTView)
        {
            var data = new MessageModel<string>();
            var dc = CheLiangAlarmYFTView.MixedDetect;
            d_car_attribute dpa = new d_car_attribute();
            //var list = await _DeviceListServices.Query(c => c.DeviceID == CheLiangAlarmYFTView.CameraId);
            string Position = "";

            //dpa.Position = list.FirstOrDefault().name;
            dpa.Type = dc["Type"];
            dpa.Mistake = dc["Mistake"];
            dpa.Licence = dc["Licence"];
            dpa.PlateColor = dc["PlateColor"];
            dpa.PlateRect = dc["PlateRect"];
            dpa.PlateType = dc["PlateType"];
            dpa.VehicleColor = dc["VehicleColor"];
            dpa.VehicleType = dc["VehicleType"];
            dpa.Time = DateTime.Now;
            dpa.Guid = Guid.NewGuid().ToString();
            dpa.HandleID = CheLiangAlarmYFTView.Guid;
            var id = (await _d_car_attributeServices.Add(dpa));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加车辆信息成功";
            }
            return data;
        }

        /// <summary>
        /// 使用post方法添加hk车辆报警
        /// </summary>
        [HttpPost]
        [Route("DeviceCheLiangHK")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostFaceHK([FromBody] VehicleIdentificationView VehicleIdentificationView)
        {
            var data = new MessageModel<string>();

            d_car_attribute dpa = new d_car_attribute();
            //var list = await _DeviceListServices.Query(c => c.DeviceID == VehicleIdentificationView.DeviceId);
            //string Position = "";
            //var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == VehicleIdentificationView.DeviceId);
            //if (list2.Count > 0)
            //{
            //    foreach (var item in list2)
            //    {
            //        Position = Position + item.Name + ".";
            //    }
            //    dpa.Position = Position;
            //}
            //dpa.Guid = VehicleIdentificationView.Guid;
            dpa.Type = "car";
            dpa.Mistake = "前";
            dpa.Licence = VehicleIdentificationView.byVehicleLogoRecogString;
            dpa.PlateColor = VehicleIdentificationView.PlateColorString;
            dpa.PlateRect = VehicleIdentificationView.PlateNumber;
            dpa.PlateType = VehicleIdentificationView.PlateTypeString;
            dpa.VehicleColor = VehicleIdentificationView.VehicleColorString;
            dpa.VehicleType = VehicleIdentificationView.VehicleTypeString;
            dpa.Time = DateTime.Now;
            dpa.Guid = Guid.NewGuid().ToString();
            dpa.HandleID = VehicleIdentificationView.Guid;
            var id = (await _d_car_attributeServices.Add(dpa));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加车牌信息成功";
            }
            return data;
        }

        /// <summary>
        /// 使用post方法添加yft人脸报警
        /// </summary>
        [HttpPost]
        [Route("DeviceRenLianYFT")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostCLYFT([FromBody] FaceAlarmYFT FaceAlarmYFT)
        {
            var data = new MessageModel<string>();

            d_target_camera_record_people drp = new d_target_camera_record_people();
            //var list = await _DeviceListServices.Query(c => c.DeviceID == FaceAlarmYFT.CameraId);
            //string Position = "";
            //var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == FaceAlarmYFT.CameraId);
            //if (list2.Count > 0)
            //{
            //    foreach (var item in list2)
            //    {
            //        Position = Position + item.Name + ".";
            //    }
            //    drp.Position = Position;
            //}
            var dc = FaceAlarmYFT.FaceInfo;
            drp.PeopleID = Convert.ToInt32(dc["FaceId"]);
            drp.Name = dc["Name"];
            drp.Similar = Convert.ToInt32(dc["Similar"]);
            drp.ImagePath = FaceAlarmYFT.ImageUrl;
            drp.RecTime = Convert.ToDateTime(FaceAlarmYFT.time);
            drp.Guid = Guid.NewGuid().ToString();
            drp.HandleID = FaceAlarmYFT.Guid;
            var id = (await _d_target_camera_record_peopleServices.Add(drp));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加人脸识别信息成功";
            }
            return data;
        }

        /// <summary>
        /// 使用post方法添加周界报警
        /// </summary>
        [HttpPost]
        [Route("DeviceVideoAnalysisYFT")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostZJ([FromBody] ZJAlarmView ZJAlarmView)
        {
            var data = new MessageModel<string>();

            var type = ZJAlarmView.Type;

            d_alarm_info dai = new d_alarm_info();
            var list = await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("越界") && ZJAlarmView.EventType.Contains("区域"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("越线") && ZJAlarmView.EventType.Contains("线"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("徘徊") && ZJAlarmView.EventType.Contains("徘徊"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            //string Position = "";
            //var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == ZJAlarmView.CameraId);
            //if (list2.Count > 0)
            //{
            //    foreach (var item in list2)
            //    {
            //        Position = Position + item.Name + ".";
            //    }
            //    dai.Position = Position;
            //}
            //dai.AlarmDeviceID = ZJAlarmView.CameraId;
            dai.VedioRecrdPath = ZJAlarmView.ImageUrl;
            dai.Content = ZJAlarmView.EventType;
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = Convert.ToDateTime(ZJAlarmView.time);
            dai.Guid = Guid.NewGuid().ToString();
            dai.HandleID = ZJAlarmView.Guid;
            var id = (await _d_alarm_infoServices.Add(dai));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加周界报警信息成功";
            }
            return data;
        }
        [HttpPost]
        [Route("DeviceVideoAnalysisHK")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostZJHK([FromBody] ZJHKAlarmView ZJHKAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list = await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("越界") && ZJHKAlarmView.AlarmTypeId == 4)
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
                else if (item.Name.Contains("越线") && ZJHKAlarmView.AlarmTypeId == 1)
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            //string Position = "";
            //var list2 = await _d_viceo_baseServices.Query(c => c.CameraID == ZJHKAlarmView.DeviceId);
            //if (list2.Count > 0)
            //{
            //    foreach (var item in list2)
            //    {
            //        Position = Position + item.Name + ".";
            //    }
            //    dai.Position = Position;
            //}
            //dai.AlarmDeviceID = ZJAlarmView.CameraId;
            dai.VedioRecrdPath = ZJHKAlarmView.ImageUrl;
            dai.Content = ZJHKAlarmView.AlarmTypeDesc;
            dai.UpdateTime = DateTime.Now;
            dai.AlarmTime = DateTime.Now;
            dai.Guid = Guid.NewGuid().ToString();
            dai.HandleID = ZJHKAlarmView.Guid;
            var id = (await _d_alarm_infoServices.Add(dai));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加周界报警信息成功";
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
            dai.Guid = JGAlarmView.Guid;
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
            if (d_alarm_info != null)
            {
                var id = (await _d_alarm_infoServices.Update(d_alarm_info));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" + d_alarm_info.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" + d_alarm_info.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
        ///更新处置状态数据
        /// </summary>
        [HttpPost]
        [Route("upstatus")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> UpdateStatus([FromForm] string id)
        {

            var data = new MessageModel<string>();
            var alarmInfo = (await _d_alarm_infoServices.Query(c => c.HandleID == id)).FirstOrDefault();
            alarmInfo.RecStatus = 1;
            alarmInfo.UpdateTime = DateTime.Now;
            //d_handle_info.Guid = Guid.NewGuid().ToString();
            var flag = await _d_alarm_infoServices.Update(alarmInfo);
            data.success = flag;
            if (data.success)
            {
                data.response = "数据更新成功";
                data.msg = "更新成功";
            }
            else
            {
                data.response = "数据不存在";
            }

            return data;
        }

        /// <summary>
		/// 根据id使用get方法删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
        public async Task<MessageModel<string>> Delete(string id)
        {
            var data = new MessageModel<string>();
            if (id != "")
            {
                var model = await _d_alarm_infoServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _d_alarm_infoServices.Update(model);
                data.success = flag;
                if (flag)
                {
                    data.response = id.ToString() + "数据删除";
                    data.msg = "删除成功";
                }
                else
                {
                    data.response = "id为" + id.ToString() + "的数据找不到";
                    data.msg = "删除失败";
                }
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
            var list = await _d_alarm_infoServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _d_alarm_infoServices.Update(list);
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


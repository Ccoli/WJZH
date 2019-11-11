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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_infoController(Id_alarm_infoServices d_alarm_infoServices, Ib_alarm_typeServices b_alarm_typeServices, ItopicsdkjgServices topicsdkjgServices, IHandAlarmServices HandAlarmServices)
        {
            _d_alarm_infoServices = d_alarm_infoServices;
            _b_alarm_typeServices = b_alarm_typeServices;
            _topicsdkjgServices = topicsdkjgServices;
            _HandAlarmServices = HandAlarmServices;
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
		/// 使用post方法添加激光报警
		/// </summary>
        [HttpPost]
        [Route("topicsdkjg")]
        [AllowAnonymous]
        public async Task<MessageModel<string>> PostJG([FromBody] JGAlarmView JGAlarmView)
        {
            var data = new MessageModel<string>();

            d_alarm_info dai = new d_alarm_info();
            var list=await _b_alarm_typeServices.Query();
            foreach (var item in list)
            {
                if (item.Name.Contains("激光"))
                {
                    dai.AlarmTypeID = item.ID;
                    break;
                }
            }
            int alarmID = JGAlarmView.EventID;
            var jgAlarm = await _topicsdkjgServices.Query(c => c.ID == alarmID);
            dai.Content = jgAlarm.First().Name;
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

	
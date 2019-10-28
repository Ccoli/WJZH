using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_dutyControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_dutyController : ControllerBase
    { 
		 readonly Id_dutyServices _d_dutyServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_dutyController(Id_dutyServices d_dutyServices)
        {
            _d_dutyServices = d_dutyServices;
        }
		/// <summary>
		///查询执勤信息表
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_duty>> Get()
        {
            return await _d_dutyServices.QueryDuty();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<d_duty>> GetPage(int page)
        {
            return await _d_dutyServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_duty>> Get(int id)
        {
            return await _d_dutyServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] DutyEntity datas)
        {
			var data = new MessageModel<string>();
            string time = "";
            foreach (d_duty d_duty in datas.tabledatas)
            {
                d_duty.UpdateTime = DateTime.Now;
                time = d_duty.ExcutionTime;
            }
            var flag = await _d_dutyServices.DeleteDuty(time);
            if (flag)
            {
                var id = (await _d_dutyServices.AddList(datas.tabledatas));
                data.success = id > 0;
                if (data.success)
                {
                    data.response = "200";
                    data.msg = "添加成功";
                }
            }
            return data;
        }

         /// <summary>
		///更新数据
		/// </summary>
        [HttpPost]
        [Route("update")]
        public async Task<MessageModel<string>> Update([FromBody] d_duty d_duty)
        {
			var data = new MessageModel<string>();
            if (d_duty != null && d_duty.ID > 0)
            {
                var id = (await _d_dutyServices.Update(d_duty));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_duty.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_duty.ID.ToString() + "的数据不存在";
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
            var flag = (await _d_dutyServices.DeleteById(id));
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
            var flag = (await _d_dutyServices.DeleteByIds(id));
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

	
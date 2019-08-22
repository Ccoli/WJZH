using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_soldier_leaveControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_soldier_leaveController : ControllerBase
    { 
		 readonly Id_soldier_leaveServices _d_soldier_leaveServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_soldier_leaveController(Id_soldier_leaveServices d_soldier_leaveServices)
        {
            _d_soldier_leaveServices = d_soldier_leaveServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_soldier_leave>> Get()
        {
            return await _d_soldier_leaveServices.Query();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<d_soldier_leave>> GetPage(int page)
        {
            return await _d_soldier_leaveServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_soldier_leave>> Get(int id)
        {
            return await _d_soldier_leaveServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_soldier_leave d_soldier_leave)
        {
			var data = new MessageModel<string>();

            var id = (await _d_soldier_leaveServices.Add(d_soldier_leave));
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
        public async Task<MessageModel<string>> Update([FromBody] d_soldier_leave d_soldier_leave)
        {
			var data = new MessageModel<string>();
            if (d_soldier_leave != null && d_soldier_leave.ID > 0)
            {
                var id = (await _d_soldier_leaveServices.Update(d_soldier_leave));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_soldier_leave.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_soldier_leave.ID.ToString() + "的数据不存在";
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
            var flag = (await _d_soldier_leaveServices.DeleteById(id));
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
            var flag = (await _d_soldier_leaveServices.DeleteByIds(id));
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

	
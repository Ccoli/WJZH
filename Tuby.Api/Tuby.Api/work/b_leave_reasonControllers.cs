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
	/// b_leave_reasonControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_leave_reasonController : ControllerBase
    { 
		 readonly Ib_leave_reasonServices _b_leave_reasonServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_leave_reasonController(Ib_leave_reasonServices b_leave_reasonServices)
        {
            _b_leave_reasonServices = b_leave_reasonServices;
        }
		/// <summary>
		/// api/b_leave_reason 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_leave_reason>> Get()
        {
            return await _b_leave_reasonServices.Query();
        }

        /// <summary>
		/// api/b_leave_reason/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_leave_reason>> Get(int id)
        {
            return await _b_leave_reasonServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_leave_reason post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_leave_reason b_leave_reason)
        {
			var data = new MessageModel<string>();

            var id = (await _b_leave_reasonServices.Add(b_leave_reason));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_leave_reason put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_leave_reason b_leave_reason)
        {
			var data = new MessageModel<string>();
            if (b_leave_reason != null && b_leave_reason.ID > 0)
            {
                var id = (await _b_leave_reasonServices.Update(b_leave_reason));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_leave_reason.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_leave_reason.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_leave_reason/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_leave_reasonServices.DeleteById(id));
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
    }
}

	
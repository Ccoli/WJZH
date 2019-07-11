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
	/// d_shaowei_turnControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_shaowei_turnController : ControllerBase
    { 
		 readonly Id_shaowei_turnServices _d_shaowei_turnServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_shaowei_turnController(Id_shaowei_turnServices d_shaowei_turnServices)
        {
            _d_shaowei_turnServices = d_shaowei_turnServices;
        }
		/// <summary>
		/// api/d_shaowei_turn 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_shaowei_turn>> Get()
        {
            return await _d_shaowei_turnServices.Query();
        }

        /// <summary>
		/// api/d_shaowei_turn/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_shaowei_turn>> Get(int id)
        {
            return await _d_shaowei_turnServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_shaowei_turn post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_shaowei_turn d_shaowei_turn)
        {
			var data = new MessageModel<string>();

            var id = (await _d_shaowei_turnServices.Add(d_shaowei_turn));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_shaowei_turn put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_shaowei_turn d_shaowei_turn)
        {
			var data = new MessageModel<string>();
            if (d_shaowei_turn != null && d_shaowei_turn.ID > 0)
            {
                var id = (await _d_shaowei_turnServices.Update(d_shaowei_turn));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_shaowei_turn.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_shaowei_turn.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_shaowei_turn/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_shaowei_turnServices.DeleteById(id));
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

	
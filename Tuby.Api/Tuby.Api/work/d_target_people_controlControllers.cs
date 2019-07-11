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
	/// d_target_people_controlControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_target_people_controlController : ControllerBase
    { 
		 readonly Id_target_people_controlServices _d_target_people_controlServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_target_people_controlController(Id_target_people_controlServices d_target_people_controlServices)
        {
            _d_target_people_controlServices = d_target_people_controlServices;
        }
		/// <summary>
		/// api/d_target_people_control 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_target_people_control>> Get()
        {
            return await _d_target_people_controlServices.Query();
        }

        /// <summary>
		/// api/d_target_people_control/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_target_people_control>> Get(int id)
        {
            return await _d_target_people_controlServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_target_people_control post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_target_people_control d_target_people_control)
        {
			var data = new MessageModel<string>();

            var id = (await _d_target_people_controlServices.Add(d_target_people_control));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_target_people_control put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_target_people_control d_target_people_control)
        {
			var data = new MessageModel<string>();
            if (d_target_people_control != null && d_target_people_control.ID > 0)
            {
                var id = (await _d_target_people_controlServices.Update(d_target_people_control));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_target_people_control.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_target_people_control.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_target_people_control/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_target_people_controlServices.DeleteById(id));
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

	
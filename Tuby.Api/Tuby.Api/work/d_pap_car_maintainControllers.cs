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
	/// d_pap_car_maintainControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_car_maintainController : ControllerBase
    { 
		 readonly Id_pap_car_maintainServices _d_pap_car_maintainServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_car_maintainController(Id_pap_car_maintainServices d_pap_car_maintainServices)
        {
            _d_pap_car_maintainServices = d_pap_car_maintainServices;
        }
		/// <summary>
		/// api/d_pap_car_maintain 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_car_maintain>> Get()
        {
            return await _d_pap_car_maintainServices.Query();
        }

        /// <summary>
		/// api/d_pap_car_maintain/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_car_maintain>> Get(int id)
        {
            return await _d_pap_car_maintainServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_pap_car_maintain post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_car_maintain d_pap_car_maintain)
        {
			var data = new MessageModel<string>();

            var id = (await _d_pap_car_maintainServices.Add(d_pap_car_maintain));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_pap_car_maintain put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_car_maintain d_pap_car_maintain)
        {
			var data = new MessageModel<string>();
            if (d_pap_car_maintain != null && d_pap_car_maintain.ID > 0)
            {
                var id = (await _d_pap_car_maintainServices.Update(d_pap_car_maintain));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_car_maintain.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_car_maintain.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_pap_car_maintain/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_pap_car_maintainServices.DeleteById(id));
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

	
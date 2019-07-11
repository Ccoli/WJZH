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
	/// d_target_carControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_target_carController : ControllerBase
    { 
		 readonly Id_target_carServices _d_target_carServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_target_carController(Id_target_carServices d_target_carServices)
        {
            _d_target_carServices = d_target_carServices;
        }
		/// <summary>
		/// api/d_target_car 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_target_car>> Get()
        {
            return await _d_target_carServices.Query();
        }

        /// <summary>
		/// api/d_target_car/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_target_car>> Get(int id)
        {
            return await _d_target_carServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_target_car post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_target_car d_target_car)
        {
			var data = new MessageModel<string>();

            var id = (await _d_target_carServices.Add(d_target_car));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_target_car put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_target_car d_target_car)
        {
			var data = new MessageModel<string>();
            if (d_target_car != null && d_target_car.ID > 0)
            {
                var id = (await _d_target_carServices.Update(d_target_car));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_target_car.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_target_car.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_target_car/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_target_carServices.DeleteById(id));
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

	
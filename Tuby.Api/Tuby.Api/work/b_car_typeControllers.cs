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
	/// b_car_typeControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_car_typeController : ControllerBase
    { 
		 readonly Ib_car_typeServices _b_car_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_car_typeController(Ib_car_typeServices b_car_typeServices)
        {
            _b_car_typeServices = b_car_typeServices;
        }
		/// <summary>
		/// api/b_car_type 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_car_type>> Get()
        {
            return await _b_car_typeServices.Query();
        }

        /// <summary>
		/// api/b_car_type/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_car_type>> Get(int id)
        {
            return await _b_car_typeServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_car_type post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_car_type b_car_type)
        {
			var data = new MessageModel<string>();

            var id = (await _b_car_typeServices.Add(b_car_type));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_car_type put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_car_type b_car_type)
        {
			var data = new MessageModel<string>();
            if (b_car_type != null && b_car_type.ID > 0)
            {
                var id = (await _b_car_typeServices.Update(b_car_type));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_car_type.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_car_type.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_car_type/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_car_typeServices.DeleteById(id));
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

	
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
	/// d_phone_tableControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_phone_tableController : ControllerBase
    { 
		 readonly Id_phone_tableServices _d_phone_tableServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_phone_tableController(Id_phone_tableServices d_phone_tableServices)
        {
            _d_phone_tableServices = d_phone_tableServices;
        }
		/// <summary>
		/// api/d_phone_table 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_phone_table>> Get()
        {
            return await _d_phone_tableServices.Query();
        }

        /// <summary>
		/// api/d_phone_table/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_phone_table>> Get(int id)
        {
            return await _d_phone_tableServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_phone_table post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_phone_table d_phone_table)
        {
			var data = new MessageModel<string>();

            var id = (await _d_phone_tableServices.Add(d_phone_table));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_phone_table put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_phone_table d_phone_table)
        {
			var data = new MessageModel<string>();
            if (d_phone_table != null && d_phone_table.ID > 0)
            {
                var id = (await _d_phone_tableServices.Update(d_phone_table));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_phone_table.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_phone_table.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_phone_table/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_phone_tableServices.DeleteById(id));
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

	
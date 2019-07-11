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
	/// a_data_accessControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class a_data_accessController : ControllerBase
    { 
		 readonly Ia_data_accessServices _a_data_accessServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_data_accessController(Ia_data_accessServices a_data_accessServices)
        {
            _a_data_accessServices = a_data_accessServices;
        }
		/// <summary>
		/// api/a_data_access 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<a_data_access>> Get()
        {
            return await _a_data_accessServices.Query();
        }

        /// <summary>
		/// api/a_data_access/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<a_data_access>> Get(int id)
        {
            return await _a_data_accessServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/a_data_access post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] a_data_access a_data_access)
        {
			var data = new MessageModel<string>();

            var id = (await _a_data_accessServices.Add(a_data_access));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/a_data_access put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] a_data_access a_data_access)
        {
			var data = new MessageModel<string>();
            if (a_data_access != null && a_data_access.ID > 0)
            {
                var id = (await _a_data_accessServices.Update(a_data_access));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +a_data_access.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +a_data_access.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/a_data_access/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _a_data_accessServices.DeleteById(id));
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

	
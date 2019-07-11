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
	/// d_target_people_whitelistControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_target_people_whitelistController : ControllerBase
    { 
		 readonly Id_target_people_whitelistServices _d_target_people_whitelistServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_target_people_whitelistController(Id_target_people_whitelistServices d_target_people_whitelistServices)
        {
            _d_target_people_whitelistServices = d_target_people_whitelistServices;
        }
		/// <summary>
		/// api/d_target_people_whitelist 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_target_people_whitelist>> Get()
        {
            return await _d_target_people_whitelistServices.Query();
        }

        /// <summary>
		/// api/d_target_people_whitelist/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_target_people_whitelist>> Get(int id)
        {
            return await _d_target_people_whitelistServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_target_people_whitelist post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_target_people_whitelist d_target_people_whitelist)
        {
			var data = new MessageModel<string>();

            var id = (await _d_target_people_whitelistServices.Add(d_target_people_whitelist));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_target_people_whitelist put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_target_people_whitelist d_target_people_whitelist)
        {
			var data = new MessageModel<string>();
            if (d_target_people_whitelist != null && d_target_people_whitelist.ID > 0)
            {
                var id = (await _d_target_people_whitelistServices.Update(d_target_people_whitelist));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_target_people_whitelist.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_target_people_whitelist.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_target_people_whitelist/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_target_people_whitelistServices.DeleteById(id));
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

	
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
	/// d_target_people_blacklistControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_target_people_blacklistController : ControllerBase
    { 
		 readonly Id_target_people_blacklistServices _d_target_people_blacklistServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_target_people_blacklistController(Id_target_people_blacklistServices d_target_people_blacklistServices)
        {
            _d_target_people_blacklistServices = d_target_people_blacklistServices;
        }
		/// <summary>
		/// api/d_target_people_blacklist 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_target_people_blacklist>> Get()
        {
            return await _d_target_people_blacklistServices.Query();
        }

        /// <summary>
		/// api/d_target_people_blacklist/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_target_people_blacklist>> Get(int id)
        {
            return await _d_target_people_blacklistServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_target_people_blacklist post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_target_people_blacklist d_target_people_blacklist)
        {
			var data = new MessageModel<string>();

            var id = (await _d_target_people_blacklistServices.Add(d_target_people_blacklist));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_target_people_blacklist put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_target_people_blacklist d_target_people_blacklist)
        {
			var data = new MessageModel<string>();
            if (d_target_people_blacklist != null && d_target_people_blacklist.ID > 0)
            {
                var id = (await _d_target_people_blacklistServices.Update(d_target_people_blacklist));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_target_people_blacklist.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_target_people_blacklist.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_target_people_blacklist/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_target_people_blacklistServices.DeleteById(id));
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

	
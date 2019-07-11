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
	/// d_pap_matterControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_matterController : ControllerBase
    { 
		 readonly Id_pap_matterServices _d_pap_matterServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_matterController(Id_pap_matterServices d_pap_matterServices)
        {
            _d_pap_matterServices = d_pap_matterServices;
        }
		/// <summary>
		/// api/d_pap_matter 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_matter>> Get()
        {
            return await _d_pap_matterServices.Query();
        }

        /// <summary>
		/// api/d_pap_matter/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_matter>> Get(int id)
        {
            return await _d_pap_matterServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_pap_matter post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_matter d_pap_matter)
        {
			var data = new MessageModel<string>();

            var id = (await _d_pap_matterServices.Add(d_pap_matter));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_pap_matter put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_matter d_pap_matter)
        {
			var data = new MessageModel<string>();
            if (d_pap_matter != null && d_pap_matter.ID > 0)
            {
                var id = (await _d_pap_matterServices.Update(d_pap_matter));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_matter.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_matter.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_pap_matter/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_pap_matterServices.DeleteById(id));
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

	
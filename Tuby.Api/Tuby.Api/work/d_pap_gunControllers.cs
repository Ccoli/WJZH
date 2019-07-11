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
	/// d_pap_gunControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_gunController : ControllerBase
    { 
		 readonly Id_pap_gunServices _d_pap_gunServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_gunController(Id_pap_gunServices d_pap_gunServices)
        {
            _d_pap_gunServices = d_pap_gunServices;
        }
		/// <summary>
		/// api/d_pap_gun 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_gun>> Get()
        {
            return await _d_pap_gunServices.Query();
        }

        /// <summary>
		/// api/d_pap_gun/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_gun>> Get(int id)
        {
            return await _d_pap_gunServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_pap_gun post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_gun d_pap_gun)
        {
			var data = new MessageModel<string>();

            var id = (await _d_pap_gunServices.Add(d_pap_gun));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_pap_gun put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_gun d_pap_gun)
        {
			var data = new MessageModel<string>();
            if (d_pap_gun != null && d_pap_gun.ID > 0)
            {
                var id = (await _d_pap_gunServices.Update(d_pap_gun));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_gun.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_gun.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_pap_gun/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_pap_gunServices.DeleteById(id));
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

	
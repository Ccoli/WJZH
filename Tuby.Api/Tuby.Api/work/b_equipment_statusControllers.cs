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
	/// b_equipment_statusControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_equipment_statusController : ControllerBase
    { 
		 readonly Ib_equipment_statusServices _b_equipment_statusServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_equipment_statusController(Ib_equipment_statusServices b_equipment_statusServices)
        {
            _b_equipment_statusServices = b_equipment_statusServices;
        }
		/// <summary>
		/// api/b_equipment_status 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_equipment_status>> Get()
        {
            return await _b_equipment_statusServices.Query();
        }

        /// <summary>
		/// api/b_equipment_status/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_equipment_status>> Get(int id)
        {
            return await _b_equipment_statusServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_equipment_status post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_equipment_status b_equipment_status)
        {
			var data = new MessageModel<string>();

            var id = (await _b_equipment_statusServices.Add(b_equipment_status));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_equipment_status put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_equipment_status b_equipment_status)
        {
			var data = new MessageModel<string>();
            if (b_equipment_status != null && b_equipment_status.ID > 0)
            {
                var id = (await _b_equipment_statusServices.Update(b_equipment_status));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_equipment_status.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_equipment_status.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_equipment_status/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_equipment_statusServices.DeleteById(id));
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

	
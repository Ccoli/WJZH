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
	/// d_pap_equipmentControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_equipmentController : ControllerBase
    { 
		 readonly Id_pap_equipmentServices _d_pap_equipmentServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_equipmentController(Id_pap_equipmentServices d_pap_equipmentServices)
        {
            _d_pap_equipmentServices = d_pap_equipmentServices;
        }
		/// <summary>
		/// api/d_pap_equipment 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_equipment>> Get()
        {
            return await _d_pap_equipmentServices.Query();
        }

        /// <summary>
		/// api/d_pap_equipment/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_equipment>> Get(int id)
        {
            return await _d_pap_equipmentServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_pap_equipment post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_equipment d_pap_equipment)
        {
			var data = new MessageModel<string>();

            var id = (await _d_pap_equipmentServices.Add(d_pap_equipment));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_pap_equipment put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_equipment d_pap_equipment)
        {
			var data = new MessageModel<string>();
            if (d_pap_equipment != null && d_pap_equipment.ID > 0)
            {
                var id = (await _d_pap_equipmentServices.Update(d_pap_equipment));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_equipment.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_equipment.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_pap_equipment/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_pap_equipmentServices.DeleteById(id));
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

	
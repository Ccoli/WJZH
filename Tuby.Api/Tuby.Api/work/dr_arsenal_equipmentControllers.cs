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
	/// dr_arsenal_equipmentControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class dr_arsenal_equipmentController : ControllerBase
    { 
		 readonly Idr_arsenal_equipmentServices _dr_arsenal_equipmentServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public dr_arsenal_equipmentController(Idr_arsenal_equipmentServices dr_arsenal_equipmentServices)
        {
            _dr_arsenal_equipmentServices = dr_arsenal_equipmentServices;
        }
		/// <summary>
		/// api/dr_arsenal_equipment 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<dr_arsenal_equipment>> Get()
        {
            return await _dr_arsenal_equipmentServices.Query();
        }

        /// <summary>
		/// api/dr_arsenal_equipment/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<dr_arsenal_equipment>> Get(int id)
        {
            return await _dr_arsenal_equipmentServices.Query(c => c.ArsenalID == id);
        }

        /// <summary>
		/// api/dr_arsenal_equipment post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] dr_arsenal_equipment dr_arsenal_equipment)
        {
			var data = new MessageModel<string>();

            var id = (await _dr_arsenal_equipmentServices.Add(dr_arsenal_equipment));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/dr_arsenal_equipment put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] dr_arsenal_equipment dr_arsenal_equipment)
        {
			var data = new MessageModel<string>();
            if (dr_arsenal_equipment != null && dr_arsenal_equipment.ArsenalID > 0)
            {
                var id = (await _dr_arsenal_equipmentServices.Update(dr_arsenal_equipment));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +dr_arsenal_equipment.ArsenalID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +dr_arsenal_equipment.ArsenalID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/dr_arsenal_equipment/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _dr_arsenal_equipmentServices.DeleteById(id));
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

	
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
	/// dr_department_soldierControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class dr_department_soldierController : ControllerBase
    { 
		 readonly Idr_department_soldierServices _dr_department_soldierServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public dr_department_soldierController(Idr_department_soldierServices dr_department_soldierServices)
        {
            _dr_department_soldierServices = dr_department_soldierServices;
        }
		/// <summary>
		/// api/dr_department_soldier 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<dr_department_soldier>> Get()
        {
            return await _dr_department_soldierServices.Query();
        }

        /// <summary>
		/// api/dr_department_soldier/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<dr_department_soldier>> Get(int id)
        {
            return await _dr_department_soldierServices.Query(c => c.DepartmentID == id);
        }

        /// <summary>
		/// api/dr_department_soldier post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] dr_department_soldier dr_department_soldier)
        {
			var data = new MessageModel<string>();

            var id = (await _dr_department_soldierServices.Add(dr_department_soldier));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/dr_department_soldier put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] dr_department_soldier dr_department_soldier)
        {
			var data = new MessageModel<string>();
            if (dr_department_soldier != null && dr_department_soldier.DepartmentID > 0)
            {
                var id = (await _dr_department_soldierServices.Update(dr_department_soldier));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +dr_department_soldier.DepartmentID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +dr_department_soldier.DepartmentID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/dr_department_soldier/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _dr_department_soldierServices.DeleteById(id));
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

	
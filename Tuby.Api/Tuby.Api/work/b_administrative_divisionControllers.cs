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
	/// b_administrative_divisionControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_administrative_divisionController : ControllerBase
    { 
		 readonly Ib_administrative_divisionServices _b_administrative_divisionServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_administrative_divisionController(Ib_administrative_divisionServices b_administrative_divisionServices)
        {
            _b_administrative_divisionServices = b_administrative_divisionServices;
        }
		/// <summary>
		/// api/b_administrative_division 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_administrative_division>> Get()
        {
            return await _b_administrative_divisionServices.Query();
        }

        /// <summary>
		/// api/b_administrative_division/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_administrative_division>> Get(int id)
        {
            return await _b_administrative_divisionServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_administrative_division post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_administrative_division b_administrative_division)
        {
			var data = new MessageModel<string>();

            var id = (await _b_administrative_divisionServices.Add(b_administrative_division));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_administrative_division put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_administrative_division b_administrative_division)
        {
			var data = new MessageModel<string>();
            if (b_administrative_division != null && b_administrative_division.ID > 0)
            {
                var id = (await _b_administrative_divisionServices.Update(b_administrative_division));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_administrative_division.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_administrative_division.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_administrative_division/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_administrative_divisionServices.DeleteById(id));
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

	
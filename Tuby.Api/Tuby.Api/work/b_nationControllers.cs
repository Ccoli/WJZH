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
	/// b_nationControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_nationController : ControllerBase
    { 
		 readonly Ib_nationServices _b_nationServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_nationController(Ib_nationServices b_nationServices)
        {
            _b_nationServices = b_nationServices;
        }
		/// <summary>
		/// api/b_nation 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_nation>> Get()
        {
            return await _b_nationServices.Query();
        }

        /// <summary>
		/// api/b_nation/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_nation>> Get(int id)
        {
            return await _b_nationServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_nation post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_nation b_nation)
        {
			var data = new MessageModel<string>();

            var id = (await _b_nationServices.Add(b_nation));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_nation put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_nation b_nation)
        {
			var data = new MessageModel<string>();
            if (b_nation != null && b_nation.ID > 0)
            {
                var id = (await _b_nationServices.Update(b_nation));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_nation.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_nation.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_nation/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_nationServices.DeleteById(id));
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

	
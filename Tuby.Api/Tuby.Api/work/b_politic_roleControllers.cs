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
	/// b_politic_roleControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_politic_roleController : ControllerBase
    { 
		 readonly Ib_politic_roleServices _b_politic_roleServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_politic_roleController(Ib_politic_roleServices b_politic_roleServices)
        {
            _b_politic_roleServices = b_politic_roleServices;
        }
		/// <summary>
		/// api/b_politic_role 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_politic_role>> Get()
        {
            return await _b_politic_roleServices.Query();
        }

        /// <summary>
		/// api/b_politic_role/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_politic_role>> Get(int id)
        {
            return await _b_politic_roleServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_politic_role post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_politic_role b_politic_role)
        {
			var data = new MessageModel<string>();

            var id = (await _b_politic_roleServices.Add(b_politic_role));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_politic_role put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_politic_role b_politic_role)
        {
			var data = new MessageModel<string>();
            if (b_politic_role != null && b_politic_role.ID > 0)
            {
                var id = (await _b_politic_roleServices.Update(b_politic_role));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_politic_role.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_politic_role.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_politic_role/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_politic_roleServices.DeleteById(id));
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

	
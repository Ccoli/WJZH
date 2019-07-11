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
	/// a_userControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class a_userController : ControllerBase
    { 
		 readonly Ia_userServices _a_userServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_userController(Ia_userServices a_userServices)
        {
            _a_userServices = a_userServices;
        }
		/// <summary>
		/// api/a_user 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<a_user>> Get()
        {
            return await _a_userServices.Query();
        }

        /// <summary>
		/// api/a_user/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<a_user>> Get(int id)
        {
            return await _a_userServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/a_user post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] a_user a_user)
        {
			var data = new MessageModel<string>();

            var id = (await _a_userServices.Add(a_user));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/a_user put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] a_user a_user)
        {
			var data = new MessageModel<string>();
            if (a_user != null && a_user.ID > 0)
            {
                var id = (await _a_userServices.Update(a_user));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +a_user.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +a_user.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/a_user/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _a_userServices.DeleteById(id));
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

	
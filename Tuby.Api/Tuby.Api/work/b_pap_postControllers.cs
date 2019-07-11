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
	/// b_pap_postControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_pap_postController : ControllerBase
    { 
		 readonly Ib_pap_postServices _b_pap_postServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_pap_postController(Ib_pap_postServices b_pap_postServices)
        {
            _b_pap_postServices = b_pap_postServices;
        }
		/// <summary>
		/// api/b_pap_post 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_pap_post>> Get()
        {
            return await _b_pap_postServices.Query();
        }

        /// <summary>
		/// api/b_pap_post/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_pap_post>> Get(int id)
        {
            return await _b_pap_postServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_pap_post post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_pap_post b_pap_post)
        {
			var data = new MessageModel<string>();

            var id = (await _b_pap_postServices.Add(b_pap_post));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_pap_post put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_pap_post b_pap_post)
        {
			var data = new MessageModel<string>();
            if (b_pap_post != null && b_pap_post.ID > 0)
            {
                var id = (await _b_pap_postServices.Update(b_pap_post));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_pap_post.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_pap_post.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_pap_post/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_pap_postServices.DeleteById(id));
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

	
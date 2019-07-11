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
	/// b_zhd_architectureControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_zhd_architectureController : ControllerBase
    { 
		 readonly Ib_zhd_architectureServices _b_zhd_architectureServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_zhd_architectureController(Ib_zhd_architectureServices b_zhd_architectureServices)
        {
            _b_zhd_architectureServices = b_zhd_architectureServices;
        }
		/// <summary>
		/// api/b_zhd_architecture 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_zhd_architecture>> Get()
        {
            return await _b_zhd_architectureServices.Query();
        }

        /// <summary>
		/// api/b_zhd_architecture/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_zhd_architecture>> Get(int id)
        {
            return await _b_zhd_architectureServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_zhd_architecture post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_zhd_architecture b_zhd_architecture)
        {
			var data = new MessageModel<string>();

            var id = (await _b_zhd_architectureServices.Add(b_zhd_architecture));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_zhd_architecture put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_zhd_architecture b_zhd_architecture)
        {
			var data = new MessageModel<string>();
            if (b_zhd_architecture != null && b_zhd_architecture.ID > 0)
            {
                var id = (await _b_zhd_architectureServices.Update(b_zhd_architecture));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_zhd_architecture.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_zhd_architecture.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_zhd_architecture/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_zhd_architectureServices.DeleteById(id));
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

	
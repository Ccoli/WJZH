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
	/// b_education_levelControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_education_levelController : ControllerBase
    { 
		 readonly Ib_education_levelServices _b_education_levelServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_education_levelController(Ib_education_levelServices b_education_levelServices)
        {
            _b_education_levelServices = b_education_levelServices;
        }
		/// <summary>
		/// api/b_education_level 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_education_level>> Get()
        {
            return await _b_education_levelServices.Query();
        }

        /// <summary>
		/// api/b_education_level/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_education_level>> Get(int id)
        {
            return await _b_education_levelServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_education_level post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_education_level b_education_level)
        {
			var data = new MessageModel<string>();

            var id = (await _b_education_levelServices.Add(b_education_level));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_education_level put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_education_level b_education_level)
        {
			var data = new MessageModel<string>();
            if (b_education_level != null && b_education_level.ID > 0)
            {
                var id = (await _b_education_levelServices.Update(b_education_level));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_education_level.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_education_level.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_education_level/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_education_levelServices.DeleteById(id));
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

	
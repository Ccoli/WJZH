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
	/// d_shaowei_arrangeControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_shaowei_arrangeController : ControllerBase
    { 
		 readonly Id_shaowei_arrangeServices _d_shaowei_arrangeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_shaowei_arrangeController(Id_shaowei_arrangeServices d_shaowei_arrangeServices)
        {
            _d_shaowei_arrangeServices = d_shaowei_arrangeServices;
        }
		/// <summary>
		/// api/d_shaowei_arrange 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_shaowei_arrange>> Get()
        {
            return await _d_shaowei_arrangeServices.Query();
        }

        /// <summary>
		/// api/d_shaowei_arrange/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_shaowei_arrange>> Get(int id)
        {
            return await _d_shaowei_arrangeServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_shaowei_arrange post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_shaowei_arrange d_shaowei_arrange)
        {
			var data = new MessageModel<string>();

            var id = (await _d_shaowei_arrangeServices.Add(d_shaowei_arrange));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_shaowei_arrange put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_shaowei_arrange d_shaowei_arrange)
        {
			var data = new MessageModel<string>();
            if (d_shaowei_arrange != null && d_shaowei_arrange.ID > 0)
            {
                var id = (await _d_shaowei_arrangeServices.Update(d_shaowei_arrange));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_shaowei_arrange.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_shaowei_arrange.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_shaowei_arrange/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_shaowei_arrangeServices.DeleteById(id));
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

	
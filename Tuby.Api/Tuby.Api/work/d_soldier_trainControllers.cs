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
	/// d_soldier_trainControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_soldier_trainController : ControllerBase
    { 
		 readonly Id_soldier_trainServices _d_soldier_trainServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_soldier_trainController(Id_soldier_trainServices d_soldier_trainServices)
        {
            _d_soldier_trainServices = d_soldier_trainServices;
        }
		/// <summary>
		/// api/d_soldier_train 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_soldier_train>> Get()
        {
            return await _d_soldier_trainServices.Query();
        }

        /// <summary>
		/// api/d_soldier_train/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_soldier_train>> Get(int id)
        {
            return await _d_soldier_trainServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_soldier_train post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_soldier_train d_soldier_train)
        {
			var data = new MessageModel<string>();

            var id = (await _d_soldier_trainServices.Add(d_soldier_train));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_soldier_train put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_soldier_train d_soldier_train)
        {
			var data = new MessageModel<string>();
            if (d_soldier_train != null && d_soldier_train.ID > 0)
            {
                var id = (await _d_soldier_trainServices.Update(d_soldier_train));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_soldier_train.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_soldier_train.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_soldier_train/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_soldier_trainServices.DeleteById(id));
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

	
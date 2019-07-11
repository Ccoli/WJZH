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
	/// b_soldier_stateControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class b_soldier_stateController : ControllerBase
    { 
		 readonly Ib_soldier_stateServices _b_soldier_stateServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_soldier_stateController(Ib_soldier_stateServices b_soldier_stateServices)
        {
            _b_soldier_stateServices = b_soldier_stateServices;
        }
		/// <summary>
		/// api/b_soldier_state 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_soldier_state>> Get()
        {
            return await _b_soldier_stateServices.Query();
        }

        /// <summary>
		/// api/b_soldier_state/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_soldier_state>> Get(int id)
        {
            return await _b_soldier_stateServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/b_soldier_state post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_soldier_state b_soldier_state)
        {
			var data = new MessageModel<string>();

            var id = (await _b_soldier_stateServices.Add(b_soldier_state));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/b_soldier_state put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] b_soldier_state b_soldier_state)
        {
			var data = new MessageModel<string>();
            if (b_soldier_state != null && b_soldier_state.ID > 0)
            {
                var id = (await _b_soldier_stateServices.Update(b_soldier_state));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_soldier_state.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_soldier_state.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/b_soldier_state/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _b_soldier_stateServices.DeleteById(id));
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

	
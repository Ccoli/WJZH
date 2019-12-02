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
	/// ar_usergroup_data_accessControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class ar_usergroup_data_accessController : ControllerBase
    { 
		 readonly Iar_usergroup_data_accessServices _ar_usergroup_data_accessServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public ar_usergroup_data_accessController(Iar_usergroup_data_accessServices ar_usergroup_data_accessServices)
        {
            _ar_usergroup_data_accessServices = ar_usergroup_data_accessServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<ar_usergroup_data_access>> Get()
        {
            return await _ar_usergroup_data_accessServices.Query();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<ar_usergroup_data_access>> GetPage(int page)
        {
            return await _ar_usergroup_data_accessServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<ar_usergroup_data_access>> Get(int id)
        {
            return await _ar_usergroup_data_accessServices.Query(c => c.DataAccessID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] ar_usergroup_data_access ar_usergroup_data_access)
        {
			var data = new MessageModel<string>();

            var id = (await _ar_usergroup_data_accessServices.Add(ar_usergroup_data_access));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		///更新数据
		/// </summary>
        [HttpPost]
        [Route("update")]
        public async Task<MessageModel<string>> Update([FromBody] ar_usergroup_data_access ar_usergroup_data_access)
        {
			var data = new MessageModel<string>();
            if (ar_usergroup_data_access != null && ar_usergroup_data_access.DataAccessID > 0)
            {
                var id = (await _ar_usergroup_data_accessServices.Update(ar_usergroup_data_access));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +ar_usergroup_data_access.DataAccessID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +ar_usergroup_data_access.DataAccessID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// 根据id使用get方法删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _ar_usergroup_data_accessServices.DeleteById(id));
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

		/// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletemuch")]
        public async Task<MessageModel<string>> DeleteMuch([FromBody] object[] id)
        {
            var flag = (await _ar_usergroup_data_accessServices.DeleteByIds(id));
            var data = new MessageModel<string>();
            data.success = flag;
            if (flag)
            {
                data.response = string.Join(",", id) + "数据删除";
                data.msg = "删除成功";
            }
            else
            {
                data.response = "id为" + id.ToString() + "的数据找不到";
                data.msg = "删除失败";
            }

            return data;
        }
    }
}

	
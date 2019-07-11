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
	/// ar_usergroup_ui_accessControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class ar_usergroup_ui_accessController : ControllerBase
    { 
		 readonly Iar_usergroup_ui_accessServices _ar_usergroup_ui_accessServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public ar_usergroup_ui_accessController(Iar_usergroup_ui_accessServices ar_usergroup_ui_accessServices)
        {
            _ar_usergroup_ui_accessServices = ar_usergroup_ui_accessServices;
        }
		/// <summary>
		/// api/ar_usergroup_ui_access 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<ar_usergroup_ui_access>> Get()
        {
            return await _ar_usergroup_ui_accessServices.Query();
        }

        /// <summary>
		/// api/ar_usergroup_ui_access/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<ar_usergroup_ui_access>> Get(int id)
        {
            return await _ar_usergroup_ui_accessServices.Query(c => c.UserGroupID == id);
        }

        /// <summary>
		/// api/ar_usergroup_ui_access post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] ar_usergroup_ui_access ar_usergroup_ui_access)
        {
			var data = new MessageModel<string>();

            var id = (await _ar_usergroup_ui_accessServices.Add(ar_usergroup_ui_access));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/ar_usergroup_ui_access put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] ar_usergroup_ui_access ar_usergroup_ui_access)
        {
			var data = new MessageModel<string>();
            if (ar_usergroup_ui_access != null && ar_usergroup_ui_access.UserGroupID > 0)
            {
                var id = (await _ar_usergroup_ui_accessServices.Update(ar_usergroup_ui_access));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +ar_usergroup_ui_access.UserGroupID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +ar_usergroup_ui_access.UserGroupID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/ar_usergroup_ui_access/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _ar_usergroup_ui_accessServices.DeleteById(id));
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

	
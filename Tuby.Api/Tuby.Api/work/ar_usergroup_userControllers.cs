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
	/// ar_usergroup_userControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class ar_usergroup_userController : ControllerBase
    { 
		 readonly Iar_usergroup_userServices _ar_usergroup_userServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public ar_usergroup_userController(Iar_usergroup_userServices ar_usergroup_userServices)
        {
            _ar_usergroup_userServices = ar_usergroup_userServices;
        }
		/// <summary>
		/// api/ar_usergroup_user 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<ar_usergroup_user>> Get()
        {
            return await _ar_usergroup_userServices.Query();
        }

        /// <summary>
		/// api/ar_usergroup_user/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<ar_usergroup_user>> Get(int id)
        {
            return await _ar_usergroup_userServices.Query(c => c.UserGroupID == id);
        }

        /// <summary>
		/// api/ar_usergroup_user post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] ar_usergroup_user ar_usergroup_user)
        {
			var data = new MessageModel<string>();

            var id = (await _ar_usergroup_userServices.Add(ar_usergroup_user));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/ar_usergroup_user put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] ar_usergroup_user ar_usergroup_user)
        {
			var data = new MessageModel<string>();
            if (ar_usergroup_user != null && ar_usergroup_user.UserGroupID > 0)
            {
                var id = (await _ar_usergroup_userServices.Update(ar_usergroup_user));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +ar_usergroup_user.UserGroupID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +ar_usergroup_user.UserGroupID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/ar_usergroup_user/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _ar_usergroup_userServices.DeleteById(id));
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

	
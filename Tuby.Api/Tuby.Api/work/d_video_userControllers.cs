using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_video_userControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    [AllowAnonymous]
    public class d_video_userController : ControllerBase
    { 
		 readonly Id_video_userServices _d_video_userServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_video_userController(Id_video_userServices d_video_userServices)
        {
            _d_video_userServices = d_video_userServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_video_user>> Get()
        {
            return await _d_video_userServices.Query();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<d_video_user>> GetPage(int page)
        {
            return await _d_video_userServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_video_user>> Get(int id)
        {
            return await _d_video_userServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_video_user d_video_user)
        {
			var data = new MessageModel<string>();

            var id = (await _d_video_userServices.Add(d_video_user));
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
        public async Task<MessageModel<string>> Update([FromBody] d_video_user d_video_user)
        {
			var data = new MessageModel<string>();
            if (d_video_user != null && d_video_user.ID > 0)
            {
                var id = (await _d_video_userServices.Update(d_video_user));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_video_user.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_video_user.ID.ToString() + "的数据不存在";
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
            var flag = (await _d_video_userServices.DeleteById(id));
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
            var flag = (await _d_video_userServices.DeleteByIds(id));
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

	
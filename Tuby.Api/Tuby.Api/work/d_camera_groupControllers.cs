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
	/// d_camera_groupControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_camera_groupController : ControllerBase
    { 
		 readonly Id_camera_groupServices _d_camera_groupServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_camera_groupController(Id_camera_groupServices d_camera_groupServices)
        {
            _d_camera_groupServices = d_camera_groupServices;
        }
		/// <summary>
		/// api/d_camera_group 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_camera_group>> Get()
        {
            return await _d_camera_groupServices.Query();
        }

        /// <summary>
		/// api/d_camera_group/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_camera_group>> Get(int id)
        {
            return await _d_camera_groupServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_camera_group post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_camera_group d_camera_group)
        {
			var data = new MessageModel<string>();

            var id = (await _d_camera_groupServices.Add(d_camera_group));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_camera_group put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_camera_group d_camera_group)
        {
			var data = new MessageModel<string>();
            if (d_camera_group != null && d_camera_group.ID > 0)
            {
                var id = (await _d_camera_groupServices.Update(d_camera_group));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_camera_group.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_camera_group.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_camera_group/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_camera_groupServices.DeleteById(id));
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

	
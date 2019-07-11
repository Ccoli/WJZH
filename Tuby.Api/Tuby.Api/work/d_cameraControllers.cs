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
	/// d_cameraControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_cameraController : ControllerBase
    { 
		 readonly Id_cameraServices _d_cameraServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_cameraController(Id_cameraServices d_cameraServices)
        {
            _d_cameraServices = d_cameraServices;
        }
		/// <summary>
		/// api/d_camera 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_camera>> Get()
        {
            return await _d_cameraServices.Query();
        }

        /// <summary>
		/// api/d_camera/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_camera>> Get(int id)
        {
            return await _d_cameraServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_camera post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_camera d_camera)
        {
			var data = new MessageModel<string>();

            var id = (await _d_cameraServices.Add(d_camera));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_camera put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_camera d_camera)
        {
			var data = new MessageModel<string>();
            if (d_camera != null && d_camera.ID > 0)
            {
                var id = (await _d_cameraServices.Update(d_camera));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_camera.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_camera.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_camera/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_cameraServices.DeleteById(id));
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

	
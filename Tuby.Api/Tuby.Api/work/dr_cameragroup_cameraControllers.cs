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
	/// dr_cameragroup_cameraControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class dr_cameragroup_cameraController : ControllerBase
    { 
		 readonly Idr_cameragroup_cameraServices _dr_cameragroup_cameraServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public dr_cameragroup_cameraController(Idr_cameragroup_cameraServices dr_cameragroup_cameraServices)
        {
            _dr_cameragroup_cameraServices = dr_cameragroup_cameraServices;
        }
		/// <summary>
		/// api/dr_cameragroup_camera 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<dr_cameragroup_camera>> Get()
        {
            return await _dr_cameragroup_cameraServices.Query();
        }

        /// <summary>
		/// api/dr_cameragroup_camera/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<dr_cameragroup_camera>> Get(int id)
        {
            return await _dr_cameragroup_cameraServices.Query(c => c.CameraGroupID == id);
        }

        /// <summary>
		/// api/dr_cameragroup_camera post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] dr_cameragroup_camera dr_cameragroup_camera)
        {
			var data = new MessageModel<string>();

            var id = (await _dr_cameragroup_cameraServices.Add(dr_cameragroup_camera));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/dr_cameragroup_camera put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] dr_cameragroup_camera dr_cameragroup_camera)
        {
			var data = new MessageModel<string>();
            if (dr_cameragroup_camera != null && dr_cameragroup_camera.CameraGroupID > 0)
            {
                var id = (await _dr_cameragroup_cameraServices.Update(dr_cameragroup_camera));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +dr_cameragroup_camera.CameraGroupID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +dr_cameragroup_camera.CameraGroupID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/dr_cameragroup_camera/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _dr_cameragroup_cameraServices.DeleteById(id));
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

	
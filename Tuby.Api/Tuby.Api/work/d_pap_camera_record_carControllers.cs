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
	/// d_pap_camera_record_carControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_camera_record_carController : ControllerBase
    { 
		 readonly Id_pap_camera_record_carServices _d_pap_camera_record_carServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_camera_record_carController(Id_pap_camera_record_carServices d_pap_camera_record_carServices)
        {
            _d_pap_camera_record_carServices = d_pap_camera_record_carServices;
        }
		/// <summary>
		/// api/d_pap_camera_record_car 查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_camera_record_car>> Get()
        {
            return await _d_pap_camera_record_carServices.Query();
        }

        /// <summary>
		/// api/d_pap_camera_record_car/{id} 根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_camera_record_car>> Get(int id)
        {
            return await _d_pap_camera_record_carServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// api/d_pap_camera_record_car post添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_camera_record_car d_pap_camera_record_car)
        {
			var data = new MessageModel<string>();

            var id = (await _d_pap_camera_record_carServices.Add(d_pap_camera_record_car));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		/// api/d_pap_camera_record_car put更新数据
		/// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_camera_record_car d_pap_camera_record_car)
        {
			var data = new MessageModel<string>();
            if (d_pap_camera_record_car != null && d_pap_camera_record_car.ID > 0)
            {
                var id = (await _d_pap_camera_record_carServices.Update(d_pap_camera_record_car));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_camera_record_car.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_camera_record_car.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// api/d_pap_camera_record_car/delete get删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var flag = (await _d_pap_camera_record_carServices.DeleteById(id));
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

	
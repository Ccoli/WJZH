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


		 [HttpGet]
        public async Task<List<d_pap_camera_record_car>> Get()
        {
            return await _d_pap_camera_record_carServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_camera_record_car>> Get(int id)
        {
            return await _d_pap_camera_record_carServices.Query(c => c.ID == id);
        }

        // POST: api/a_department
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/a_department/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

	
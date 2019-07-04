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
	/// b_camera_usage_groupControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_camera_usage_groupController : ControllerBase
    { 
		 readonly Ib_camera_usage_groupServices _b_camera_usage_groupServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_camera_usage_groupController(Ib_camera_usage_groupServices b_camera_usage_groupServices)
        {
            _b_camera_usage_groupServices = b_camera_usage_groupServices;
        }


		 [HttpGet]
        public async Task<List<b_camera_usage_group>> Get()
        {
            return await _b_camera_usage_groupServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_camera_usage_group>> Get(int id)
        {
            return await _b_camera_usage_groupServices.Query(c => c.ID == id);
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

	
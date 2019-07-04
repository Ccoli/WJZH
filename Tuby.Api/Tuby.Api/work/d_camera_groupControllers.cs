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


		 [HttpGet]
        public async Task<List<d_camera_group>> Get()
        {
            return await _d_camera_groupServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_camera_group>> Get(int id)
        {
            return await _d_camera_groupServices.Query(c => c.ID == id);
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

	
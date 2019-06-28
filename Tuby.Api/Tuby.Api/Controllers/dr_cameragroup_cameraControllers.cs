using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.Services;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// dr_cameragroup_cameraControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class dr_cameragroup_cameraController : ControllerBase
    { 
		 Idr_cameragroup_cameraServices dr_cameragroup_cameraServices=new dr_cameragroup_cameraServices();
		 [HttpGet]
        public async Task<List<dr_cameragroup_camera>> Get()
        {
            return await dr_cameragroup_cameraServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<dr_cameragroup_camera>> Get(int id)
        {
            return await dr_cameragroup_cameraServices.Query(c => c.CameraID == id);
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

	
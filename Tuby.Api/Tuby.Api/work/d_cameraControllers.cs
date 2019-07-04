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


		 [HttpGet]
        public async Task<List<d_camera>> Get()
        {
            return await _d_cameraServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_camera>> Get(int id)
        {
            return await _d_cameraServices.Query(c => c.ID == id);
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

	
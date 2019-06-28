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
	/// d_shaoweiControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_shaoweiController : ControllerBase
    { 
		 Id_shaoweiServices d_shaoweiServices=new d_shaoweiServices();
		 [HttpGet]
        public async Task<List<d_shaowei>> Get()
        {
            return await d_shaoweiServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_shaowei>> Get(int id)
        {
            return await d_shaoweiServices.Query(c => c.ID == id);
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

	
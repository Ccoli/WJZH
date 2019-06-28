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
	/// d_soldier_treatmentControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_soldier_treatmentController : ControllerBase
    { 
		 Id_soldier_treatmentServices d_soldier_treatmentServices=new d_soldier_treatmentServices();
		 [HttpGet]
        public async Task<List<d_soldier_treatment>> Get()
        {
            return await d_soldier_treatmentServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_soldier_treatment>> Get(int id)
        {
            return await d_soldier_treatmentServices.Query(c => c.ID == id);
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

	
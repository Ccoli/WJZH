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
	/// b_device_usageControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_device_usageController : ControllerBase
    { 
		 Ib_device_usageServices b_device_usageServices=new b_device_usageServices();
		 [HttpGet]
        public async Task<List<b_device_usage>> Get()
        {
            return await b_device_usageServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_device_usage>> Get(int id)
        {
            return await b_device_usageServices.Query(c => c.ID == id);
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

	
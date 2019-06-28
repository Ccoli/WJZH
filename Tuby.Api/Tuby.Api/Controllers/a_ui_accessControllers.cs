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
	/// a_ui_accessControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class a_ui_accessController : ControllerBase
    { 
		 Ia_ui_accessServices a_ui_accessServices=new a_ui_accessServices();
		 [HttpGet]
        public async Task<List<a_ui_access>> Get()
        {
            return await a_ui_accessServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<a_ui_access>> Get(int id)
        {
            return await a_ui_accessServices.Query(c => c.ID == id);
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

	
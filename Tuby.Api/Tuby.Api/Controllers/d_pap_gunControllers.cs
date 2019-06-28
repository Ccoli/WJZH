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
	/// d_pap_gunControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_gunController : ControllerBase
    { 
		 Id_pap_gunServices d_pap_gunServices=new d_pap_gunServices();
		 [HttpGet]
        public async Task<List<d_pap_gun>> Get()
        {
            return await d_pap_gunServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_gun>> Get(int id)
        {
            return await d_pap_gunServices.Query(c => c.ID == id);
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

	
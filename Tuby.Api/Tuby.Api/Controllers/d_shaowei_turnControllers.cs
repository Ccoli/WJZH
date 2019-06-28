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
	/// d_shaowei_turnControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_shaowei_turnController : ControllerBase
    { 
		 Id_shaowei_turnServices d_shaowei_turnServices=new d_shaowei_turnServices();
		 [HttpGet]
        public async Task<List<d_shaowei_turn>> Get()
        {
            return await d_shaowei_turnServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_shaowei_turn>> Get(int id)
        {
            return await d_shaowei_turnServices.Query(c => c.ID == id);
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

	
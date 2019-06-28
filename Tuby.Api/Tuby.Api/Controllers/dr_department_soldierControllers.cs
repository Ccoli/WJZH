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
	/// dr_department_soldierControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class dr_department_soldierController : ControllerBase
    { 
		 Idr_department_soldierServices dr_department_soldierServices=new dr_department_soldierServices();
		 [HttpGet]
        public async Task<List<dr_department_soldier>> Get()
        {
            return await dr_department_soldierServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<dr_department_soldier>> Get(int id)
        {
            return await dr_department_soldierServices.Query(c => c.SoldierID == id);
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

	
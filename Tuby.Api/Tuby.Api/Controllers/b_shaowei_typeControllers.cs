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
	/// b_shaowei_typeControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_shaowei_typeController : ControllerBase
    { 
		 Ib_shaowei_typeServices b_shaowei_typeServices=new b_shaowei_typeServices();
		 [HttpGet]
        public async Task<List<b_shaowei_type>> Get()
        {
            return await b_shaowei_typeServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_shaowei_type>> Get(int id)
        {
            return await b_shaowei_typeServices.Query(c => c.ID == id);
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

	
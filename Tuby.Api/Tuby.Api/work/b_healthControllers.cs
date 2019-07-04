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
	/// b_healthControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_healthController : ControllerBase
    { 
		 readonly Ib_healthServices _b_healthServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_healthController(Ib_healthServices b_healthServices)
        {
            _b_healthServices = b_healthServices;
        }


		 [HttpGet]
        public async Task<List<b_health>> Get()
        {
            return await _b_healthServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_health>> Get(int id)
        {
            return await _b_healthServices.Query(c => c.ID == id);
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

	
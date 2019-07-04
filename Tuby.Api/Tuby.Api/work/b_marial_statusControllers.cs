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
	/// b_marial_statusControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_marial_statusController : ControllerBase
    { 
		 readonly Ib_marial_statusServices _b_marial_statusServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_marial_statusController(Ib_marial_statusServices b_marial_statusServices)
        {
            _b_marial_statusServices = b_marial_statusServices;
        }


		 [HttpGet]
        public async Task<List<b_marial_status>> Get()
        {
            return await _b_marial_statusServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_marial_status>> Get(int id)
        {
            return await _b_marial_statusServices.Query(c => c.ID == id);
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

	
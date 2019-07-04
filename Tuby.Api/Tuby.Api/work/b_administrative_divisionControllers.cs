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
	/// b_administrative_divisionControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_administrative_divisionController : ControllerBase
    { 
		 readonly Ib_administrative_divisionServices _b_administrative_divisionServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_administrative_divisionController(Ib_administrative_divisionServices b_administrative_divisionServices)
        {
            _b_administrative_divisionServices = b_administrative_divisionServices;
        }


		 [HttpGet]
        public async Task<List<b_administrative_division>> Get()
        {
            return await _b_administrative_divisionServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_administrative_division>> Get(int id)
        {
            return await _b_administrative_divisionServices.Query(c => c.ID == id);
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

	
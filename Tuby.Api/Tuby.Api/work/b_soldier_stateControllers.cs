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
	/// b_soldier_stateControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_soldier_stateController : ControllerBase
    { 
		 readonly Ib_soldier_stateServices _b_soldier_stateServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_soldier_stateController(Ib_soldier_stateServices b_soldier_stateServices)
        {
            _b_soldier_stateServices = b_soldier_stateServices;
        }


		 [HttpGet]
        public async Task<List<b_soldier_state>> Get()
        {
            return await _b_soldier_stateServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_soldier_state>> Get(int id)
        {
            return await _b_soldier_stateServices.Query(c => c.ID == id);
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

	
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
	/// d_soldier_leaveControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_soldier_leaveController : ControllerBase
    { 
		 readonly Id_soldier_leaveServices _d_soldier_leaveServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_soldier_leaveController(Id_soldier_leaveServices d_soldier_leaveServices)
        {
            _d_soldier_leaveServices = d_soldier_leaveServices;
        }


		 [HttpGet]
        public async Task<List<d_soldier_leave>> Get()
        {
            return await _d_soldier_leaveServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_soldier_leave>> Get(int id)
        {
            return await _d_soldier_leaveServices.Query(c => c.ID == id);
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

	
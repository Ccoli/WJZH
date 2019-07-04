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
	/// b_leave_reasonControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_leave_reasonController : ControllerBase
    { 
		 readonly Ib_leave_reasonServices _b_leave_reasonServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_leave_reasonController(Ib_leave_reasonServices b_leave_reasonServices)
        {
            _b_leave_reasonServices = b_leave_reasonServices;
        }


		 [HttpGet]
        public async Task<List<b_leave_reason>> Get()
        {
            return await _b_leave_reasonServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_leave_reason>> Get(int id)
        {
            return await _b_leave_reasonServices.Query(c => c.ID == id);
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

	
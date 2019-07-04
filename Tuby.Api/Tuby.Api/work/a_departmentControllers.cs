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
	/// a_departmentControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class a_departmentController : ControllerBase
    { 
		 readonly Ia_departmentServices _a_departmentServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_departmentController(Ia_departmentServices a_departmentServices)
        {
            _a_departmentServices = a_departmentServices;
        }


		 [HttpGet]
        public async Task<List<a_department>> Get()
        {
            return await _a_departmentServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<a_department>> Get(int id)
        {
            return await _a_departmentServices.Query(c => c.ID == id);
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

	
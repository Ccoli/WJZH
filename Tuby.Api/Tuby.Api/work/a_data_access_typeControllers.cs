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
	/// a_data_access_typeControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class a_data_access_typeController : ControllerBase
    { 
		 readonly Ia_data_access_typeServices _a_data_access_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_data_access_typeController(Ia_data_access_typeServices a_data_access_typeServices)
        {
            _a_data_access_typeServices = a_data_access_typeServices;
        }


		 [HttpGet]
        public async Task<List<a_data_access_type>> Get()
        {
            return await _a_data_access_typeServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<a_data_access_type>> Get(int id)
        {
            return await _a_data_access_typeServices.Query(c => c.ID == id);
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

	
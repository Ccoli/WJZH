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
	/// b_phone_table_typeControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_phone_table_typeController : ControllerBase
    { 
		 readonly Ib_phone_table_typeServices _b_phone_table_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_phone_table_typeController(Ib_phone_table_typeServices b_phone_table_typeServices)
        {
            _b_phone_table_typeServices = b_phone_table_typeServices;
        }


		 [HttpGet]
        public async Task<List<b_phone_table_type>> Get()
        {
            return await _b_phone_table_typeServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_phone_table_type>> Get(int id)
        {
            return await _b_phone_table_typeServices.Query(c => c.ID == id);
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

	
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
	/// d_phone_tableControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_phone_tableController : ControllerBase
    { 
		 readonly Id_phone_tableServices _d_phone_tableServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_phone_tableController(Id_phone_tableServices d_phone_tableServices)
        {
            _d_phone_tableServices = d_phone_tableServices;
        }


		 [HttpGet]
        public async Task<List<d_phone_table>> Get()
        {
            return await _d_phone_tableServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_phone_table>> Get(int id)
        {
            return await _d_phone_tableServices.Query(c => c.ID == id);
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

	
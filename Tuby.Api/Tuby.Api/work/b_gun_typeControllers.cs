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
	/// b_gun_typeControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_gun_typeController : ControllerBase
    { 
		 readonly Ib_gun_typeServices _b_gun_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_gun_typeController(Ib_gun_typeServices b_gun_typeServices)
        {
            _b_gun_typeServices = b_gun_typeServices;
        }


		 [HttpGet]
        public async Task<List<b_gun_type>> Get()
        {
            return await _b_gun_typeServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_gun_type>> Get(int id)
        {
            return await _b_gun_typeServices.Query(c => c.ID == id);
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

	
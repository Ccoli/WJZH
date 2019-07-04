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
	/// b_target_people_typeControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_target_people_typeController : ControllerBase
    { 
		 readonly Ib_target_people_typeServices _b_target_people_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_target_people_typeController(Ib_target_people_typeServices b_target_people_typeServices)
        {
            _b_target_people_typeServices = b_target_people_typeServices;
        }


		 [HttpGet]
        public async Task<List<b_target_people_type>> Get()
        {
            return await _b_target_people_typeServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_target_people_type>> Get(int id)
        {
            return await _b_target_people_typeServices.Query(c => c.ID == id);
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

	
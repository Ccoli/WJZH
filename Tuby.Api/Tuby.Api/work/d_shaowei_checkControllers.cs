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
	/// d_shaowei_checkControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_shaowei_checkController : ControllerBase
    { 
		 readonly Id_shaowei_checkServices _d_shaowei_checkServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_shaowei_checkController(Id_shaowei_checkServices d_shaowei_checkServices)
        {
            _d_shaowei_checkServices = d_shaowei_checkServices;
        }


		 [HttpGet]
        public async Task<List<d_shaowei_check>> Get()
        {
            return await _d_shaowei_checkServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_shaowei_check>> Get(int id)
        {
            return await _d_shaowei_checkServices.Query(c => c.ID == id);
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

	
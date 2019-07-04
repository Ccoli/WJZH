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
	/// a_userControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class a_userController : ControllerBase
    { 
		 readonly Ia_userServices _a_userServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_userController(Ia_userServices a_userServices)
        {
            _a_userServices = a_userServices;
        }


		 [HttpGet]
        public async Task<List<a_user>> Get()
        {
            return await _a_userServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<a_user>> Get(int id)
        {
            return await _a_userServices.Query(c => c.ID == id);
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

	
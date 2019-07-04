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
	/// ar_usergroup_data_accessControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class ar_usergroup_data_accessController : ControllerBase
    { 
		 readonly Iar_usergroup_data_accessServices _ar_usergroup_data_accessServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public ar_usergroup_data_accessController(Iar_usergroup_data_accessServices ar_usergroup_data_accessServices)
        {
            _ar_usergroup_data_accessServices = ar_usergroup_data_accessServices;
        }


		 [HttpGet]
        public async Task<List<ar_usergroup_data_access>> Get()
        {
            return await _ar_usergroup_data_accessServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<ar_usergroup_data_access>> Get(int id)
        {
            return await _ar_usergroup_data_accessServices.Query(c => c.UserGroupID == id);
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

	
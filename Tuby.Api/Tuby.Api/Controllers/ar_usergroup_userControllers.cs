using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.Services;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// ar_usergroup_userControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class ar_usergroup_userController : ControllerBase
    { 
		 Iar_usergroup_userServices ar_usergroup_userServices=new ar_usergroup_userServices();
		 [HttpGet]
        public async Task<List<ar_usergroup_user>> Get()
        {
            return await ar_usergroup_userServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<ar_usergroup_user>> Get(int id)
        {
            return await ar_usergroup_userServices.Query(c => c.UserID == id);
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

	
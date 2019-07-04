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
	/// d_pap_arsenalControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_arsenalController : ControllerBase
    { 
		 readonly Id_pap_arsenalServices _d_pap_arsenalServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_arsenalController(Id_pap_arsenalServices d_pap_arsenalServices)
        {
            _d_pap_arsenalServices = d_pap_arsenalServices;
        }


		 [HttpGet]
        public async Task<List<d_pap_arsenal>> Get()
        {
            return await _d_pap_arsenalServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_arsenal>> Get(int id)
        {
            return await _d_pap_arsenalServices.Query(c => c.ID == id);
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

	
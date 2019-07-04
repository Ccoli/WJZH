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
	/// d_pap_equipmentControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_equipmentController : ControllerBase
    { 
		 readonly Id_pap_equipmentServices _d_pap_equipmentServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_equipmentController(Id_pap_equipmentServices d_pap_equipmentServices)
        {
            _d_pap_equipmentServices = d_pap_equipmentServices;
        }


		 [HttpGet]
        public async Task<List<d_pap_equipment>> Get()
        {
            return await _d_pap_equipmentServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_equipment>> Get(int id)
        {
            return await _d_pap_equipmentServices.Query(c => c.ID == id);
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

	
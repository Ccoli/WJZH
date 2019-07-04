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
	/// d_pap_car_maintainControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_car_maintainController : ControllerBase
    { 
		 readonly Id_pap_car_maintainServices _d_pap_car_maintainServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_car_maintainController(Id_pap_car_maintainServices d_pap_car_maintainServices)
        {
            _d_pap_car_maintainServices = d_pap_car_maintainServices;
        }


		 [HttpGet]
        public async Task<List<d_pap_car_maintain>> Get()
        {
            return await _d_pap_car_maintainServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_car_maintain>> Get(int id)
        {
            return await _d_pap_car_maintainServices.Query(c => c.ID == id);
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

	
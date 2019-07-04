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
	/// d_pap_car_leaveControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_pap_car_leaveController : ControllerBase
    { 
		 readonly Id_pap_car_leaveServices _d_pap_car_leaveServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_car_leaveController(Id_pap_car_leaveServices d_pap_car_leaveServices)
        {
            _d_pap_car_leaveServices = d_pap_car_leaveServices;
        }


		 [HttpGet]
        public async Task<List<d_pap_car_leave>> Get()
        {
            return await _d_pap_car_leaveServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_pap_car_leave>> Get(int id)
        {
            return await _d_pap_car_leaveServices.Query(c => c.ID == id);
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

	
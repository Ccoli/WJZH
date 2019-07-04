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
	/// d_alarm_deviceControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class d_alarm_deviceController : ControllerBase
    { 
		 readonly Id_alarm_deviceServices _d_alarm_deviceServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_deviceController(Id_alarm_deviceServices d_alarm_deviceServices)
        {
            _d_alarm_deviceServices = d_alarm_deviceServices;
        }


		 [HttpGet]
        public async Task<List<d_alarm_device>> Get()
        {
            return await _d_alarm_deviceServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<d_alarm_device>> Get(int id)
        {
            return await _d_alarm_deviceServices.Query(c => c.ID == id);
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

	
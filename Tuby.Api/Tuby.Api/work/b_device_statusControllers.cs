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
	/// b_device_statusControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_device_statusController : ControllerBase
    { 
		 readonly Ib_device_statusServices _b_device_statusServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_device_statusController(Ib_device_statusServices b_device_statusServices)
        {
            _b_device_statusServices = b_device_statusServices;
        }


		 [HttpGet]
        public async Task<List<b_device_status>> Get()
        {
            return await _b_device_statusServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_device_status>> Get(int id)
        {
            return await _b_device_statusServices.Query(c => c.ID == id);
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

	
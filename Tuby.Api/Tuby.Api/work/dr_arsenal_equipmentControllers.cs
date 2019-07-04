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
	/// dr_arsenal_equipmentControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class dr_arsenal_equipmentController : ControllerBase
    { 
		 readonly Idr_arsenal_equipmentServices _dr_arsenal_equipmentServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public dr_arsenal_equipmentController(Idr_arsenal_equipmentServices dr_arsenal_equipmentServices)
        {
            _dr_arsenal_equipmentServices = dr_arsenal_equipmentServices;
        }


		 [HttpGet]
        public async Task<List<dr_arsenal_equipment>> Get()
        {
            return await _dr_arsenal_equipmentServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<dr_arsenal_equipment>> Get(int id)
        {
            return await _dr_arsenal_equipmentServices.Query(c => c.ArsenalID == id);
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

	
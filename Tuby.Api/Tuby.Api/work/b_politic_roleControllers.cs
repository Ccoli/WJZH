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
	/// b_politic_roleControllers
	/// </summary>	
	[Route("api/[controller]")]
    [ApiController]
	public class b_politic_roleController : ControllerBase
    { 
		 readonly Ib_politic_roleServices _b_politic_roleServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_politic_roleController(Ib_politic_roleServices b_politic_roleServices)
        {
            _b_politic_roleServices = b_politic_roleServices;
        }


		 [HttpGet]
        public async Task<List<b_politic_role>> Get()
        {
            return await _b_politic_roleServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<b_politic_role>> Get(int id)
        {
            return await _b_politic_roleServices.Query(c => c.ID == id);
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

	
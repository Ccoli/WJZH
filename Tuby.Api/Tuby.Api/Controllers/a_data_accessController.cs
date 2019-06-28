using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Services;

namespace Tuby.Api.Controllers
{
    /// <summary>
    /// a_data_access
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class a_data_accessController : ControllerBase
    {
        Ia_data_accessServices a_data_accessServices = new a_data_accessServices();
        // GET: api/a_data_access
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<a_data_access>> Get()
        {
            return await a_data_accessServices.Query();
        }

        // GET: api/a_data_access/5
        [HttpGet("{id}")]
        public async Task<List<a_data_access>> Get(int id)
        {
            return await a_data_accessServices.Query(c => c.ID == id);
        }

        // POST: api/a_data_access
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/a_data_access/5
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

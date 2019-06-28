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
    [Route("api/[controller]")]
    [ApiController]
    public class a_data_access_typeController : ControllerBase
    {
        Ia_data_access_typeServices a_data_access_typeServices = new a_data_access_typeServices();
        // GET: api/a_data_access_type
        [HttpGet]
        public async Task<List<a_data_access_type>> Get()
        {
            return   await a_data_access_typeServices.Query(); ;
        }

        // GET: api/a_data_access_type/5
        [HttpGet("{id}")]
        public async Task<List<a_data_access_type>> Get(int id)
        {
            return await a_data_access_typeServices.Query(c => c.ID == id);
        }

        // POST: api/a_data_access_type
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/a_data_access_type/5
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

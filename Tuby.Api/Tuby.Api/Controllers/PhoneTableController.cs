using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneTableController : ControllerBase
    {
        readonly IPhoneTableServices _PhoneTableServices;

        public PhoneTableController(IPhoneTableServices PhoneTableServices)
        {
            _PhoneTableServices = PhoneTableServices;
        }
        // GET: api/PhoneTable
        [HttpGet]
        public async Task<List<PhoneTableView>> Get()
        {
            return await _PhoneTableServices.QueryMuchTable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class LeaveRecordController : ControllerBase
    {
        readonly ILeaveRecordServices _LeaveRecordServices;

        public LeaveRecordController(ILeaveRecordServices LeaveRecordServices)
        {
            _LeaveRecordServices = LeaveRecordServices;
        }
        // GET: api/LeaveRecord
        [HttpGet]
        public async Task<List<LeaveRecordView>> Get()
        {
            return await _LeaveRecordServices.QueryMuchTable();
        }
    }
}

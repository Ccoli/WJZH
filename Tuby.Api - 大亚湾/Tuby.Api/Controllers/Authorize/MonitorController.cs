﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.Common.Helper;
using Tuby.Api.Common.LogHelper;
using Tuby.Api.Hubs;
using Tuby.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Tuby.Api.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class MonitorController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MonitorController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>
        /// SignalR send data
        /// </summary>
        /// <returns></returns>
        // GET: api/Logs
        [HttpGet]
        public MessageModel<List<LogInfo>> Get()
        {

            _hubContext.Clients.All.SendAsync("ReceiveUpdate", LogLock.GetLogData()).Wait();

            return new MessageModel<List<LogInfo>>()
            {
                msg = "获取成功",
                success = true,
                response = null
            };
        }

        // GET: api/Logs/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Logs
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Logs/5
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

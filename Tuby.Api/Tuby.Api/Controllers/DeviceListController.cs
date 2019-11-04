using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class DeviceListController : ControllerBase
    {
        readonly IDeviceListServices _DeviceListServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public DeviceListController(IDeviceListServices DeviceListServices)
        {
            _DeviceListServices = DeviceListServices;
        }
        // GET: api/DeviceList
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<NodeData>> GetAsync()
        {
            return await _DeviceListServices.GetListData();
        }
    }
}

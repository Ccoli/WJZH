using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    [AllowAnonymous]
    public class AlarmBusinessViewController : ControllerBase
    {
        readonly IAlarmBusinessViewServices _AlarmBusinessViewServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AlarmBusinessViewController(IAlarmBusinessViewServices AlarmBusinessViewServices)
        {
            _AlarmBusinessViewServices = AlarmBusinessViewServices;
        }

        /// <summary>
        /// 获取所以信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AlarmBusinessView>> GetPage()
        {
            var list = await _AlarmBusinessViewServices.QueryMuchTable();
            return list;
        }
        // GET: api/AlarmInfo
        /// <summary>
        /// 根据主题获取信息
        /// </summary>
        ///  <param name="name">主题</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getname")]
        public async Task<List<AlarmBusinessView>> GetPage(string name)
        {
            var list = await _AlarmBusinessViewServices.QueryMuchTable(name);
            return list;
        }
    }
}

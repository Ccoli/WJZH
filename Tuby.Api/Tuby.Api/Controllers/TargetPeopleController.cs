using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    /// <summary>
    /// 报警信息接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class TargetPeopleController : ControllerBase
    {
        readonly ITargetPeopleServices _TargetPeopleServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public TargetPeopleController(ITargetPeopleServices TargetPeopleServices)
        {
            _TargetPeopleServices = TargetPeopleServices;
        }

        /// <summary>
        /// 根据id获取目标人员
        /// </summary>
        /// <param name="id">目标人员id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpeople")]
        [AllowAnonymous]
        public async Task<PageModel<TargetPeopleView>> GetTypePage(int id)
        {
            var list = await _TargetPeopleServices.QueryMuchTable(id);
            return list;
        }

    }
}

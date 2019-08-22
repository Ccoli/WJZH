using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldierInfoController : ControllerBase
    {
        readonly ISoldierInfoServices _SoldierInfoServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public SoldierInfoController(ISoldierInfoServices SoldierInfoServices)
        {
            _SoldierInfoServices = SoldierInfoServices;
        }
        // GET: api/AlarmInfo
        /// <summary>
        /// 根据名字查询士兵信息
        /// </summary>
        ///  <param name="name">名字</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getname")]
        public async Task<List<SoldierInfoView>> GetPage(string name)
        {
            var list = await _SoldierInfoServices.QueryMuchTable(name);
            return list;
        }
        /// <summary>
        /// 分页查询士兵信息
        /// </summary>
        /// <param name="page">页码</param>
        ///<param name="pagesize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModel<SoldierInfoView>> GetPage(int page,int pagesize)
        {
            var list = await _SoldierInfoServices.QueryMuchTable(page, pagesize);
            return list;
        }
    }
}

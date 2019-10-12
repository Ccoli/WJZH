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
    public class GunInfoController : ControllerBase
    {
        readonly IGunInfoServices _GunInfoServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public GunInfoController(IGunInfoServices GunInfoServices)
        {
            _GunInfoServices = GunInfoServices;
        }
        // GET: api/GunInfo
        [HttpGet]
        [Route("3d")]
        public async Task<List<GunInfoView>> Get()
        {
            return await _GunInfoServices.QueryMuchTable();
        }
        [HttpGet]
        public async Task<PageModel<GunInfoView>> Get(int page,int pagesize)
        {
            return await _GunInfoServices.QueryMuchTable(page,pagesize);
        }
    }
}

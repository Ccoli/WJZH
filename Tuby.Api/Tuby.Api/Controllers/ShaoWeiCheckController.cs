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
    public class ShaoWeiCheckController : ControllerBase
    {
        readonly IShaoWeiCheckServices _ShaoWeiCheckServices;

        public ShaoWeiCheckController(IShaoWeiCheckServices ShaoWeiCheckServices)
        {
            _ShaoWeiCheckServices = ShaoWeiCheckServices;
        }
        // GET: api/ShaoWeiList
        [HttpGet]
        public async Task<PageModel<ShaoWeiCheckView>> GetPage(int page, int pagesize)
        {
            var list = await _ShaoWeiCheckServices.QueryMuchTable(page,pagesize);
            return list;
        }
    }
}

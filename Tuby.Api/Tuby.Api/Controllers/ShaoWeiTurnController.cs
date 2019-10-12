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
    public class ShaoWeiTurnController : ControllerBase
    {
        readonly IShaoWeiTurnServices _ShaoWeiTurnServices;

        public ShaoWeiTurnController(IShaoWeiTurnServices ShaoWeiTurnServices)
        {
            _ShaoWeiTurnServices = ShaoWeiTurnServices;
        }
        // GET: api/ShaoWeiList
        [HttpGet]
        public async Task<PageModel<ShaoWeiTurnView>> GetPage(int page, int pagesize)
        {
            var list = await _ShaoWeiTurnServices.QueryMuchTable(page,pagesize);
            return list;
        }
    }
}

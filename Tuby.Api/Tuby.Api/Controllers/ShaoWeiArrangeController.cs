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
    public class ShaoWeiArrangeController : ControllerBase
    {
        readonly IShaoWeiArrangeServices _ShaoWeiArrangeServices;

        public ShaoWeiArrangeController(IShaoWeiArrangeServices ShaoWeiArrangeServices)
        {
            _ShaoWeiArrangeServices = ShaoWeiArrangeServices;
        }
        // GET: api/ShaoWeiArrange
        [HttpGet]
        public async Task<PageModel<ShaoWeiArrangeView>> GetPage(int page, int pagesize)
        {
            var list = await _ShaoWeiArrangeServices.QueryMuchTable(page,pagesize);
            return list;
        }
    }
}

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
    public class ShaoWeiListController : ControllerBase
    {
        readonly IShaoWeiListServices _ShaoWeiListServices;

        public ShaoWeiListController(IShaoWeiListServices ShaoWeiListServices)
        {
            _ShaoWeiListServices = ShaoWeiListServices;
        }
        // GET: api/ShaoWeiList
        [HttpGet]
        public async Task<PageModel<ShaoWeiListView>> GetPage(int page, int pagesize)
        {
            var list = await _ShaoWeiListServices.QueryMuchTable(page,pagesize);
            return list;
        }
    }
}

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
        /// 分页查询士兵信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModel<SoldierInfoView>> GetPage(int page)
        {
            //    var list = db.Queryable<d_alarm_info, b_alarm_type, d_alarm_device>(
            //        (dinfo, btype, ddevice) => new object[] {
            //    JoinType.Left,dinfo.AlarmTypeID==btype.ID,
            //    JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID})
            //    .Select<AlarmInfoView>().ToList();
            var list = await _SoldierInfoServices.QueryMuchTable(page);
            return list;
        }
    }
}

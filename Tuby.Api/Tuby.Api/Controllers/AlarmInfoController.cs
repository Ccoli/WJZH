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
    public class AlarmInfoController : ControllerBase
    {
        readonly IAlarmInfoServices _AlarmInfoServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AlarmInfoController(IAlarmInfoServices AlarmInfoServices)
        {
            _AlarmInfoServices = AlarmInfoServices;
        }
        // GET: api/AlarmInfo
        /// <summary>
        /// 分页查询报警信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModel<AlarmInfoView>> GetPage(int page,int pagesize)
        {
            //    var list = db.Queryable<d_alarm_info, b_alarm_type, d_alarm_device>(
            //        (dinfo, btype, ddevice) => new object[] {
            //    JoinType.Left,dinfo.AlarmTypeID==btype.ID,
            //    JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID})
            //    .Select<AlarmInfoView>().ToList();
            var list =await _AlarmInfoServices.QueryMuchTable(page,pagesize);
            return list;
        }
        /// <summary>
        /// 根据报警类型获取报警信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="id">报警类型</param>
        /// <returns></returns>
        [HttpGet]
        [Route("gettype")]
        public async Task<PageModel<AlarmInfoView>> GetTypePage(int page, int pagesize,int id)
        {
            var list = await _AlarmInfoServices.QueryMuchTable(page, pagesize,id);
            return list;
        }

        [HttpGet]
        [Route("gettime")]
        public async Task<PageModel<AlarmInfoView>> GetTimePage(int page, int pagesize, int id, DateTime dt1, DateTime dt2)
        {
            var list = await _AlarmInfoServices.QueryMuchTable(page, pagesize, id, dt1,dt2);
            return list;
        }
    }
}

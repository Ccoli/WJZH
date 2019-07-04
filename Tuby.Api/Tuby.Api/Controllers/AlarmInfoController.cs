using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Controllers
{
    /// <summary>
    /// 测试多表查询接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmInfoController : ControllerBase
    {
        readonly ISoldierInfoServices _SoldierInfoServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public AlarmInfoController(ISoldierInfoServices SoldierInfoServices)
        {
            _SoldierInfoServices = SoldierInfoServices;
        }
        // GET: api/AlarmInfo
        [HttpGet]
        public List<AlarmInfoView> Get()
        {
            //    var list = db.Queryable<d_alarm_info, b_alarm_type, d_alarm_device>(
            //        (dinfo, btype, ddevice) => new object[] {
            //    JoinType.Left,dinfo.AlarmTypeID==btype.ID,
            //    JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID})
            //    .Select<AlarmInfoView>().ToList();
            var list = _SoldierInfoServices.QueryMuchTable();
            return list;
        }

        // GET: api/AlarmInfo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AlarmInfo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AlarmInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

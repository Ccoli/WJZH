using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model;
using Tuby.Api.IRepositoty;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Repository.sugar;
using SqlSugar;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tuby.Api.Repository
{
    public class AlarmInfoRepository : BaseRepository<AlarmInfoView>, IAlarmInfoRepository
    {



        //public List<AlarmInfoView> Query()
        //{


        //    var list = db.Queryable<d_alarm_info, b_alarm_type, d_alarm_device>(
        //        (dinfo, btype, ddevice) => new object[] {
        //    JoinType.Left,dinfo.AlarmTypeID==btype.ID,
        //    JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID})
        //    .Select<AlarmInfoView>().ToList();


        //    return list;
        //}
        public async Task<PageModel<AlarmInfoView>> QueryMuchTable(int page)
        {
            return await QueryMuch<d_alarm_info, b_alarm_type, d_alarm_device, b_alarm_level, AlarmInfoView>(
                    (dinfo, btype, ddevice, blevel) => new object[] {
                JoinType.Left,dinfo.AlarmTypeID==btype.ID,
               JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID,
               JoinType.Left,btype.AlarmLevelID==blevel.ID
                    }, page, 10
                    );
        }
    }
}

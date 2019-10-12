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
        public async Task<PageModel<AlarmInfoView>> QueryMuchTable(int page,int pagesize)
        {
            return await QueryMuch<d_alarm_info, b_alarm_type, d_alarm_device, b_alarm_level, AlarmInfoView>(
                    (dinfo, btype, ddevice, blevel) => new object[] {
                JoinType.Left,dinfo.AlarmTypeID==btype.ID,
               JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID,
               JoinType.Left,btype.AlarmLevelID==blevel.ID
                    }, page, pagesize
                    );
        }

        public async Task<PageModel<AlarmInfoView>> QueryMuchTable(int page, int pagesize,int id)
        {
            return await QueryMuch<d_alarm_info, b_alarm_type, d_alarm_device, b_alarm_level, AlarmInfoView>(
                    (dinfo, btype, ddevice, blevel) => new object[] {
                JoinType.Left,dinfo.AlarmTypeID==btype.ID,
               JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID,
               JoinType.Left,btype.AlarmLevelID==blevel.ID
                    }, page, pagesize,(dinfo, btype, ddevice, blevel)=> dinfo.AlarmTypeID==id
                    );
        }

        public async Task<PageModel<AlarmInfoView>> QueryMuchTable(int page, int pagesize, DateTime dt1, DateTime dt2, int id = 0)
        {
            if (id == 0)
            {
                return await QueryMuch<d_alarm_info, b_alarm_type, d_alarm_device, b_alarm_level, AlarmInfoView>(
                   (dinfo, btype, ddevice, blevel) => new object[] {
                JoinType.Left,dinfo.AlarmTypeID==btype.ID,
               JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID,
               JoinType.Left,btype.AlarmLevelID==blevel.ID
                   }, page, pagesize, (dinfo, btype, ddevice, blevel) => dinfo.AlarmTime > dt1 && dinfo.AlarmTime < dt2
                   );
            }
            return await QueryMuch<d_alarm_info, b_alarm_type, d_alarm_device, b_alarm_level, AlarmInfoView>(
                    (dinfo, btype, ddevice, blevel) => new object[] {
                JoinType.Left,dinfo.AlarmTypeID==btype.ID,
               JoinType.Left,dinfo.AlarmDeviceID==ddevice.ID,
               JoinType.Left,btype.AlarmLevelID==blevel.ID
                    }, page, pagesize, (dinfo, btype, ddevice, blevel) => dinfo.AlarmTypeID == id && dinfo.AlarmTime > dt1 && dinfo.AlarmTime < dt2
                    );
        }
    }
}

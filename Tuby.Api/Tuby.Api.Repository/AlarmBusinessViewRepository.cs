using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using Tuby.Api.Model;
using SqlSugar;

namespace Tuby.Api.Repository
{
    public class AlarmBusinessViewRepository : BaseRepository<AlarmBusinessView>, IAlarmBusinessViewRepository
    {
        public async Task<List<AlarmBusinessView>> QueryMuchTable(string name)
        {
            if (name ==null||name=="")
            {
                return await QueryMuchSelect<d_alarm_business, d_alarm_source, AlarmBusinessView>(
                   (dab, das) => new object[] {
                JoinType.Left,dab.BySouceID==das.ID
                   },
                   null
                   );
            }
            return await QueryMuchSelect<d_alarm_business, d_alarm_source, AlarmBusinessView>(
                   (dab, das) => new object[] {
                 JoinType.Left,dab.BySouceID==das.ID,
                   }, 
                   (dab, das) => (das.TopicName).Contains(name)
                   );
        }
        public async Task<List<AlarmBusinessView>> QueryMuchTable()
        {

            return await QueryMuch<d_alarm_business, d_alarm_source, AlarmBusinessView>(
                   (dab, das) => new object[] {
                 JoinType.Left,dab.BySouceID==das.ID,
                   },
                   null
                   );
        }

    }
}

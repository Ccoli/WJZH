using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Repository.Base;

namespace Tuby.Api.Repository
{
    public class LeaveRecordRepository:BaseRepository<LeaveRecordView>,ILeaveRecordRepository
    {
        public async Task<List<LeaveRecordView>> QueryMuchTable()
        {

            return await QueryMuch<d_soldier_leave, d_soldier, b_soldier_state, LeaveRecordView>(
                     (dsl, ds, bss) => new object[] {
                JoinType.Left,dsl.SoldierID==ds.ID,
                JoinType.Left,dsl.Reason==bss.ID
                     }
                     );
        }
    }
}

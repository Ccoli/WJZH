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
    public class PhoneTableRepository:BaseRepository<PhoneTableView>,IPhoneTableRepository
    {
        public async Task<List<PhoneTableView>> QueryMuchTable()
        {

            return await QueryMuch<d_phone_table, b_phone_table_type,a_department, PhoneTableView>(
                     (dpt, bptt,ad) => new object[] {
                JoinType.Left,dpt.PhoneTableTypeID==bptt.ID,
                JoinType.Left,dpt.PhoneTableTypeID==ad.ID
                     }
                     );
        }
    }
}

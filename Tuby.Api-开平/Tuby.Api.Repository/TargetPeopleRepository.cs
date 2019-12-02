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
    public class TargetPeopleRepository : BaseRepository<TargetPeopleView>, ITargetPeopleRepository
    {


        public async Task<PageModel<TargetPeopleView>> QueryMuchTable(int id)
        {
            return await QueryMuch<d_target_people, b_target_people_type, b_target_people_security_level,  TargetPeopleView>(
                    (dtp, btpt, bpsl) => new object[] {
                JoinType.Left,dtp.TargetPeopleTypeID==btpt.ID,
               JoinType.Left,dtp.SecurityLevelID==bpsl.ID
                    }, 1, 20, (dtp, btpt, bpsl) => dtp.ID==id
                    );
        }

    }
}

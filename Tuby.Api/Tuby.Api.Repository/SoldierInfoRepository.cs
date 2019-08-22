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
    public class SoldierInfoRepository : BaseRepository<SoldierInfoView>, ISoldierInfoRepository
    {
        public async Task<PageModel<SoldierInfoView>> QueryMuchTable(int page)
        {
            return await QueryMuch<d_soldier, b_pap_post, b_pap_rank, b_health,b_soldier_state, SoldierInfoView>(
                   (dsoldeir, bppost, bprank, bhealth,bsstate) => new object[] {
                JoinType.Left,dsoldeir.PostID==bppost.ID,
               JoinType.Left,dsoldeir.PoliceRankID==bprank.ID,
               JoinType.Left,dsoldeir.HealthID==bhealth.ID,
               JoinType.Left,dsoldeir.SoilderStateID ==bsstate.ID
                   }, page, 10
                   );
        }
    }
}

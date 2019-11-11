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
        public async Task<PageModel<SoldierInfoView>> QueryMuchTable(int page,int pagesize)
        {
            return await QueryMuch<d_soldier, b_pap_post, b_pap_rank, b_health, b_soldier_state, b_education_level, b_politic_role, b_marial_status,b_nation, SoldierInfoView>(
                   (dsoldeir, bppost, bprank, bhealth, bsstate, bel, bpr, bms,bn) => new object[] {
                JoinType.Left,dsoldeir.PostID==bppost.ID,
               JoinType.Left,dsoldeir.PoliceRankID==bprank.ID,
               JoinType.Left,dsoldeir.HealthID==bhealth.ID,
               JoinType.Left,dsoldeir.SoilderStateID ==bsstate.ID,
                JoinType.Left,dsoldeir.EducationID ==bel.ID,
                 JoinType.Left,dsoldeir.PoliticalRoleID ==bpr.ID,
                 JoinType.Left,dsoldeir.IsMarriageID ==bms.ID,
                 JoinType.Left,dsoldeir.Nation ==bn.NationID
                   },
                   page,
                   pagesize,null
                   );
        }
        public async Task<List<SoldierInfoView>> QueryMuchTable(string name)
        {
            if (name ==null||name=="")
            {
                return await QueryMuch<d_soldier, b_pap_post, b_pap_rank, b_health, b_soldier_state, b_education_level, b_politic_role, b_marial_status, b_nation, SoldierInfoView>(
                   (dsoldeir, bppost, bprank, bhealth, bsstate, bel, bpr, bms, bn) => new object[] {
                JoinType.Left,dsoldeir.PostID==bppost.ID,
               JoinType.Left,dsoldeir.PoliceRankID==bprank.ID,
               JoinType.Left,dsoldeir.HealthID==bhealth.ID,
               JoinType.Left,dsoldeir.SoilderStateID ==bsstate.ID,
                JoinType.Left,dsoldeir.EducationID ==bel.ID,
                 JoinType.Left,dsoldeir.PoliticalRoleID ==bpr.ID,
                 JoinType.Left,dsoldeir.IsMarriageID ==bms.ID,
                 JoinType.Left,dsoldeir.Nation ==bn.NationID
                   },
                   null
                   );
            }
            return await QueryMuch<d_soldier, b_pap_post, b_pap_rank, b_health,b_soldier_state,b_education_level,b_politic_role , b_marial_status, b_nation, SoldierInfoView>(
                   (dsoldeir, bppost, bprank, bhealth,bsstate,bel,bpr,bms,bn) => new object[] {
                JoinType.Left,dsoldeir.PostID==bppost.ID,
               JoinType.Left,dsoldeir.PoliceRankID==bprank.ID,
               JoinType.Left,dsoldeir.HealthID==bhealth.ID,
               JoinType.Left,dsoldeir.SoilderStateID ==bsstate.ID,
                JoinType.Left,dsoldeir.EducationID ==bel.ID,
                 JoinType.Left,dsoldeir.PoliticalRoleID ==bpr.ID,
                 JoinType.Left,dsoldeir.IsMarriageID ==bms.ID,
                 JoinType.Left,dsoldeir.Nation ==bn.NationID
                   }, 
                   (dsoldeir, bppost, bprank, bhealth, bsstate, bel, bpr,bms,bn) => (dsoldeir.Name).Contains(name)
                   );
        }
    }
}

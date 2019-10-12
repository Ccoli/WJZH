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
    public class ShaoWeiTurnRepository : BaseRepository<ShaoWeiTurnView>, IShaoWeiTurnRepository
    {
        public async Task<PageModel<ShaoWeiTurnView>> QueryMuchTable(int page, int pagesize)
        {
            return await QueryMuch<d_shaowei_turn, d_soldier, d_shaowei, ShaoWeiTurnView>(
                   (dst, ds, dsw) => new object[] {
               JoinType.Left,dst.SoldierID==ds.ID,
               JoinType.Left,dst.ShaoWeiID==dsw.ID
                   },
                   page,
                   pagesize,null

                   );
        }
    }
}

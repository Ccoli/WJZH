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
    public class ShaoWeiCheckRepository : BaseRepository<ShaoWeiCheckView>, IShaoWeiCheckRepository
    {
        public async Task<PageModel<ShaoWeiCheckView>> QueryMuchTable(int page, int pagesize)
        {
            return await QueryMuch<d_shaowei_check, d_soldier, d_shaowei, ShaoWeiCheckView>(
                   (dsa, ds, dsw) => new object[] {
               JoinType.Left,dsa.SoldierID==ds.ID,
               JoinType.Left,dsa.ShaoweiID==dsw.ID
                   },
                   page,
                   pagesize,null

                   );
        }
    }
}

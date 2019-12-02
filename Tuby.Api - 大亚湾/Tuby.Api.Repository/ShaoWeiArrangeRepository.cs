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
    public class ShaoWeiArrangeRepository : BaseRepository<ShaoWeiArrangeView>, IShaoWeiArrangeRepository
    {
        public async Task<PageModel<ShaoWeiArrangeView>> QueryMuchTable(int page, int pagesize)
        {
            return await QueryMuch<d_shaowei_arrange, d_soldier, d_shaowei, ShaoWeiArrangeView>(
                   (dsa, ds, dsw) => new object[] {
               JoinType.Left,dsa.SoildierID==ds.ID,
               JoinType.Left,dsa.ShaoweiID==dsw.ID
                   },
                   page,
                   pagesize,null

                   );
        }
    }
}

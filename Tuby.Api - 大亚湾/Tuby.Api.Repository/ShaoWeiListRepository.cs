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
    public class ShaoWeiListRepository:BaseRepository<ShaoWeiListView>,IShaoWeiListRepository
    {
        public async Task<PageModel<ShaoWeiListView>> QueryMuchTable(int page, int pagesize)
        {
            return await QueryMuch<d_shaowei, b_shaowei_type, b_department_type, ShaoWeiListView>(
                   (ds, bst, bdt) => new object[] {
               JoinType.Left,ds.ShaoweiTypeID==bst.ID,
               JoinType.Left,ds.DepartmentID==bdt.ID
                   },
                   page,
                   pagesize,null

                   );
        }
    }
}

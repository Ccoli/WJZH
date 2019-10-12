using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IRepository.Base;
using System.Threading.Tasks;
using Tuby.Api.Model;

namespace Tuby.Api.IRepositoty
{
    public interface IGunInfoRepository:IBaseRepository<GunInfoView>
    {
        Task<List<GunInfoView>> QueryMuchTable();
        Task<PageModel<GunInfoView>> QueryMuchTable(int page, int pagesize);
    }
}

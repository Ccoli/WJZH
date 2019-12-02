using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IServices.BASE;
using System.Threading.Tasks;
using Tuby.Api.Model;

namespace Tuby.Api.IServices
{
    public interface IGunInfoServices:IBaseServices<GunInfoView>
    {
        Task<List<GunInfoView>> QueryMuchTable();
        Task<PageModel<GunInfoView>> QueryMuchTable(int page, int pagesize);
    }
}

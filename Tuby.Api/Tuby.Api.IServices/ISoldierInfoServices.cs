using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface ISoldierInfoServices:IBaseServices<SoldierInfoView>
    {
        Task<PageModel<SoldierInfoView>> QueryMuchTable(int page);
    }
}

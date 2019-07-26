using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface IAlarmInfoServices:IBaseServices<AlarmInfoView>
    {
        // List<AlarmInfoView> Query();
        Task<PageModel<AlarmInfoView>> QueryMuchTable(int page);
    }
}

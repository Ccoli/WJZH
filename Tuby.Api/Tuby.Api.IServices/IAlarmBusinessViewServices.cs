using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface IAlarmBusinessViewServices:IBaseServices<AlarmBusinessView>
    {
        Task<List<AlarmBusinessView>> QueryMuchTable(string name);
        Task<List<AlarmBusinessView>> QueryMuchTable();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;

namespace Tuby.Api.Services
{
    public class AlarmBusinessViewServices : BaseServices<AlarmBusinessView>, IAlarmBusinessViewServices
    {
        public IAlarmBusinessViewRepository _dal;

        public AlarmBusinessViewServices(IAlarmBusinessViewRepository dal)
        {
            this._dal = dal;
        }

        public async Task<List<AlarmBusinessView>> QueryMuchTable(string name)
        {
            return await _dal.QueryMuchTable(name);
        }
        public async Task<List<AlarmBusinessView>> QueryMuchTable()
        {
            return await _dal.QueryMuchTable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Repository;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class AlarmInfoServices:BaseServices<AlarmInfoView>,  IAlarmInfoServices
    {
        public IAlarmInfoRepository _dal;

        public AlarmInfoServices(IAlarmInfoRepository dal)
        {
            this._dal = dal;
        }

        public async Task<PageModel<AlarmInfoView>> QueryMuchTable(int page)
        {
            return await _dal.QueryMuchTable(page);
        }

        //public List<AlarmInfoView> Query()
        //{
        //    return _dal.Query();
        //}
    }
}

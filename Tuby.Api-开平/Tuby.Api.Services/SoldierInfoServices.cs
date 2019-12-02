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
    public class SoldierInfoServices : BaseServices<SoldierInfoView>, ISoldierInfoServices
    {
        public ISoldierInfoRepository _dal;

        public SoldierInfoServices(ISoldierInfoRepository dal)
        {
            this._dal = dal;
        }
        public async Task<PageModel<SoldierInfoView>> QueryMuchTable(int page,int pagesize)
        {
            return await _dal.QueryMuchTable(page, pagesize);
        }
        public async Task<List<SoldierInfoView>> QueryMuchTable(string name)
        {
            return await _dal.QueryMuchTable(name);
        }
    }
}

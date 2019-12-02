using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Model;
using Tuby.Api.Services.BASE;
using Tuby.Api.IServices;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;

namespace Tuby.Api.Services
{
    public class GunInfoServices : BaseServices<GunInfoView>, IGunInfoServices
    {

        public IGunInfoRepository _dal;

        public GunInfoServices(IGunInfoRepository dal)
        {
            this._dal = dal;
        }

        public async Task<List<GunInfoView>> QueryMuchTable()
        {
            return await _dal.QueryMuchTable();
        }
        public async Task<PageModel<GunInfoView>> QueryMuchTable(int page, int pagesize)
        {
            return await _dal.QueryMuchTable(page, pagesize);
        }
    }
}

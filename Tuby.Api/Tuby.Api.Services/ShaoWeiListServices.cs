using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class ShaoWeiListServices:BaseServices<ShaoWeiListView>,IShaoWeiListServices
    {
        public IShaoWeiListRepository _dal;

        public ShaoWeiListServices(IShaoWeiListRepository dal)
        {
            this._dal = dal;
        }

        public async Task<PageModel<ShaoWeiListView>> QueryMuchTable(int page,int pagesize)
        {
            return await _dal.QueryMuchTable(page,pagesize);
        }
    }
}

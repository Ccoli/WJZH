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
    public class TargetPeopleServices:BaseServices<TargetPeopleView>,  ITargetPeopleServices
    {
        public ITargetPeopleRepository _dal;

        public TargetPeopleServices(ITargetPeopleRepository dal)
        {
            this._dal = dal;
        }


        public async Task<PageModel<TargetPeopleView>> QueryMuchTable(int id)
        {
            return await _dal.QueryMuchTable(id);
        }

    }
}

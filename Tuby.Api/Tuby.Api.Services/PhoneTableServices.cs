using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepositoty;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class PhoneTableServices : BaseServices<PhoneTableView>, IPhoneTableServices
    {
        public IPhoneTableRepository _dal;

        public PhoneTableServices(IPhoneTableRepository dal)
        {
            this._dal = dal;
        }
        public Task<List<PhoneTableView>> QueryMuchTable()
        {
            return _dal.QueryMuchTable();
        }
    }
}

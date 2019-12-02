using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface IPhoneTableServices:IBaseServices<PhoneTableView>
    {
        Task<List<PhoneTableView>> QueryMuchTable();
    }
}

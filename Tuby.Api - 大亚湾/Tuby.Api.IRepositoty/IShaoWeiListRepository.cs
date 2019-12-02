using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IRepositoty
{
    public interface IShaoWeiListRepository:IBaseRepository<ShaoWeiListView>
    {
        Task<PageModel<ShaoWeiListView>> QueryMuchTable(int page, int pagesize);
    }
}

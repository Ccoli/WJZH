using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IRepositoty
{
    public interface IDeviceListRepository:IBaseRepository<DeviceListView>
    {
        Task<List<DeviceListView2>> QueryMuchTable();
    }
}

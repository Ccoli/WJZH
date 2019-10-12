using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IServices.BASE;
using System.Threading.Tasks;

namespace Tuby.Api.IServices
{
    public interface IDeviceListServices:IBaseServices<DeviceListView>
    {
        Task<List<NodeData>> GetListData();
    }
}

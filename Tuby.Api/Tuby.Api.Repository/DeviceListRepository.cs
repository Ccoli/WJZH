using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using Tuby.Api.Model;
using SqlSugar;

namespace Tuby.Api.Repository
{
    public class DeviceListRepository:BaseRepository<DeviceListView>, IDeviceListRepository
    {
        public async Task<List<DeviceListView2>> QueryMuchTable()
        {
            return await QueryMuch<DeviceListView, b_device_account, DeviceListView2>(
                    (dv, bda) => new object[] {
                JoinType.Left,dv.UserID==bda.ID
                    },null
                    );
        }
    }
}

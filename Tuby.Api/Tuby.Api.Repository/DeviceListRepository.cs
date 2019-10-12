using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IRepositoty;

namespace Tuby.Api.Repository
{
    public class DeviceListRepository:BaseRepository<DeviceListView>, IDeviceListRepository
    {
    }
}

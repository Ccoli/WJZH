using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;

namespace Tuby.Api.IRepositoty
{
    public interface IVideoViewRepository : IBaseRepository<VideoView>
    {
        Task<List<VideoView>> QueryMuchTable();
    }
}

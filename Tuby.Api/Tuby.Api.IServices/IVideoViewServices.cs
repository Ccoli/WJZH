using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model;
using Tuby.Api.IServices.BASE;
using System.Threading.Tasks;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface IVideoViewServices:IBaseServices<VideoView>
    {
        Task<List<VideoNodeData>> GetListData();
    }
}

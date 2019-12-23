using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model;
using Tuby.Api.Services.BASE;
using Tuby.Api.IServices;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using System.Linq;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Services
{
    public class VideoViewServices : BaseServices<VideoView>, IVideoViewServices
    {
        IVideoViewRepository dal;
        Id_video_structServices _d_video_structServices;
        public VideoViewServices(IVideoViewRepository dal, Id_video_structServices d_video_structServices)
        {
            this.dal = dal;
            base.baseDal = dal;
            _d_video_structServices = d_video_structServices;
        }

        public async Task<List<VideoNodeData>> GetListData()
        {
            var list = await dal.QueryMuchTable();
            var list2 = await _d_video_structServices.Query();
            Dictionary<int, VideoNodeData> nodes = new Dictionary<int, VideoNodeData>();
            for (var i = 0; i < list2.Count; i++)
            {
                nodes.Add(list2[i].ID, new VideoNodeData(list2[i].ID, list2[i].PID, list2[i].NodeName, 0, null, null, true,null, false,null,null,0,0,0) );
            }
            for (var i = 0; i < list.Count; i++)
            {
                nodes.Add(list[i].ID, new VideoNodeData(list[i].ID, list[i].PID, list[i].Name, list[i].Channel, list[i].Address, list[i].IP, false,list[i].ViewPoint , list[i].IsAddress, list[i].UserName, list[i].Password, list[i].X, list[i].Y, list[i].Z));
            }

            List<VideoNodeData> list1 = nodes.Values.ToList();
            //list.Reverse();
            List<VideoNodeData> result = new List<VideoNodeData>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                VideoNodeData node = list1[i];
                if (nodes.ContainsKey(node.pid))
                {
                    VideoNodeData parent = nodes[node.pid];
                    if (parent.children == null)
                        parent.children = new List<VideoNodeData>();
                    parent.children.Add(node);
                }
                else
                {
                    result.Add(node);
                }
            }
            result.Reverse();
            return result;
        }
    }
}

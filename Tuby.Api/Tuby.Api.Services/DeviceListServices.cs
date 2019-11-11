using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services.BASE;
using Tuby.Api.IServices;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using System.Linq;

namespace Tuby.Api.Services
{
    public class DeviceListServices : BaseServices<DeviceListView>, IDeviceListServices
    {
        IDeviceListRepository dal;
        public DeviceListServices(IDeviceListRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<List<NodeData>> GetListData()
        {
            var list = await base.Query();
            Dictionary<int, NodeData> nodes = new Dictionary<int, NodeData>();
            for (var i = 0; i < list.Count; i++)
            {
                nodes.Add(list[i].id, new NodeData(list[i].id, list[i].pid,list[i].name, list[i].channel, list[i].timeLine, list[i].comment, list[i].ip, list[i].isParent));
            }

            List<NodeData> list1 = nodes.Values.ToList();
            //list.Reverse();
            List<NodeData> result = new List<NodeData>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                NodeData node = list1[i];
                if (nodes.ContainsKey(node.pid))
                {
                    NodeData parent = nodes[node.pid];
                    if (parent.children == null)
                        parent.children = new List<NodeData>();
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

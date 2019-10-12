using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class NodeData
    {
        public NodeData(int id, int pid, string channel, int timeline, string comment, string ip, bool isParent)
        {
            this.id = id;
            this.pid = pid;
            this.channel = channel;
            this.timeline = timeline;
            this.comment = comment;
            this.ip = ip;
            this.isParent = isParent;
            children = null;
        }
        public int id;
        public int pid;
        public string channel;
        public int timeline;
        public string comment;
        public string ip;
        public bool isParent;
        public List<NodeData> children { set; get; }
    }

}

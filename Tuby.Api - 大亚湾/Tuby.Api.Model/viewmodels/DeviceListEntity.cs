using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class NodeData
    {
        public NodeData(int id, int pid,string name, string channel, string videoaddress,string mainstream, string ip, bool isParent, string substream,string coordinate, string view,bool isAddress,string username,string password,string devicefrom)
        {
            this.id = id;
            this.pid = pid;
            this.name = name;
            this.channel = channel;
            this.videoaddress = videoaddress;
            this.mainstream = mainstream;
            this.ip = ip;
            this.isParent = isParent;
            this.substream = substream;
            this.coordinate = coordinate;
            this.view = view;
            this.isAddress = isAddress;
            this.username = username;
            this.password = password;
            this.devicefrom = devicefrom;
            children = null;
        }
        public int id;
        public int pid;
        public string name;
        public string channel;
        public string videoaddress;
        public string mainstream;
        public string ip;
        public string substream;
        public string coordinate;
        public string view;
        public bool isAddress;
        public bool isParent;
        public string username;
        public string password;
        public string devicefrom;
        public List<NodeData> children { set; get; }
    }

}

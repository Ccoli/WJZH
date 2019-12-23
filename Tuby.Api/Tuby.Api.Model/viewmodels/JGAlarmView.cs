using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class JGAlarmView
    {
        //{"AreaID":0,"EventID":11,"HostID":0,"ReceiverID":11,"TerminalID":109}
        public int AreaID { get; set; }
        public string AlarmID { get; set; }
        public int Business { get; set; }
        public string EventDescription { get; set; }
        public int EventID { get; set; }
        public int HostID { get; set; }
        public int ReceiverID { get; set; }
        public int TerminalID { get; set; }
        public string Guid { get; set; }
    }
}

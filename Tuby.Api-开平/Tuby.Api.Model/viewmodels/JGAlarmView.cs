﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class JGAlarmView
    {
        //{"AreaID":0,"EventID":11,"HostID":0,"ReceiverID":11,"TerminalID":109}
        public int AreaID { get; set; }
        public int EventID { get; set; }
        public int HostID { get; set; }
        public int ReceiverID { get; set; }
        public int TerminalID { get; set; }
    }
}

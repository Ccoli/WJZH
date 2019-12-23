using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class AlarmCountEntity
    {
        List<Dictionary<string, object>> localDayData { set; get; }
        List<Dictionary<string, object>> dayData { set; get; }
    }
}

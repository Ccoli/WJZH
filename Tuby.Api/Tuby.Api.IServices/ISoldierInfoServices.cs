using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{
    public interface ISoldierInfoServices:IBaseServices<AlarmInfoView>
    {
        // List<AlarmInfoView> Query();
        List<AlarmInfoView> QueryMuchTable();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IRepositoty
{
    public interface ISoldierInfoRepository:IBaseRepository<AlarmInfoView>
    {
       //List<AlarmInfoView> Query();
       List<AlarmInfoView> QueryMuchTable();
    }
}

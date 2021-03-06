﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IRepositoty
{
    public interface IAlarmInfoRepository:IBaseRepository<AlarmInfoView>
    {
        //List<AlarmInfoView> Query();
        Task<PageModel<AlarmInfoView>> QueryMuchTable(int page,int pagesize);
        Task<PageModel<AlarmInfoView>> QueryMuchTable(int page, int pagesize,int id);
        Task<PageModel<AlarmInfoView>> QueryMuchTable(int page, int pagesize, DateTime dt1, DateTime dt2, int id); 
    }
}

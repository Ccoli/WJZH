using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.IRepositoty;
using Tuby.Api.IServices;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Repository;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{
    public class SoldierInfoServices:BaseServices<AlarmInfoView>,  ISoldierInfoServices
    {
        public ISoldierInfoRepository _dal;

        public SoldierInfoServices(ISoldierInfoRepository dal)
        {
            this._dal = dal;
        }

        public List<AlarmInfoView> QueryMuchTable()
        {
            return _dal.QueryMuchTable();
        }

        //public List<AlarmInfoView> Query()
        //{
        //    return _dal.Query();
        //}
    }
}

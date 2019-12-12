using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Services
{
    /// <summary>
    /// d_alarm_sourceServices
    /// </summary>	
    public class d_alarm_sourceServices : BaseServices<d_alarm_source>, Id_alarm_sourceServices
    {

        Id_alarm_sourceRepository dal;
        public d_alarm_sourceServices(Id_alarm_sourceRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public async Task<List<string>> QueryList()
        {
            return await dal.QueryList();
        }
        public async Task<List<object>> QueryNameList()
        {
            return await dal.QueryNameList();
        }
    }
}


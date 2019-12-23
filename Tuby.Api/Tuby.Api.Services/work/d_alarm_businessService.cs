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
    /// d_alarm_businessServices
    /// </summary>	
    public class d_alarm_businessServices : BaseServices<d_alarm_business>, Id_alarm_businessServices
    {

        Id_alarm_businessRepository dal;
        public d_alarm_businessServices(Id_alarm_businessRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

    }
}


using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// HandAlarmServices
	/// </summary>	
	public class HandAlarmServices : BaseServices<HandAlarm>, IHandAlarmServices
    {
	
        IHandAlarmRepository dal;
        public HandAlarmServices(IHandAlarmRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
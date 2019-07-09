using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_alarm_deviceServices
	/// </summary>	
	public class d_alarm_deviceServices : BaseServices<d_alarm_device>, Id_alarm_deviceServices
    {
	
        Id_alarm_deviceRepository dal;
        public d_alarm_deviceServices(Id_alarm_deviceRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
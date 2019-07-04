using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_alarm_device_typeServices
	/// </summary>	
	public class b_alarm_device_typeServices : BaseServices<b_alarm_device_type>, Ib_alarm_device_typeServices
    {
	
        Ib_alarm_device_typeRepository dal;
        public b_alarm_device_typeServices(Ib_alarm_device_typeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
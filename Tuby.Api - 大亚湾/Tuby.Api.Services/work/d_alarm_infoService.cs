using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_alarm_infoServices
	/// </summary>	
	public class d_alarm_infoServices : BaseServices<d_alarm_info>, Id_alarm_infoServices
    {
	
        Id_alarm_infoRepository dal;
        public d_alarm_infoServices(Id_alarm_infoRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
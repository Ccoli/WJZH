using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_alarm_levelServices
	/// </summary>	
	public class b_alarm_levelServices : BaseServices<b_alarm_level>, Ib_alarm_levelServices
    {
	
        Ib_alarm_levelRepository dal;
        public b_alarm_levelServices(Ib_alarm_levelRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
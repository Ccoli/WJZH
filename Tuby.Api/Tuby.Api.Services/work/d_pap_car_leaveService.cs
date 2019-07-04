using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_car_leaveServices
	/// </summary>	
	public class d_pap_car_leaveServices : BaseServices<d_pap_car_leave>, Id_pap_car_leaveServices
    {
	
        Id_pap_car_leaveRepository dal;
        public d_pap_car_leaveServices(Id_pap_car_leaveRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
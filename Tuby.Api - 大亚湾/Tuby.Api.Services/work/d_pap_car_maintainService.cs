using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_car_maintainServices
	/// </summary>	
	public class d_pap_car_maintainServices : BaseServices<d_pap_car_maintain>, Id_pap_car_maintainServices
    {
	
        Id_pap_car_maintainRepository dal;
        public d_pap_car_maintainServices(Id_pap_car_maintainRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
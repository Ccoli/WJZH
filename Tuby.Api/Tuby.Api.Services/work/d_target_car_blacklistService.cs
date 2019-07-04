using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_car_blacklistServices
	/// </summary>	
	public class d_target_car_blacklistServices : BaseServices<d_target_car_blacklist>, Id_target_car_blacklistServices
    {
	
        Id_target_car_blacklistRepository dal;
        public d_target_car_blacklistServices(Id_target_car_blacklistRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
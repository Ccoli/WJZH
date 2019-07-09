using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_car_whitelistServices
	/// </summary>	
	public class d_target_car_whitelistServices : BaseServices<d_target_car_whitelist>, Id_target_car_whitelistServices
    {
	
        Id_target_car_whitelistRepository dal;
        public d_target_car_whitelistServices(Id_target_car_whitelistRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
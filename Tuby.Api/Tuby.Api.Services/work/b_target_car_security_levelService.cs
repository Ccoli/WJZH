using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_target_car_security_levelServices
	/// </summary>	
	public class b_target_car_security_levelServices : BaseServices<b_target_car_security_level>, Ib_target_car_security_levelServices
    {
	
        Ib_target_car_security_levelRepository dal;
        public b_target_car_security_levelServices(Ib_target_car_security_levelRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
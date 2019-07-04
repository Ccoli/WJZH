using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_carServices
	/// </summary>	
	public class d_target_carServices : BaseServices<d_target_car>, Id_target_carServices
    {
	
        Id_target_carRepository dal;
        public d_target_carServices(Id_target_carRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_carServices
	/// </summary>	
	public class d_pap_carServices : BaseServices<d_pap_car>, Id_pap_carServices
    {
	
        Id_pap_carRepository dal;
        public d_pap_carServices(Id_pap_carRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
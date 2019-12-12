using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_car_attributeServices
	/// </summary>	
	public class d_car_attributeServices : BaseServices<d_car_attribute>, Id_car_attributeServices
    {
	
        Id_car_attributeRepository dal;
        public d_car_attributeServices(Id_car_attributeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
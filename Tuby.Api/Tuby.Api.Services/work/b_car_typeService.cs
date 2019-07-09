using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_car_typeServices
	/// </summary>	
	public class b_car_typeServices : BaseServices<b_car_type>, Ib_car_typeServices
    {
	
        Ib_car_typeRepository dal;
        public b_car_typeServices(Ib_car_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
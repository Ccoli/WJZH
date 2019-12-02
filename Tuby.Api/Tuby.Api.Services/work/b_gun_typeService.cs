using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_gun_typeServices
	/// </summary>	
	public class b_gun_typeServices : BaseServices<b_gun_type>, Ib_gun_typeServices
    {
	
        Ib_gun_typeRepository dal;
        public b_gun_typeServices(Ib_gun_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
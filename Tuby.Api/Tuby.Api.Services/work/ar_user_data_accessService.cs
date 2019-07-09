using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ar_user_data_accessServices
	/// </summary>	
	public class ar_user_data_accessServices : BaseServices<ar_user_data_access>, Iar_user_data_accessServices
    {
	
        Iar_user_data_accessRepository dal;
        public ar_user_data_accessServices(Iar_user_data_accessRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
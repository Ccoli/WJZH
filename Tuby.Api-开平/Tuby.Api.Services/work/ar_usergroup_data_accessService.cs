using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ar_usergroup_data_accessServices
	/// </summary>	
	public class ar_usergroup_data_accessServices : BaseServices<ar_usergroup_data_access>, Iar_usergroup_data_accessServices
    {
	
        Iar_usergroup_data_accessRepository dal;
        public ar_usergroup_data_accessServices(Iar_usergroup_data_accessRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
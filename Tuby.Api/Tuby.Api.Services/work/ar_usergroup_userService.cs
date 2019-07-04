using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ar_usergroup_userServices
	/// </summary>	
	public class ar_usergroup_userServices : BaseServices<ar_usergroup_user>, Iar_usergroup_userServices
    {
	
        Iar_usergroup_userRepository dal;
        public ar_usergroup_userServices(Iar_usergroup_userRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
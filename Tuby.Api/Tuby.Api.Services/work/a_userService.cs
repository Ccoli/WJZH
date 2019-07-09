using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_userServices
	/// </summary>	
	public class a_userServices : BaseServices<a_user>, Ia_userServices
    {
	
        Ia_userRepository dal;
        public a_userServices(Ia_userRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_usergroupServices
	/// </summary>	
	public class a_usergroupServices : BaseServices<a_usergroup>, Ia_usergroupServices
    {
	
        Ia_usergroupRepository dal;
        public a_usergroupServices(Ia_usergroupRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
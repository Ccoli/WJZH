using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_people_whitelistServices
	/// </summary>	
	public class d_target_people_whitelistServices : BaseServices<d_target_people_whitelist>, Id_target_people_whitelistServices
    {
	
        Id_target_people_whitelistRepository dal;
        public d_target_people_whitelistServices(Id_target_people_whitelistRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
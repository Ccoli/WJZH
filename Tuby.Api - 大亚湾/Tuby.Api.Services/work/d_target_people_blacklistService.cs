using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_people_blacklistServices
	/// </summary>	
	public class d_target_people_blacklistServices : BaseServices<d_target_people_blacklist>, Id_target_people_blacklistServices
    {
	
        Id_target_people_blacklistRepository dal;
        public d_target_people_blacklistServices(Id_target_people_blacklistRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
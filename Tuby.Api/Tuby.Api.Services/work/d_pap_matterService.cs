using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_matterServices
	/// </summary>	
	public class d_pap_matterServices : BaseServices<d_pap_matter>, Id_pap_matterServices
    {
	
        Id_pap_matterRepository dal;
        public d_pap_matterServices(Id_pap_matterRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_gunServices
	/// </summary>	
	public class d_pap_gunServices : BaseServices<d_pap_gun>, Id_pap_gunServices
    {
	
        Id_pap_gunRepository dal;
        public d_pap_gunServices(Id_pap_gunRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
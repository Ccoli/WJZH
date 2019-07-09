using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_equipmentServices
	/// </summary>	
	public class d_pap_equipmentServices : BaseServices<d_pap_equipment>, Id_pap_equipmentServices
    {
	
        Id_pap_equipmentRepository dal;
        public d_pap_equipmentServices(Id_pap_equipmentRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
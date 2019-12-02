using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_medicalServices
	/// </summary>	
	public class d_medicalServices : BaseServices<d_medical>, Id_medicalServices
    {
	
        Id_medicalRepository dal;
        public d_medicalServices(Id_medicalRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
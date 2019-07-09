using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_soldier_treatmentServices
	/// </summary>	
	public class d_soldier_treatmentServices : BaseServices<d_soldier_treatment>, Id_soldier_treatmentServices
    {
	
        Id_soldier_treatmentRepository dal;
        public d_soldier_treatmentServices(Id_soldier_treatmentRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
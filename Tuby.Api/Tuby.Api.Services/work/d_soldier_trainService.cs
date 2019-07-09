using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_soldier_trainServices
	/// </summary>	
	public class d_soldier_trainServices : BaseServices<d_soldier_train>, Id_soldier_trainServices
    {
	
        Id_soldier_trainRepository dal;
        public d_soldier_trainServices(Id_soldier_trainRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
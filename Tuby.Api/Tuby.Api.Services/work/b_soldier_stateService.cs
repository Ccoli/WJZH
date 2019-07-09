using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_soldier_stateServices
	/// </summary>	
	public class b_soldier_stateServices : BaseServices<b_soldier_state>, Ib_soldier_stateServices
    {
	
        Ib_soldier_stateRepository dal;
        public b_soldier_stateServices(Ib_soldier_stateRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
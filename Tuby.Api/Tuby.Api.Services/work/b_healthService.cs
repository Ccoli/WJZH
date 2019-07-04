using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_healthServices
	/// </summary>	
	public class b_healthServices : BaseServices<b_health>, Ib_healthServices
    {
	
        Ib_healthRepository dal;
        public b_healthServices(Ib_healthRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_politic_roleServices
	/// </summary>	
	public class b_politic_roleServices : BaseServices<b_politic_role>, Ib_politic_roleServices
    {
	
        Ib_politic_roleRepository dal;
        public b_politic_roleServices(Ib_politic_roleRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
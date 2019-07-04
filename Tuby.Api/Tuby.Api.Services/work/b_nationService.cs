using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_nationServices
	/// </summary>	
	public class b_nationServices : BaseServices<b_nation>, Ib_nationServices
    {
	
        Ib_nationRepository dal;
        public b_nationServices(Ib_nationRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
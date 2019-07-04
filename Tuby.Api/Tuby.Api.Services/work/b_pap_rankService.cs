using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_pap_rankServices
	/// </summary>	
	public class b_pap_rankServices : BaseServices<b_pap_rank>, Ib_pap_rankServices
    {
	
        Ib_pap_rankRepository dal;
        public b_pap_rankServices(Ib_pap_rankRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
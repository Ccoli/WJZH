using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_marial_statusServices
	/// </summary>	
	public class b_marial_statusServices : BaseServices<b_marial_status>, Ib_marial_statusServices
    {
	
        Ib_marial_statusRepository dal;
        public b_marial_statusServices(Ib_marial_statusRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
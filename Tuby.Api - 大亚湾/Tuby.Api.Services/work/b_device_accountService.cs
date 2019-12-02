using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_device_accountServices
	/// </summary>	
	public class b_device_accountServices : BaseServices<b_device_account>, Ib_device_accountServices
    {
	
        Ib_device_accountRepository dal;
        public b_device_accountServices(Ib_device_accountRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
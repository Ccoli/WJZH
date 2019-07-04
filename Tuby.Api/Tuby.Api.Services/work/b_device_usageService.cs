using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_device_usageServices
	/// </summary>	
	public class b_device_usageServices : BaseServices<b_device_usage>, Ib_device_usageServices
    {
	
        Ib_device_usageRepository dal;
        public b_device_usageServices(Ib_device_usageRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
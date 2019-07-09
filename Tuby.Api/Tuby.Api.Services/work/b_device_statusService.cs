using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_device_statusServices
	/// </summary>	
	public class b_device_statusServices : BaseServices<b_device_status>, Ib_device_statusServices
    {
	
        Ib_device_statusRepository dal;
        public b_device_statusServices(Ib_device_statusRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
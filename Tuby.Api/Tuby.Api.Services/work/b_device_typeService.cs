using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_device_typeServices
	/// </summary>	
	public class b_device_typeServices : BaseServices<b_device_type>, Ib_device_typeServices
    {
	
        Ib_device_typeRepository dal;
        public b_device_typeServices(Ib_device_typeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
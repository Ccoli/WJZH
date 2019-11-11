using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_duty_countServices
	/// </summary>	
	public class d_duty_countServices : BaseServices<d_duty_count>, Id_duty_countServices
    {
	
        Id_duty_countRepository dal;
        public d_duty_countServices(Id_duty_countRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
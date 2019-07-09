using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_soldier_leaveServices
	/// </summary>	
	public class d_soldier_leaveServices : BaseServices<d_soldier_leave>, Id_soldier_leaveServices
    {
	
        Id_soldier_leaveRepository dal;
        public d_soldier_leaveServices(Id_soldier_leaveRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
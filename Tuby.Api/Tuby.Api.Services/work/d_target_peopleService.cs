using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_peopleServices
	/// </summary>	
	public class d_target_peopleServices : BaseServices<d_target_people>, Id_target_peopleServices
    {
	
        Id_target_peopleRepository dal;
        public d_target_peopleServices(Id_target_peopleRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
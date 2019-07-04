using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_people_controlServices
	/// </summary>	
	public class d_target_people_controlServices : BaseServices<d_target_people_control>, Id_target_people_controlServices
    {
	
        Id_target_people_controlRepository dal;
        public d_target_people_controlServices(Id_target_people_controlRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
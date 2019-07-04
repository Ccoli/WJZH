using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_pap_camera_record_peopleServices
	/// </summary>	
	public class d_pap_camera_record_peopleServices : BaseServices<d_pap_camera_record_people>, Id_pap_camera_record_peopleServices
    {
	
        Id_pap_camera_record_peopleRepository dal;
        public d_pap_camera_record_peopleServices(Id_pap_camera_record_peopleRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
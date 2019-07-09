using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_target_camera_record_carServices
	/// </summary>	
	public class d_target_camera_record_carServices : BaseServices<d_target_camera_record_car>, Id_target_camera_record_carServices
    {
	
        Id_target_camera_record_carRepository dal;
        public d_target_camera_record_carServices(Id_target_camera_record_carRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
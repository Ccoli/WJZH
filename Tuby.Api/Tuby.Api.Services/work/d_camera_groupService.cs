using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_camera_groupServices
	/// </summary>	
	public class d_camera_groupServices : BaseServices<d_camera_group>, Id_camera_groupServices
    {
	
        Id_camera_groupRepository dal;
        public d_camera_groupServices(Id_camera_groupRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
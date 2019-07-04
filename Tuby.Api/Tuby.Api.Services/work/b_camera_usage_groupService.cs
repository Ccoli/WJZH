using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_camera_usage_groupServices
	/// </summary>	
	public class b_camera_usage_groupServices : BaseServices<b_camera_usage_group>, Ib_camera_usage_groupServices
    {
	
        Ib_camera_usage_groupRepository dal;
        public b_camera_usage_groupServices(Ib_camera_usage_groupRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
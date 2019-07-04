using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// dr_cameragroup_cameraServices
	/// </summary>	
	public class dr_cameragroup_cameraServices : BaseServices<dr_cameragroup_camera>, Idr_cameragroup_cameraServices
    {
	
        Idr_cameragroup_cameraRepository dal;
        public dr_cameragroup_cameraServices(Idr_cameragroup_cameraRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
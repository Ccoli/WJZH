using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_cameraServices
	/// </summary>	
	public class d_cameraServices : BaseServices<d_camera>, Id_cameraServices
    {
	
        Id_cameraRepository dal;
        public d_cameraServices(Id_cameraRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
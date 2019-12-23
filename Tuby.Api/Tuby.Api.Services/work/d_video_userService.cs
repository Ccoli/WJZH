using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_video_userServices
	/// </summary>	
	public class d_video_userServices : BaseServices<d_video_user>, Id_video_userServices
    {
	
        Id_video_userRepository dal;
        public d_video_userServices(Id_video_userRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
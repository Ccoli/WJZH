using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_video_groupServices
	/// </summary>	
	public class d_video_groupServices : BaseServices<d_video_group>, Id_video_groupServices
    {
	
        Id_video_groupRepository dal;
        public d_video_groupServices(Id_video_groupRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
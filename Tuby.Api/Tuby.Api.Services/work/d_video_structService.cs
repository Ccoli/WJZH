using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_video_structServices
	/// </summary>	
	public class d_video_structServices : BaseServices<d_video_struct>, Id_video_structServices
    {
	
        Id_video_structRepository dal;
        public d_video_structServices(Id_video_structRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
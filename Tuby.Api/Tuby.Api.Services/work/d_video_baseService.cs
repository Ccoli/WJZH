using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_video_baseServices
	/// </summary>	
	public class d_video_baseServices : BaseServices<d_video_base>, Id_video_baseServices
    {
	
        Id_video_baseRepository dal;
        public d_video_baseServices(Id_video_baseRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
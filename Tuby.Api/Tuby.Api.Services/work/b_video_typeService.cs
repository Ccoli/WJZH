using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_video_typeServices
	/// </summary>	
	public class b_video_typeServices : BaseServices<b_video_type>, Ib_video_typeServices
    {
	
        Ib_video_typeRepository dal;
        public b_video_typeServices(Ib_video_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
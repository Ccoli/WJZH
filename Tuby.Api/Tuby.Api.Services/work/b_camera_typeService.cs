using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_camera_typeServices
	/// </summary>	
	public class b_camera_typeServices : BaseServices<b_camera_type>, Ib_camera_typeServices
    {
	
        Ib_camera_typeRepository dal;
        public b_camera_typeServices(Ib_camera_typeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
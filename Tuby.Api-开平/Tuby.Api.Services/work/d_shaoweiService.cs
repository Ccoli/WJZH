using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_shaoweiServices
	/// </summary>	
	public class d_shaoweiServices : BaseServices<d_shaowei>, Id_shaoweiServices
    {
	
        Id_shaoweiRepository dal;
        public d_shaoweiServices(Id_shaoweiRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
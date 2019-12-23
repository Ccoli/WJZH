using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_view_pointServices
	/// </summary>	
	public class d_view_pointServices : BaseServices<d_view_point>, Id_view_pointServices
    {
	
        Id_view_pointRepository dal;
        public d_view_pointServices(Id_view_pointRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
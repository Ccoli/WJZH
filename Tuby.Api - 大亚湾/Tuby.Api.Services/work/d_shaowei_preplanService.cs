using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_shaowei_preplanServices
	/// </summary>	
	public class d_shaowei_preplanServices : BaseServices<d_shaowei_preplan>, Id_shaowei_preplanServices
    {
	
        Id_shaowei_preplanRepository dal;
        public d_shaowei_preplanServices(Id_shaowei_preplanRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
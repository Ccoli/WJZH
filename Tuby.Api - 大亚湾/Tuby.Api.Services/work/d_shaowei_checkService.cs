using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_shaowei_checkServices
	/// </summary>	
	public class d_shaowei_checkServices : BaseServices<d_shaowei_check>, Id_shaowei_checkServices
    {
	
        Id_shaowei_checkRepository dal;
        public d_shaowei_checkServices(Id_shaowei_checkRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
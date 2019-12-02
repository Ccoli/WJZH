using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_shaowei_turnServices
	/// </summary>	
	public class d_shaowei_turnServices : BaseServices<d_shaowei_turn>, Id_shaowei_turnServices
    {
	
        Id_shaowei_turnRepository dal;
        public d_shaowei_turnServices(Id_shaowei_turnRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
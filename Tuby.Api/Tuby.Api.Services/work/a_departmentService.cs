using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_departmentServices
	/// </summary>	
	public class a_departmentServices : BaseServices<a_department>, Ia_departmentServices
    {
	
        Ia_departmentRepository dal;
        public a_departmentServices(Ia_departmentRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
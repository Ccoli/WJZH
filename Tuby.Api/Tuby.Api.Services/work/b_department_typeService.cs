using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_department_typeServices
	/// </summary>	
	public class b_department_typeServices : BaseServices<b_department_type>, Ib_department_typeServices
    {
	
        Ib_department_typeRepository dal;
        public b_department_typeServices(Ib_department_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
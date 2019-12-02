using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// dr_department_soldierServices
	/// </summary>	
	public class dr_department_soldierServices : BaseServices<dr_department_soldier>, Idr_department_soldierServices
    {
	
        Idr_department_soldierRepository dal;
        public dr_department_soldierServices(Idr_department_soldierRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
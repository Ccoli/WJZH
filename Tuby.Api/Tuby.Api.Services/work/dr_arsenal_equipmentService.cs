using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// dr_arsenal_equipmentServices
	/// </summary>	
	public class dr_arsenal_equipmentServices : BaseServices<dr_arsenal_equipment>, Idr_arsenal_equipmentServices
    {
	
        Idr_arsenal_equipmentRepository dal;
        public dr_arsenal_equipmentServices(Idr_arsenal_equipmentRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
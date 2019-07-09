using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_equipment_typeServices
	/// </summary>	
	public class b_equipment_typeServices : BaseServices<b_equipment_type>, Ib_equipment_typeServices
    {
	
        Ib_equipment_typeRepository dal;
        public b_equipment_typeServices(Ib_equipment_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
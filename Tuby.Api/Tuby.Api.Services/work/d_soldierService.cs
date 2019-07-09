using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_soldierServices
	/// </summary>	
	public class d_soldierServices : BaseServices<d_soldier>, Id_soldierServices
    {
	
        Id_soldierRepository dal;
        public d_soldierServices(Id_soldierRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
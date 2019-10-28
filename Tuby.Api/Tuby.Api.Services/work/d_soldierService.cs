using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<string>> QueryList()
        {
            return await dal.QueryList();
        }
        public async Task<List<object>> QueryNameList()
        {
            return await dal.QueryNameList();
        }
    }
}
	
	
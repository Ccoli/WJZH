using System;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tuby.Api.Repository
{	
	/// <summary>
	/// d_soldierRepository
	/// </summary>	
	public class d_soldierRepository : BaseRepository<d_soldier>, Id_soldierRepository
    {
        public async Task<List<string>> QueryList()
        {
            return await QueryField(s=>s.Name);
        }
        public async Task<List<object>> QueryNameList()
        {
            Expression<Func<d_soldier, bool>> whereExpression = a => a.IsDeleted != true;
            return await QueryField(s => new {
                s.ID,
                s.Name
            }, whereExpression);
        }
    }
}

	
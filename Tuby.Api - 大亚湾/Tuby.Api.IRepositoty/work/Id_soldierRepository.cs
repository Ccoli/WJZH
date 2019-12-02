using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;

namespace Tuby.Api.IRepository
{	
	/// <summary>
	/// Id_soldierRepository
	/// </summary>	
	public interface Id_soldierRepository : IBaseRepository<d_soldier>
    {
        Task<List<string>> QueryList();
        Task<List<object>> QueryNameList();
    }
}
	
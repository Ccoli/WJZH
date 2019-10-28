using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;

namespace Tuby.Api.IServices
{	
	/// <summary>
	/// d_soldierServices
	/// </summary>	
    public interface Id_soldierServices :IBaseServices<d_soldier>
	{
        Task<List<string>> QueryList();
        Task<List<object>> QueryNameList();
    }
}

	
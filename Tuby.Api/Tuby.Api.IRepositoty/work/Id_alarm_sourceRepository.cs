using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.IRepository.Base;
using Tuby.Api.Model;

namespace Tuby.Api.IRepository
{	
	/// <summary>
	/// Id_alarm_sourceRepository
	/// </summary>	
	public interface Id_alarm_sourceRepository : IBaseRepository<d_alarm_source>
    {
        Task<List<string>> QueryList();
        Task<List<object>> QueryNameList();
    }
}
	
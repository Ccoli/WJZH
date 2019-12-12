using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tuby.Api.IServices.BASE;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.IServices
{	
	/// <summary>
	/// d_alarm_sourceServices
	/// </summary>	
    public interface Id_alarm_sourceServices :IBaseServices<d_alarm_source>
	{
        Task<List<string>> QueryList();
        Task<List<object>> QueryNameList();
    }
}

	
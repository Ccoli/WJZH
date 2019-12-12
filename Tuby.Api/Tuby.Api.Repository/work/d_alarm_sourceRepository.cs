using System;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tuby.Api.Repository
{	
	/// <summary>
	/// d_alarm_sourceRepository
	/// </summary>	
	public class d_alarm_sourceRepository : BaseRepository<d_alarm_source>, Id_alarm_sourceRepository
    {
        public async Task<List<string>> QueryList()
        {
            return await QueryField(s=>s.TopicName);
        }
        public async Task<List<object>> QueryNameList()
        {
            return await QueryField(s => new {
                s.ID,
                s.TopicName
            });
        }
    }
}

	
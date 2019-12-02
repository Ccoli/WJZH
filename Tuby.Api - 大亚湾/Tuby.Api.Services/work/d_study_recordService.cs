using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_study_recordServices
	/// </summary>	
	public class d_study_recordServices : BaseServices<d_study_record>, Id_study_recordServices
    {
	
        Id_study_recordRepository dal;
        public d_study_recordServices(Id_study_recordRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
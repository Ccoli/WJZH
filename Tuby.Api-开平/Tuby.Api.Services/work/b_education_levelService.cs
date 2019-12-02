using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_education_levelServices
	/// </summary>	
	public class b_education_levelServices : BaseServices<b_education_level>, Ib_education_levelServices
    {
	
        Ib_education_levelRepository dal;
        public b_education_levelServices(Ib_education_levelRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
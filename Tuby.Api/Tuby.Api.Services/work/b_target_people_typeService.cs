using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_target_people_typeServices
	/// </summary>	
	public class b_target_people_typeServices : BaseServices<b_target_people_type>, Ib_target_people_typeServices
    {
	
        Ib_target_people_typeRepository dal;
        public b_target_people_typeServices(Ib_target_people_typeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
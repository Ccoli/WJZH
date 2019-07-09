using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_data_access_typeServices
	/// </summary>	
	public class a_data_access_typeServices : BaseServices<a_data_access_type>, Ia_data_access_typeServices
    {
	
        Ia_data_access_typeRepository dal;
        public a_data_access_typeServices(Ia_data_access_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
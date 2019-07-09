using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_phone_table_typeServices
	/// </summary>	
	public class b_phone_table_typeServices : BaseServices<b_phone_table_type>, Ib_phone_table_typeServices
    {
	
        Ib_phone_table_typeRepository dal;
        public b_phone_table_typeServices(Ib_phone_table_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
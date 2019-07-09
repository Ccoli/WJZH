using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_shaowei_typeServices
	/// </summary>	
	public class b_shaowei_typeServices : BaseServices<b_shaowei_type>, Ib_shaowei_typeServices
    {
	
        Ib_shaowei_typeRepository dal;
        public b_shaowei_typeServices(Ib_shaowei_typeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
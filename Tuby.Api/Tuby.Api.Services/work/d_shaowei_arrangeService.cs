using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_shaowei_arrangeServices
	/// </summary>	
	public class d_shaowei_arrangeServices : BaseServices<d_shaowei_arrange>, Id_shaowei_arrangeServices
    {
	
        Id_shaowei_arrangeRepository dal;
        public d_shaowei_arrangeServices(Id_shaowei_arrangeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
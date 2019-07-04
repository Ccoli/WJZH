using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_zhd_architectureServices
	/// </summary>	
	public class b_zhd_architectureServices : BaseServices<b_zhd_architecture>, Ib_zhd_architectureServices
    {
	
        Ib_zhd_architectureRepository dal;
        public b_zhd_architectureServices(Ib_zhd_architectureRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
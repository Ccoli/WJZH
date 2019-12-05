using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_handle_infoServices
	/// </summary>	
	public class d_handle_infoServices : BaseServices<d_handle_info>, Id_handle_infoServices
    {
	
        Id_handle_infoRepository dal;
        public d_handle_infoServices(Id_handle_infoRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
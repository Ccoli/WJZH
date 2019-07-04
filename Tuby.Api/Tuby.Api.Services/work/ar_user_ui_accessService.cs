using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ar_user_ui_accessServices
	/// </summary>	
	public class ar_user_ui_accessServices : BaseServices<ar_user_ui_access>, Iar_user_ui_accessServices
    {
	
        Iar_user_ui_accessRepository dal;
        public ar_user_ui_accessServices(Iar_user_ui_accessRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
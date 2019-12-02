using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_ui_accessServices
	/// </summary>	
	public class a_ui_accessServices : BaseServices<a_ui_access>, Ia_ui_accessServices
    {
	
        Ia_ui_accessRepository dal;
        public a_ui_accessServices(Ia_ui_accessRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
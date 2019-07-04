using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// a_ui_access_typeServices
	/// </summary>	
	public class a_ui_access_typeServices : BaseServices<a_ui_access_type>, Ia_ui_access_typeServices
    {
	
        Ia_ui_access_typeRepository dal;
        public a_ui_access_typeServices(Ia_ui_access_typeRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
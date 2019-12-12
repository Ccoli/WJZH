using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// d_poeple_attributeServices
	/// </summary>	
	public class d_poeple_attributeServices : BaseServices<d_poeple_attribute>, Id_poeple_attributeServices
    {
	
        Id_poeple_attributeRepository dal;
        public d_poeple_attributeServices(Id_poeple_attributeRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
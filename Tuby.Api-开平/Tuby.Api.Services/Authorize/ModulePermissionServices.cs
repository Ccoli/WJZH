using Tuby.Api.Services.BASE;
using Tuby.Api.Model.Models;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ModulePermissionServices
	/// </summary>	
	public class ModulePermissionServices : BaseServices<ModulePermission>, IModulePermissionServices
    {
	
        IModulePermissionRepository _dal;
        public ModulePermissionServices(IModulePermissionRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }
       
    }
}

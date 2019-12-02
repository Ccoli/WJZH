using Tuby.Api.IServices.BASE;
using Tuby.Api.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tuby.Api.IServices
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
    public interface IRoleModulePermissionServices :IBaseServices<RoleModulePermission>
	{

        Task<List<RoleModulePermission>> GetRoleModule();
        Task<List<RoleModulePermission>> TestModelWithChildren();
        
    }
}

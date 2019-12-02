using Tuby.Api.IRepository.Base;
using Tuby.Api.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tuby.Api.IRepository
{	
	/// <summary>
	/// IRoleModulePermissionRepository
	/// </summary>	
	public interface IRoleModulePermissionRepository : IBaseRepository<RoleModulePermission>//类名
    {
        Task<List<RoleModulePermission>> WithChildrenModel();
    }
}

using Tuby.Api.IServices.BASE;
using Tuby.Api.Model.Models;
using System.Threading.Tasks;

namespace Tuby.Api.IServices
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
    public interface IRoleServices :IBaseServices<Role>
	{
        Task<Role> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);

    }
}

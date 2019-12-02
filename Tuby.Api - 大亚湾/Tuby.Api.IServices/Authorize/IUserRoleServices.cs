using Tuby.Api.IServices.BASE;
using Tuby.Api.Model.Models;
using System.Threading.Tasks;

namespace Tuby.Api.IServices
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserRoleServices :IBaseServices<UserRole>
	{

        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}


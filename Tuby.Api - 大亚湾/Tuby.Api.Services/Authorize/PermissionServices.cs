using Tuby.Api.Services.BASE;
using Tuby.Api.Model.Models;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// PermissionServices
	/// </summary>	
	public class PermissionServices : BaseServices<Permission>, IPermissionServices
    {
	
        IPermissionRepository _dal;
        public PermissionServices(IPermissionRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }
       
    }
}

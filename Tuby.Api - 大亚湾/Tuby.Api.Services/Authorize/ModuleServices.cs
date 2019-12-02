using Tuby.Api.Services.BASE;
using Tuby.Api.Model.Models;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Module>, IModuleServices
    {
	
        IModuleRepository _dal;
        public ModuleServices(IModuleRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }
       
    }
}

using Tuby.Api.Services.BASE;
using Tuby.Api.Model.Models;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// MenuServices
	/// </summary>	
	public class MenuServices : BaseServices<Menu>, IMenuServices
    {
	
        IMenuRepository _dal;
        public MenuServices(IMenuRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }
       
    }
}

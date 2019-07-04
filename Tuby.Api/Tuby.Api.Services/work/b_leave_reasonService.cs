using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// b_leave_reasonServices
	/// </summary>	
	public class b_leave_reasonServices : BaseServices<b_leave_reason>, Ib_leave_reasonServices
    {
	
        Ib_leave_reasonRepository dal;
        public b_leave_reasonServices(Ib_leave_reasonRepository dal)
        {
            this.dal = dal;
        }
       
    }
}
	
	
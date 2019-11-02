using System;
using Tuby.Api.Model;
using Tuby.Api.IRepository;
using Tuby.Api.IServices;
using Tuby.Api.Services.BASE;
using Tuby.Api.Model.viewmodels;

namespace Tuby.Api.Services
{	
	/// <summary>
	/// topicsdkjgServices
	/// </summary>	
	public class topicsdkjgServices : BaseServices<topicsdkjg>, ItopicsdkjgServices
    {
	
        ItopicsdkjgRepository dal;
        public topicsdkjgServices(ItopicsdkjgRepository dal)
        {
            this.dal = dal;
			base.baseDal = dal;
        }
       
    }
}
	
	
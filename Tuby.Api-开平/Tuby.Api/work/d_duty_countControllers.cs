using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_duty_countControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class d_duty_countController : ControllerBase
    { 
		 readonly Id_duty_countServices _d_duty_countServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_duty_countController(Id_duty_countServices d_duty_countServices)
        {
            _d_duty_countServices = d_duty_countServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_duty_count>> Get()
        {
            return await _d_duty_countServices.Query();
        }

         /// <summary>
		///更新数据
		/// </summary>
        [HttpPost]
        [Route("update")]
        public async Task<MessageModel<string>> Update([FromBody] d_duty_count d_duty_count)
        {
			var data = new MessageModel<string>();
            if (d_duty_count.id==0)
            {
                var id = (await _d_duty_countServices.Update(d_duty_count));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为0的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为0的数据不存在";
                }
            }

            return data;
        }
    }
}

	
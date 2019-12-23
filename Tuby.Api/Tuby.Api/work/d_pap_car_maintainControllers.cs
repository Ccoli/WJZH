using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_pap_car_maintainControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class d_pap_car_maintainController : ControllerBase
    { 
		 readonly Id_pap_car_maintainServices _d_pap_car_maintainServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_pap_car_maintainController(Id_pap_car_maintainServices d_pap_car_maintainServices)
        {
            _d_pap_car_maintainServices = d_pap_car_maintainServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_pap_car_maintain>> Get()
        {
            Expression<Func<d_pap_car_maintain, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_pap_car_maintainServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<d_pap_car_maintain>> GetPage(int page)
        {
            Expression<Func<d_pap_car_maintain, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_pap_car_maintainServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_pap_car_maintain>> Get(int id)
        {
            return await _d_pap_car_maintainServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_pap_car_maintain d_pap_car_maintain)
        {
			var data = new MessageModel<string>();
            d_pap_car_maintain.Guid = Guid.NewGuid().ToString();
            var id = (await _d_pap_car_maintainServices.Add(d_pap_car_maintain));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

         /// <summary>
		///更新数据
		/// </summary>
        [HttpPost]
        [Route("update")]
        public async Task<MessageModel<string>> Update([FromBody] d_pap_car_maintain d_pap_car_maintain)
        {
			var data = new MessageModel<string>();
            if (d_pap_car_maintain != null)
            {
                var id = (await _d_pap_car_maintainServices.Update(d_pap_car_maintain));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_pap_car_maintain.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_pap_car_maintain.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// 根据id使用get方法删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
        public async Task<MessageModel<string>> Delete(string id)
        {
            var data = new MessageModel<string>();
            if (id != "")
            {
                var model = await _d_pap_car_maintainServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _d_pap_car_maintainServices.Update(model);
                data.success = flag;
                if (flag)
                {
                    data.response = id.ToString() + "数据删除";
                    data.msg = "删除成功";
                }
                else
                {
                    data.response = "id为" + id.ToString() + "的数据找不到";
                    data.msg = "删除失败";
                }
            }

            return data;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletemuch")]
        public async Task<MessageModel<string>> DeleteMuch([FromBody] object[] id)
        {
            var list = await _d_pap_car_maintainServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _d_pap_car_maintainServices.Update(list);
            var data = new MessageModel<string>();
            data.success = flag;
            if (flag)
            {
                data.response = string.Join(",", id) + "数据删除";
                data.msg = "删除成功";
            }
            else
            {
                data.response = "id为" + id.ToString() + "的数据找不到";
                data.msg = "删除失败";
            }

            return data;
        }
    }
}

	
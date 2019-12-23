using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;
using Microsoft.AspNetCore.Authorization;
using Tuby.Api.Model.viewmodels;
using System.Linq.Expressions;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_alarm_businessControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class d_alarm_businessController : ControllerBase
    { 
		 readonly Id_alarm_businessServices _d_alarm_businessServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_businessController(Id_alarm_businessServices d_alarm_businessServices)
        {
            _d_alarm_businessServices = d_alarm_businessServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
         [AllowAnonymous]
        public async Task<List<d_alarm_business>> Get()
        {
            Expression<Func<d_alarm_business, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_businessServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        [AllowAnonymous]
        public async Task<PageModel<d_alarm_business>> GetPage(int page)
        {
            Expression<Func<d_alarm_business, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_businessServices.Query(whereExpression, page, 10, "");
        }


        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<List<d_alarm_business>> Get(int id)
        {
            return await _d_alarm_businessServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_alarm_business d_alarm_business)
        {
			var data = new MessageModel<string>();
            d_alarm_business.UpdateTime = DateTime.Now;
            var id = (await _d_alarm_businessServices.Add(d_alarm_business));
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
        public async Task<MessageModel<string>> Update([FromBody] d_alarm_business d_alarm_business)
        {
			var data = new MessageModel<string>();
            if (d_alarm_business != null && d_alarm_business.ID > 0)
            {
                d_alarm_business.UpdateTime = DateTime.Now;
                var id = (await _d_alarm_businessServices.Update(d_alarm_business));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_alarm_business.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_alarm_business.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
		/// 根据id使用get方法删除数据
		/// </summary>
        [HttpGet]
        [Route("delete")]
		 public async Task<MessageModel<string>> Delete(int id)
        {
            var data = new MessageModel<string>();
            if (id > 0)
            {
                var model = await _d_alarm_businessServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _d_alarm_businessServices.Update(model);
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
            var list = await _d_alarm_businessServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _d_alarm_businessServices.Update(list);
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

	
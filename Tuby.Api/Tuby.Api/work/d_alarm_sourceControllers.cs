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
	/// d_alarm_sourceControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    [AllowAnonymous]
    public class d_alarm_sourceController : ControllerBase
    { 
		 readonly Id_alarm_sourceServices _d_alarm_sourceServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_alarm_sourceController(Id_alarm_sourceServices d_alarm_sourceServices)
        {
            _d_alarm_sourceServices = d_alarm_sourceServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
         [AllowAnonymous]
        public async Task<List<d_alarm_source>> Get()
        {
            //return await _d_alarm_sourceServices.Query();
            Expression<Func<d_alarm_source, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_sourceServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        [AllowAnonymous]
        public async Task<PageModel<d_alarm_source>> GetPage(int page)
        {
            Expression<Func<d_alarm_source, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_alarm_sourceServices.Query(whereExpression, page, 10, "");
        }
        /// <summary>
        /// 查询主题名字列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getname")]
        public async Task<Dictionary<string, List<object>>> Getname()
        {
            Dictionary<string, List<object>> data = new Dictionary<string, List<object>>();
                
            data.Add("data", await _d_alarm_sourceServices.QueryNameList());
            return data;
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<List<d_alarm_source>> Get(int id)
        {
            return await _d_alarm_sourceServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_alarm_source d_alarm_source)
        {
			var data = new MessageModel<string>();
            d_alarm_source.UpdateTime = DateTime.Now;
            var id = (await _d_alarm_sourceServices.Add(d_alarm_source));
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
        public async Task<MessageModel<string>> Update([FromBody] d_alarm_source d_alarm_source)
        {
			var data = new MessageModel<string>();
            if (d_alarm_source != null && d_alarm_source.ID > 0)
            {
                d_alarm_source.UpdateTime = DateTime.Now;
                var id = (await _d_alarm_sourceServices.Update(d_alarm_source));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_alarm_source.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_alarm_source.ID.ToString() + "的数据不存在";
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
            if (id >0)
            {
                var model = await _d_alarm_sourceServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _d_alarm_sourceServices.Update(model);
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
            var list = await _d_alarm_sourceServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _d_alarm_sourceServices.Update(list);
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

	
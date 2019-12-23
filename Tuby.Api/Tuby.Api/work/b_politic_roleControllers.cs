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
	/// b_politic_roleControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class b_politic_roleController : ControllerBase
    { 
		 readonly Ib_politic_roleServices _b_politic_roleServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_politic_roleController(Ib_politic_roleServices b_politic_roleServices)
        {
            _b_politic_roleServices = b_politic_roleServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_politic_role>> Get()
        {
            Expression<Func<b_politic_role, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_politic_roleServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<b_politic_role>> GetPage(int page)
        {
            Expression<Func<b_politic_role, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_politic_roleServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_politic_role>> Get(int id)
        {
            return await _b_politic_roleServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_politic_role b_politic_role)
        {
			var data = new MessageModel<string>();

            var id = (await _b_politic_roleServices.Add(b_politic_role));
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
        public async Task<MessageModel<string>> Update([FromBody] b_politic_role b_politic_role)
        {
			var data = new MessageModel<string>();
            if (b_politic_role != null && b_politic_role.ID > 0)
            {
                var id = (await _b_politic_roleServices.Update(b_politic_role));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_politic_role.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_politic_role.ID.ToString() + "的数据不存在";
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
                var model = await _b_politic_roleServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _b_politic_roleServices.Update(model);
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
            var list = await _b_politic_roleServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _b_politic_roleServices.Update(list);
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

	
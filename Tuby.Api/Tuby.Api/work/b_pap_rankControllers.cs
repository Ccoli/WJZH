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
	/// b_pap_rankControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class b_pap_rankController : ControllerBase
    { 
		 readonly Ib_pap_rankServices _b_pap_rankServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_pap_rankController(Ib_pap_rankServices b_pap_rankServices)
        {
            _b_pap_rankServices = b_pap_rankServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_pap_rank>> Get()
        {
            Expression<Func<b_pap_rank, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_pap_rankServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<b_pap_rank>> GetPage(int page)
        {
            Expression<Func<b_pap_rank, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_pap_rankServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_pap_rank>> Get(int id)
        {
            return await _b_pap_rankServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_pap_rank b_pap_rank)
        {
			var data = new MessageModel<string>();

            var id = (await _b_pap_rankServices.Add(b_pap_rank));
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
        public async Task<MessageModel<string>> Update([FromBody] b_pap_rank b_pap_rank)
        {
			var data = new MessageModel<string>();
            if (b_pap_rank != null && b_pap_rank.ID > 0)
            {
                var id = (await _b_pap_rankServices.Update(b_pap_rank));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_pap_rank.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_pap_rank.ID.ToString() + "的数据不存在";
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
                var model = await _b_pap_rankServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _b_pap_rankServices.Update(model);
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
            var list = await _b_pap_rankServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _b_pap_rankServices.Update(list);
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

	
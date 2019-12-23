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
	/// b_device_typeControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class b_device_typeController : ControllerBase
    { 
		 readonly Ib_device_typeServices _b_device_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public b_device_typeController(Ib_device_typeServices b_device_typeServices)
        {
            _b_device_typeServices = b_device_typeServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<b_device_type>> Get()
        {
            Expression<Func<b_device_type, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_device_typeServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<b_device_type>> GetPage(int page)
        {
            Expression<Func<b_device_type, bool>> whereExpression = a => a.IsDeleted != true;
            return await _b_device_typeServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<b_device_type>> Get(int id)
        {
            return await _b_device_typeServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] b_device_type b_device_type)
        {
			var data = new MessageModel<string>();

            var id = (await _b_device_typeServices.Add(b_device_type));
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
        public async Task<MessageModel<string>> Update([FromBody] b_device_type b_device_type)
        {
			var data = new MessageModel<string>();
            if (b_device_type != null && b_device_type.ID > 0)
            {
                var id = (await _b_device_typeServices.Update(b_device_type));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +b_device_type.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +b_device_type.ID.ToString() + "的数据不存在";
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
                var model = await _b_device_typeServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _b_device_typeServices.Update(model);
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
            //var flag = (await _b_device_typeServices.DeleteByIds(id));
            var list = await _b_device_typeServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _b_device_typeServices.Update(list);
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

	
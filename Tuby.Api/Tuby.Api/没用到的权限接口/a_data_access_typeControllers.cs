using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.Model;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// a_data_access_typeControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
	public class a_data_access_typeController : ControllerBase
    { 
		 readonly Ia_data_access_typeServices _a_data_access_typeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public a_data_access_typeController(Ia_data_access_typeServices a_data_access_typeServices)
        {
            _a_data_access_typeServices = a_data_access_typeServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<a_data_access_type>> Get()
        {
            return await _a_data_access_typeServices.Query();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<a_data_access_type>> GetPage(int page)
        {
            return await _a_data_access_typeServices.Query("", page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<a_data_access_type>> Get(int id)
        {
            return await _a_data_access_typeServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] a_data_access_type a_data_access_type)
        {
			var data = new MessageModel<string>();

            var id = (await _a_data_access_typeServices.Add(a_data_access_type));
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
        public async Task<MessageModel<string>> Update([FromBody] a_data_access_type a_data_access_type)
        {
			var data = new MessageModel<string>();
            if (a_data_access_type != null && a_data_access_type.ID > 0)
            {
                var id = (await _a_data_access_typeServices.Update(a_data_access_type));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +a_data_access_type.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +a_data_access_type.ID.ToString() + "的数据不存在";
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
            var flag = (await _a_data_access_typeServices.DeleteById(id));
            var data = new MessageModel<string>();
            data.success = flag;
            if (flag)
            {
                data.response = id.ToString()+"数据删除";
                data.msg = "删除成功";
            }
            else
            {
                data.response ="id为"+ id.ToString() + "的数据找不到";
                data.msg = "删除失败";
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
            var flag = (await _a_data_access_typeServices.DeleteByIds(id));
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

	
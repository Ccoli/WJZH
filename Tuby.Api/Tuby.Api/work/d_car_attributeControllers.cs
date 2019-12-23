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
	/// d_car_attributeControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    [AllowAnonymous]
    public class d_car_attributeController : ControllerBase
    { 
		 readonly Id_car_attributeServices _d_car_attributeServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_car_attributeController(Id_car_attributeServices d_car_attributeServices)
        {
            _d_car_attributeServices = d_car_attributeServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
        public async Task<List<d_car_attribute>> Get()
        {
            Expression<Func<d_car_attribute, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_car_attributeServices.Query(whereExpression);
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        public async Task<PageModel<d_car_attribute>> GetPage(int page)
        {
            Expression<Func<d_car_attribute, bool>> whereExpression = a => a.IsDeleted != true;
            return await _d_car_attributeServices.Query(whereExpression, page, 10, "");
        }

        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        public async Task<List<d_car_attribute>> Get(string id)
        {
            return await _d_car_attributeServices.Query(c => c.Guid == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_car_attribute d_car_attribute)
        {
			var data = new MessageModel<string>();
            d_car_attribute.Guid = Guid.NewGuid().ToString();
            var id = (await _d_car_attributeServices.Add(d_car_attribute));
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
        public async Task<MessageModel<string>> Update([FromBody] d_car_attribute d_car_attribute)
        {
			var data = new MessageModel<string>();
            if (d_car_attribute != null )
            {
                var id = (await _d_car_attributeServices.Update(d_car_attribute));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_car_attribute.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_car_attribute.ID.ToString() + "的数据不存在";
                }
            }

            return data;
        }

        /// <summary>
        ///更新处置状态数据
        /// </summary>
        [HttpPost]
        [Route("updatestatus")]
        public async Task<MessageModel<string>> UpdateStatus(string id)
        {
            var data = new MessageModel<string>();
            var alarmInfo = (await _d_car_attributeServices.Query(c => c.HandleID == id)).FirstOrDefault();
            alarmInfo.RecStatus = 1;
            //d_handle_info.Guid = Guid.NewGuid().ToString();
            var flag = await _d_car_attributeServices.Update(alarmInfo);
            data.success = flag;
            if (data.success)
            {
                data.response = "数据更新成功";
                data.msg = "更新成功";
            }
            else
            {
                data.response = "数据不存在";
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
                var model = await _d_car_attributeServices.QueryByID(id);
                model.IsDeleted = true;
                var flag = await _d_car_attributeServices.Update(model);
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
            var list = await _d_car_attributeServices.QueryByIDs(id);
            foreach (var item in list)
            {
                item.IsDeleted = true;
            }
            var flag = await _d_car_attributeServices.Update(list);
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

	
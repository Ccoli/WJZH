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

namespace Tuby.Api.Controllers
{	
	/// <summary>
	/// d_soldierControllers
	/// </summary>	
	[Produces("application/json")]
	[Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class d_soldierController : ControllerBase
    { 
		 readonly Id_soldierServices _d_soldierServices;

		 /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public d_soldierController(Id_soldierServices d_soldierServices)
        {
            _d_soldierServices = d_soldierServices;
        }
		/// <summary>
		///查询所有数据
		/// </summary>	
		 [HttpGet]
         [AllowAnonymous]
        public async Task<List<d_soldier>> Get()
        {
            return await _d_soldierServices.Query();
        }

		/// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage")]
        [AllowAnonymous]
        public async Task<PageModel<d_soldier>> GetPage(int page)
        {
            return await _d_soldierServices.Query("", page, 10, "");
        }
        /// <summary>
        /// 查询名字列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getname")]
        public async Task<List<object>> Getname()
        {
            return await _d_soldierServices.QueryNameList();
        }
        /// <summary>
        /// 获取统计信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getcount")]
        [AllowAnonymous]
        public async Task<CountSoldierEntity> GetCount()
        {
            return await _d_soldierServices.GetCount();
        }
        /// <summary>
		///根据id查询数据
		/// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<List<d_soldier>> Get(int id)
        {
            return await _d_soldierServices.Query(c => c.ID == id);
        }

        /// <summary>
		/// 使用post方法添加数据
		/// </summary>
        [HttpPost]
       public async Task<MessageModel<string>> Post([FromBody] d_soldier d_soldier)
        {
			var data = new MessageModel<string>();
            d_soldier.UpdateTime = DateTime.Now;
            var id = (await _d_soldierServices.Add(d_soldier));
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
        public async Task<MessageModel<string>> Update([FromBody] d_soldier d_soldier)
        {
			var data = new MessageModel<string>();
            if (d_soldier != null && d_soldier.ID > 0)
            {
                d_soldier.UpdateTime = DateTime.Now;
                var id = (await _d_soldierServices.Update(d_soldier));
                data.success = id;
                if (data.success)
                {
                    data.response = "id为" +d_soldier.ID.ToString() + "的数据更新成功";
                    data.msg = "更新成功";
                }
                else
                {
                    data.response = "id为" +d_soldier.ID.ToString() + "的数据不存在";
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
            var flag = (await _d_soldierServices.DeleteById(id));
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
            var flag = (await _d_soldierServices.DeleteByIds(id));
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

	
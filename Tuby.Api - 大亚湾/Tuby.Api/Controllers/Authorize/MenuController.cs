using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tuby.Api.Common.HttpContextUser;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tuby.Api.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class MenuController : ControllerBase
    {
        readonly IMenuServices _MenuServices;
        readonly IUser _user;

       
        public MenuController(IMenuServices MenuServices, IUser user)
        {
            _MenuServices = MenuServices;
            _user = user;
        }

        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <param name="page"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        // GET: api/User
        [HttpGet]
        public async Task<MessageModel<PageModel<Menu>>> Get(int page = 1, string key = "")
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
            {
                key = "";
            }
            int intPageSize = 50;

            Expression<Func<Menu, bool>> whereExpression = a => a.IsDeleted != true && (a.MenuName != null && a.MenuName.Contains(key));

            var data = await _MenuServices.QueryPage(whereExpression, page, intPageSize, " Id desc ");

            return new MessageModel<PageModel<Menu>>()
            {
                msg = "获取成功",
                success = data.dataCount >= 0,
                response = data
            };

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        /// <summary>
        /// 添加一条菜单信息
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        // POST: api/User
        [HttpPost]
        public async Task<MessageModel<string>> Post([FromBody] Menu Menu)
        {
            var data = new MessageModel<string>();

            //Menu.CreateId = _user.ID;
           // Menu.CreateBy = _user.Name;

            var id = (await _MenuServices.Add(Menu));
            data.success = id > 0;
            if (data.success)
            {
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }

            return data;
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="Menu"></param>
        /// <returns></returns>
        // PUT: api/User/5
        [HttpPut]
        public async Task<MessageModel<string>> Put([FromBody] Menu Menu)
        {
            var data = new MessageModel<string>();
            if (Menu != null && Menu.Id > 0)
            {
                data.success = await _MenuServices.Update(Menu);
                if (data.success)
                {
                    data.msg = "更新成功";
                    data.response = Menu?.Id.ObjToString();
                }
            }

            return data;
        }

        /// <summary>
        /// 删除一条菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<MessageModel<string>> Delete(int id)
        {
            var data = new MessageModel<string>();
            if (id > 0)
            {
                var userDetail = await _MenuServices.QueryByID(id);
                userDetail.IsDeleted = true;
                data.success = await _MenuServices.Update(userDetail);
                if (data.success)
                {
                    data.msg = "删除成功";
                    data.response = userDetail?.Id.ObjToString();
                }
            }

            return data;
        }
    }
}

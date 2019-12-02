using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.AuthHelper.OverWrite;
using Tuby.Api.IServices;

namespace Tuby.Api.Controllers.Authorize
{
    [Authorize("Permission")]
    [Route("api/[controller]")]
    [ApiController]
    public class Login1Controller : ControllerBase
    {
        readonly ISysUserInfoServices _sysUserInfoServices;


        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="sysUserInfoServices"></param>
   
        public Login1Controller(ISysUserInfoServices sysUserInfoServices)
        {
            this._sysUserInfoServices = sysUserInfoServices;
        }
        // GET: api/Login1
        [HttpGet]
        public async Task<object> GetJwtStr(string name, string pass)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            // 获取用户的角色名，请暂时忽略其内部是如何获取的，可以直接用 var userRole="Admin"; 来代替更好理解。
            var userRole = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
             //var userRole="Admin";
            if (userRole != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = userRole };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }

        // GET: api/Login1/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login1
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Login1/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

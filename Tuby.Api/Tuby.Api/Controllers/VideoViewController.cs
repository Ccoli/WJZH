using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuby.Api.IServices;
using Tuby.Api.Model;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.Services;

namespace Tuby.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class VideoViewController : ControllerBase
    {
        readonly IVideoViewServices _VideoViewServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public VideoViewController(IVideoViewServices VideoViewServices)
        {
            _VideoViewServices = VideoViewServices;
        }
        // GET: api/VideoView
        [HttpGet]
        [Route("getlist")]
        [AllowAnonymous]
        public async Task<List<VideoNodeData>> GetAsync()
        {
            return await _VideoViewServices.GetListData();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<VideoView>> Get()
        {
            return await _VideoViewServices.Query();
        }

        /// <summary>
        ///根据id查询数据
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<List<VideoView>> Get(string id)
        {
            return await _VideoViewServices.Query(c => c.DeviceId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuby.Api.Model;

namespace Tuby.Api.Model
{
    public class VideoView:d_video_base
    {

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName { get; set; }
    }
}

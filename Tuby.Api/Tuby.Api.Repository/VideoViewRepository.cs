using System;
using System.Collections.Generic;
using System.Text;
using Tuby.Api.Repository.Base;
using Tuby.Api.Model.viewmodels;
using Tuby.Api.IRepositoty;
using System.Threading.Tasks;
using Tuby.Api.Model;
using SqlSugar;

namespace Tuby.Api.Repository
{
    public class VideoViewRepository:BaseRepository<VideoView>, IVideoViewRepository
    {
        public async Task<List<VideoView>> QueryMuchTable()
        {
            return await QueryMuch<d_video_base, d_video_user,b_video_type, VideoView>(
                    (dvb, dvu,bvt) => new object[] {
                JoinType.Left,dvb.UserID==dvu.ID,
                JoinType.Left,dvb.VideoTypeID==bvt.ID
                    },null
                    );
        }
    }
}

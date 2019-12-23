using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class FaceAlarmYFT
    {
        public string CameraId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public string Type { set; get; }        //报警种类0：人，1：机动车，2：非机动车   
        public string EventType { set; get; }   //报警类型
        public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
        public string Guid { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string HandleID { get; set; }
        public Dictionary<string, string> FaceInfo { set; get; } //人脸识别信息

    }
}

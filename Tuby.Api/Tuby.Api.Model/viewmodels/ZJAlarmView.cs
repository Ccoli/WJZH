using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class ZJAlarmView
    {
        // {"CameraId":"40cda183-a8ce-4a48-8eca-c60fa456c2ff","ImageUrl":"http://192.168.18.155:8012/40cda183-a8ce-4a48-8eca-c60fa456c2ff/2019-11-21-14-20-23.jpg","Type":1,"EventType":"wireCross","Feature":"","time":"2019-11-21 14:19:16"}
        public string CameraId { set; get; }   //报警设备ID 
        public string ImageUrl { set; get; }   //报警截图 
        public int Type { set; get; }        //报警种类0：人，1：机动车，2：非机动车   
        public string EventType { set; get; }   //报警类型
        public string Feature { set; get; }   //特征
        public string time { set; get; }   //报警时间（格式：yyyy-MM-dd HH:mm:ss）
        public Dictionary<string, string> FaceInfo { set; get; } //人脸识别信息
        public Dictionary<string, string> MixedDetect { set; get; } //混合检测信息

    }
}

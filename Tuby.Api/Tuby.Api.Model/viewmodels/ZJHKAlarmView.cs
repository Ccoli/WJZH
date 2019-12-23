using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class ZJHKAlarmView
    {
        // {"CameraId":"40cda183-a8ce-4a48-8eca-c60fa456c2ff","ImageUrl":"http://192.168.18.155:8012/40cda183-a8ce-4a48-8eca-c60fa456c2ff/2019-11-21-14-20-23.jpg","Type":1,"EventType":"wireCross","Feature":"","time":"2019-11-21 14:19:16"}
        public string ImageUrl { set; get; }   //报警截图 
        public string AlarmTypeDesc { set; get; }   //报警信息
        public int AlarmTypeId { set; get; }   //报警类型信息
        public int Business { set; get; }   //业务线
        public string DeviceId { set; get; }   //设备id
        public string Guid { set; get; }   //guid

    }
}

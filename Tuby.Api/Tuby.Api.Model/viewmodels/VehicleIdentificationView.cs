using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model.viewmodels
{
    public class VehicleIdentificationView
    {
        /// <summary>
        /// id
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 业务线
        /// </summary>
        public int Business { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public int PlateColor { get; set; }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public string PlateColorString { get; set; }

        /// <summary>
        /// 车牌号码
        /// </summary>
        public string PlateNumber { get; set; }
        /// <summary>
        /// 车牌类型
        /// </summary>
        public string PlateType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlateTypeString { get; set; }
        /// <summary>
        /// 车辆类型 0 表示其它车型，1 表示小型车，2 表示大型车 ,3表示行人触发 ,4表示二轮车触发 5表示三轮车触发(3.5Ver)
        /// </summary>
        public string VehicleType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VehicleTypeString { get; set; }
        /// <summary>
        /// 车身颜色
        /// </summary>
        public string VehicleColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VehicleColorString { get; set; }
        /// <summary>
        /// 汽车品牌
        /// </summary>
        public string byVehicleLogoRecog { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string byVehicleLogoRecogString { get; set; }
        /// <summary>
        /// 车辆主品牌(该字段兼容 byVehicleLogoRecog)
        /// </summary>
        public string wVehicleLogoRecog { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wVehicleLogoRecogString { get; set; }
    }
}

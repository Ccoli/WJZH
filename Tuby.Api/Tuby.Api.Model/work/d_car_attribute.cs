using System;
using System.Collections.Generic;
using System.Text;

namespace Tuby.Api.Model
{
    /// <summary>
    /// d_car_attribute Entity Model
    /// </summary>   
    [Serializable]
    public class d_car_attribute
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Mistake { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Licence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlateColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlateRect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlateType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VehicleColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VehicleType { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 报警类型
        /// </summary>
        public DateTime Time { get; set; }
    }
}

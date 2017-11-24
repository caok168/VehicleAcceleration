using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    public class Line
    {
        /// <summary>
        /// ID 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 线路名缩写
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 线路名中文
        /// </summary>
        public string LineNameCn { get; set; }
    }
}

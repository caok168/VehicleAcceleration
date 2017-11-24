using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 线路信息
    /// </summary>
    public class LineInfo
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 线路类型
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 速度等级
        /// </summary>
        public double SpeedLevel { get; set; }

        /// <summary>
        /// 起始里程
        /// </summary>
        public double StartMile { get; set; }

        /// <summary>
        /// 结束里程
        /// </summary>
        public double EndMile { get; set; }
    }
}

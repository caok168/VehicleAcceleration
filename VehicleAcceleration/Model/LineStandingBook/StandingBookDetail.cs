using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 台账详情类
    /// </summary>
    public class StandingBookDetail
    {
        /// <summary>
        /// 开始里程
        /// </summary>
        public double StartMile { get; set; }

        /// <summary>
        /// 结束里程
        /// </summary>
        public double EndMile { get; set; }

        /// <summary>
        /// 台账类型
        /// </summary>
        public string Type { get; set; }
    }
}

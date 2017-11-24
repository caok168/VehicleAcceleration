using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 线路对应的台账信息表
    /// </summary>
    public class StandingBook
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 台账名称
        /// </summary>
        public string StandingBookName { get; set; }
    }
}

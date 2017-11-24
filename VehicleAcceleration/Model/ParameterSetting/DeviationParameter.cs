using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 偏差参数类（2*3的double数组）
    /// </summary>
    public class DeviationParameter
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 第一个值
        /// </summary>
        public double Value1_1 { get; set; }

        /// <summary>
        /// 第二个值
        /// </summary>
        public double Value1_2 { get; set; }

        /// <summary>
        /// 第三个值
        /// </summary>
        public double Value1_3 { get; set; }


        /// <summary>
        /// 第一个值
        /// </summary>
        public double Value2_1 { get; set; }

        /// <summary>
        /// 第二个值
        /// </summary>
        public double Value2_2 { get; set; }

        /// <summary>
        /// 第三个值
        /// </summary>
        public double Value2_3 { get; set; }
    }
}

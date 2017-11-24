using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 检测车有效值信息
    /// </summary>
    public class RmsMeanInfo
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 综合检测车
        /// </summary>
        public string SurveyVehicle { get; set; }

        /// <summary>
        /// 线路类型
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 速度等级
        /// </summary>
        public double SpeedLevel { get; set; }

        /// <summary>
        /// 检测系统
        /// </summary>
        public string SurveySystem { get; set; }

        /// <summary>
        /// 有效值平均值（左轴垂）
        /// </summary>
        public double Rms_mean_LeftAxisVertical { get; set; }

        /// <summary>
        /// 有效值平均值（右轴垂）
        /// </summary>
        public double Rms_mean_RightAxisVertical { get; set; }

        /// <summary>
        /// 有效值平均值（左轴横）
        /// </summary>
        public double Rms_mean_LeftAxisHorizontal { get; set; }
    }
}

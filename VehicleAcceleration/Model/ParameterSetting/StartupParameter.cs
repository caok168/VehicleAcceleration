using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 启动参数类
    /// </summary>
    public class StartupParameter
    {
        /// <summary>
        /// 序号（自动增长列）
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 检测员姓名
        /// </summary>
        public string SurveyorName { get; set; }

        /// <summary>
        /// 检测车型号
        /// </summary>
        public string SurveyVehicleVersion { get; set; }

        /// <summary>
        /// 线路名
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 行别
        /// </summary>
        public string WalkType { get; set; }

        /// <summary>
        /// 增减里程类型
        /// </summary>
        public string MileageType { get; set; }

        /// <summary>
        /// 起始里程
        /// </summary>
        public double OrigialMileage { get; set; }

        /// <summary>
        /// 检测方向
        /// </summary>
        public string SurveyDirection { get; set; }

        /// <summary>
        /// 运行方向
        /// </summary>
        public string RunDirection { get; set; }
    }
}

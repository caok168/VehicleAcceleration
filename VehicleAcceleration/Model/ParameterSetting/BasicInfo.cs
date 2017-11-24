using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 运行一个线路的基本信息
    /// </summary>
    public class BasicInfo
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

        /// <summary>
        /// 运行日期
        /// </summary>
        public string RunDate { get; set; }

        /// <summary>
        /// 运行的时间
        /// </summary>
        public string RunTime { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 读取cit文件是否完成（0未完成、1为完成、2为异常）
        /// </summary>
        public int IsComplete { get; set; }

        /// <summary>
        /// 完成状态
        /// </summary>
        public string CompleteState { get; set; }

        /// <summary>
        /// 实际里程
        /// </summary>
        public double ActualMile { get; set; }

        /// <summary>
        /// 超过200公里
        /// </summary>
        public double MileMore200 { get; set; }
    }
}

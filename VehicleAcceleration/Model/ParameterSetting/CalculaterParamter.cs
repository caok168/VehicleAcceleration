using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 计算参数类
    /// </summary>
    public class CalculaterParamter
    {
        /// <summary>
        /// 序号（数据库中使用自动增长列）
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 计算时间（单位：秒）默认值：300（也就是5分钟）
        /// </summary>
        public int ComputingTime { get; set; }

        /// <summary>
        /// 采样频率（单位： HZ） 默认值：2000
        /// </summary>
        public int SamplingFrequency { get; set; }

        /// <summary>
        /// 有效值窗长（单位： 个） 默认值：60
        /// </summary>
        public int EffectiveValueLength { get; set; }

        /// <summary>
        /// 抽样点数（单位：个） 默认值：6
        /// </summary>
        public int SamplingPoints { get; set; }

        /// <summary>
        /// 速度等级（单位：KM/H） 默认值：300
        /// </summary>
        public int SpeedGrade { get; set; }

        /// <summary>
        /// 最大值统计窗长（单位：个/点） 200
        /// </summary>
        public int MaxValueLength { get; set; }

        /// <summary>
        /// 低速控制值（单位：KM/H）默认值：20
        /// </summary>
        public int LowSpeedControlValue { get; set; }

        /// <summary>
        /// 低速控制率 默认值：30%
        /// </summary>
        public double LowSpeedControlRate { get; set; }
    }
}

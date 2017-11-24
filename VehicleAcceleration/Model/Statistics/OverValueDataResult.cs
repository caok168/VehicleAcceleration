using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 超限类
    /// </summary>
    public class OverValueDataResult
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 通道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 通道ID
        /// </summary>
        public int ChannelID { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        public double Mile { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// 超限类型
        /// </summary>
        public string OverType { get; set; }

        /// <summary>
        /// 超限值（有效值/峰值）
        /// </summary>
        public double OverValueRms { get; set; }

        /// <summary>
        /// 轨道冲击指数
        /// </summary>
        public double OverValuePeak { get; set; }

        /// <summary>
        /// 超限长度
        /// </summary>
        public double OverLength { get; set; }

        /// <summary>
        /// 超限等级
        /// </summary>
        public string OverLevel { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public int IsValid { get; set; }

    }
}

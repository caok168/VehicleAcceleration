using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 通道参数类
    /// </summary>
    public class ChannelFreqParamter
    {
        /// <summary>
        /// 序号（数据库中使用自动增长列）
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 左轴垂下限频率
        /// </summary>
        public double LeftAxisVerticalLower { get; set; }

        /// <summary>
        /// 左轴垂上限频率
        /// </summary>
        public double LeftAxisVerticalUpper { get; set; }

        /// <summary>
        /// 右轴垂下限频率
        /// </summary>
        public double RightAxisVerticalLower { get; set; }

        /// <summary>
        /// 右轴垂上限频率
        /// </summary>
        public double RightAxisVerticalUpper { get; set; }

        /// <summary>
        /// 左轴横下限频率
        /// </summary>
        public double LeftAxisHorizontalLower { get; set; }

        /// <summary>
        /// 左轴横上限频率
        /// </summary>
        public double LeftAxisHorizontalUpper { get; set; }

        /// <summary>
        /// 构架垂下限频率
        /// </summary>
        public double FrameVerticalLower { get; set; }

        /// <summary>
        /// 构架垂上限频率
        /// </summary>
        public double FrameVerticalUpper { get; set; }

        /// <summary>
        /// 构架横下限频率
        /// </summary>
        public double FrameHorizontalLower { get; set; }

        /// <summary>
        /// 构架横上限频率
        /// </summary>
        public double FrameHorizontalUpper { get; set; }

        /// <summary>
        /// 车体垂下限频率
        /// </summary>
        public double BodyVerticalLower { get; set; }

        /// <summary>
        /// 车体垂上限频率
        /// </summary>
        public double BodyVerticalUpper { get; set; }

        /// <summary>
        /// 车体横下限频率
        /// </summary>
        public double BodyHorizontalLower { get; set; }

        /// <summary>
        /// 车体横上限频率
        /// </summary>
        public double BodyHorizontalUpper { get; set; }
    }
}

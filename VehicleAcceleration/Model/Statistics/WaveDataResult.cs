using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 波形数据结果类
    /// </summary>
    public class WaveDataResult
    {
        /// <summary>
        /// 自动增长列
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 平均速度
        /// </summary>
        public double AvgSpeed { get; set; }

        /// <summary>
        /// 开始里程
        /// </summary>
        public double StartMile { get; set; }

        /// <summary>
        /// 最大值发生的里程
        /// </summary>
        public double MaxValueMile { get; set; }

        /// <summary>
        /// 有效值或幅值
        /// </summary>
        public double RmsValue { get; set; }

        /// <summary>
        /// 轨道冲击指数
        /// </summary>
        public double PeakIndex { get; set; }

        /// <summary>
        /// 左轴垂（通道3）
        /// </summary>
        public double LeftAxisVertical_MaxValueMile { get; set; }
        /// <summary>
        /// 左轴垂（通道3）
        /// </summary>
        public double LeftAxisVertical_RmsValue { get; set; }
        /// <summary>
        /// 左轴垂（通道3）
        /// </summary>
        public double LeftAxisVertical_PeakIndex { get; set; }

        /// <summary>
        /// 右轴垂（通道4）
        /// </summary>
        public double RightAxisVertical_MaxValueMile { get; set; }
        /// <summary>
        /// 右轴垂（通道4）
        /// </summary>
        public double RightAxisVertical_RmsValue { get; set; }
        /// <summary>
        /// 右轴垂（通道4）
        /// </summary>
        public double RightAxisVertical_PeakIndex { get; set; }

        /// <summary>
        /// 左轴横（通道5）
        /// </summary>
        public double LeftAxisHorizontal_MaxValueMile { get; set; }
        /// <summary>
        /// 左轴横（通道5）
        /// </summary>
        public double LeftAxisHorizontal_RmsValue { get; set; }
        /// <summary>
        /// 左轴横（通道5）
        /// </summary>
        public double LeftAxisHorizontal_PeakIndex { get; set; }

        /// <summary>
        /// 构架垂（通道6）
        /// </summary>
        public double FrameVertical_MaxValueMile { get; set; }
        /// <summary>
        /// 构架垂（通道6）
        /// </summary>
        public double FrameVertical_RmsValue { get; set; }
        /// <summary>
        /// 构架垂（通道6）
        /// </summary>
        public double FrameVertical_PeakIndex { get; set; }

        /// <summary>
        /// 构架横（通道7）
        /// </summary>
        public double FrameHorizontal_MaxValueMile { get; set; }
        /// <summary>
        /// 构架横（通道7）
        /// </summary>
        public double FrameHorizontal_RmsValue { get; set; }
        /// <summary>
        /// 构架横（通道7）
        /// </summary>
        public double FrameHorizontal_PeakIndex { get; set; }

        /// <summary>
        /// 车体垂（通道10）
        /// </summary>
        public double BodyVertical_MaxValueMile { get; set; }
        /// <summary>
        /// 车体垂（通道10）
        /// </summary>
        public double BodyVertical_RmsValue { get; set; }
        /// <summary>
        /// 车体垂（通道10）
        /// </summary>
        public double BodyVertical_PeakIndex { get; set; }

        /// <summary>
        /// 车体横（通道8）
        /// </summary>
        public double BodyHorizontal_MaxValueMile { get; set; }
        /// <summary>
        /// 车体横（通道8）
        /// </summary>
        public double BodyHorizontal_RmsValue { get; set; }
        /// <summary>
        /// 车体横（通道8）
        /// </summary>
        public double BodyHorizontal_PeakIndex { get; set; }


        /// <summary>
        /// 通道序号
        /// </summary>
        public int ChannelID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 各个通道的名称信息
    /// </summary>
    public enum ChannelEnum
    {
        /// <summary>
        /// 左轴垂（通道3）
        /// </summary>
        LeftAxisVertical = 3,

        /// <summary>
        /// 右轴垂（通道4）
        /// </summary>
        RightAxisVertical = 4,

        /// <summary>
        /// 左轴横（通道5）
        /// </summary>
        LeftAxisHorizontal = 5,

        /// <summary>
        /// 构架垂（通道6）
        /// </summary>
        FrameVertical = 6,

        /// <summary>
        /// 构架横（通道7）
        /// </summary>
        FrameHorizontal = 7,

        /// <summary>
        /// 车体垂（通道10）
        /// </summary>
        BodyVertical = 10,

        /// <summary>
        /// 车体横（通道8）
        /// </summary>
        BodyHorizontal = 8,
    }
}

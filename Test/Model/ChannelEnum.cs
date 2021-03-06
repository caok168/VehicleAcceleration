﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Model
{
    /// <summary>
    /// 各个通道的名称信息
    /// </summary>
    public enum ChannelEnum
    {
        /// <summary>
        /// 左轴垂
        /// </summary>
        LeftAxisVertical = 3,

        /// <summary>
        /// 右轴垂
        /// </summary>
        RightAxisVertical = 4,

        /// <summary>
        /// 左轴横
        /// </summary>
        LeftAxisHorizontal = 5,

        /// <summary>
        /// 构架垂
        /// </summary>
        FrameVertical = 6,

        /// <summary>
        /// 构架横
        /// </summary>
        FrameHorizontal = 7,

        /// <summary>
        /// 车体垂
        /// </summary>
        BodyVertical = 10,

        /// <summary>
        /// 车体横
        /// </summary>
        BodyHorizontal = 8,
    }
}

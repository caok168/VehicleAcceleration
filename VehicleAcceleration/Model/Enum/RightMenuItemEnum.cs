using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 右击菜单
    /// </summary>
    public enum RightMenuItemEnum
    {
        /// <summary>
        /// 轴箱左垂有效值
        /// </summary>
        LeftAxisVertical_RmsValue,

        /// <summary>
        /// 轴箱右垂有效值
        /// </summary>
        LeftAxisVertical_PeakIndex,

        /// <summary>
        /// 轴箱左横有效值
        /// </summary>
        RightAxisVertical_RmsValue,

        /// <summary>
        /// 轴箱左垂轨道冲击指数
        /// </summary>
        RightAxisVertical_PeakIndex,

        /// <summary>
        /// 轴箱右垂轨道冲击指数
        /// </summary>
        LeftAxisHorizontal_RmsValue,

        /// <summary>
        /// 轴箱左横轨道冲击指数
        /// </summary>
        LeftAxisHorizontal_PeakIndex,

        /// <summary>
        /// 构架垂向幅值
        /// </summary>
        FrameVertical_RmsValue,

        /// <summary>
        /// 构架横向幅值
        /// </summary>
        FrameHorizontal_RmsValue,

        /// <summary>
        /// 车体横向幅值
        /// </summary>
        BodyHorizontal_RmsValue,

        /// <summary>
        /// 车体垂向幅值
        /// </summary>
        BodyVertical_RmsValue
    }
}

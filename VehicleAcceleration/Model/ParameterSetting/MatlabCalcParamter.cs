using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 使用Matlab的方法需要调用的配置参数汇总类
    /// </summary>
    public class MatlabCalcParamter
    {

        public int CalculatePoints { get; set; }

        /// <summary>
        /// 采样频率（单位： HZ） 默认值：2000 【Matlab函数一、二中使用】
        /// </summary>
        public int SamplingFrequency { get; set; }

        /// <summary>
        /// 有效值窗长（单位： 个） 默认值：60 【Matlab函数一中使用】
        /// </summary>
        public int EffectiveValueLength { get; set; }

        /// <summary>
        /// 最大值统计窗长（单位：个/点） 200 【Matlab函数三中使用】
        /// </summary>
        public int MaxValueLength { get; set; }

        /// <summary>
        /// 抽样点数（单位：个） 默认值：6    【Matlab函数三中使用（重采样长度？？？）】
        /// </summary>
        public int SamplingPoints { get; set; }

        #region 轴箱所需参数

        /// <summary>
        /// 左轴垂上限频率
        /// </summary>
        public int LeftAxisVerticalUpper { get; set; }

        /// <summary>
        /// 右轴垂上限频率
        /// </summary>
        public int RightAxisVerticalUpper { get; set; }

        /// <summary>
        /// 左轴横上限频率
        /// </summary>
        public int LeftAxisHorizontalUpper { get; set; }

        /// <summary>
        /// 左轴垂有效值
        /// </summary>
        public double LeftAxisVerticalRms_mean { get; set; }

        /// <summary>
        /// 右轴垂有效值
        /// </summary>
        public double RightAxisVerticalRms_mean { get; set; }

        /// <summary>
        /// 左轴横有效值
        /// </summary>
        public double LeftAxisHorizontalRms_mean { get; set; }

        #endregion

        #region 构架、车体 通道所需参数

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

        /// <summary>
        /// 构架垂有效值
        /// </summary>
        public double FrameVerticalRms_mean { get; set; }

        /// <summary>
        /// 构架横有效值
        /// </summary>
        public double FrameHorizontalRms_mean { get; set; }

        /// <summary>
        /// 车体垂有效值
        /// </summary>
        public double BodyVerticalRms_mean { get; set; }

        /// <summary>
        /// 车体横有效值
        /// </summary>
        public double BodyHorizontalRms_mean { get; set; }

        #endregion

        #region  （cit原始数据）

        /// <summary>
        /// 左轴垂 （cit原始数据）
        /// </summary>
        public double[] LeftAxisVerticalData { get; set; }

        /// <summary>
        /// 右轴垂 （cit原始数据）
        /// </summary>
        public double[] RightAxisVerticalData { get; set; }

        /// <summary>
        /// 左轴横 （cit原始数据）
        /// </summary>
        public double[] LeftAxisHorizontalData { get; set; }

        /// <summary>
        /// 构架垂 （cit原始数据）
        /// </summary>
        public double[] FrameVerticalData { get; set; }

        /// <summary>
        /// 构架横 （cit原始数据）
        /// </summary>
        public double[] FrameHorizontalData { get; set; }

        /// <summary>
        /// 车体垂 （cit原始数据）
        /// </summary>
        public double[] BodyVerticalData { get; set; }

        /// <summary>
        /// 车体横 （cit原始数据）
        /// </summary>
        public double[] BodyHorizontalData { get; set; }

        /// <summary>
        /// 公里数据
        /// </summary>
        public double[] MilesData { get; set; }

        /// <summary>
        /// 速度数据
        /// </summary>
        public double[] SpeedData { get; set; }

        #endregion


        #region 台账信息

        /// <summary>
        /// 线路台账里程信息
        /// </summary>
        public double[] disp_line { get; set; }

        /// <summary>
        /// 线路台账类型
        /// </summary>
        public Int64[] type_line { get; set; }

        /// <summary>
        /// 偏差阀值
        /// </summary>
        public double[,] thresh_tii { get; set; }

        #endregion

    }
}

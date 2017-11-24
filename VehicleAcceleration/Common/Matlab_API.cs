using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using AccelerationOnLine;

namespace VehicleAcceleration.Common
{
    /// <summary>
    /// 调用Matlab函数API类
    /// </summary>
    public class Matlab_API
    {
        AccelerationOnLineClass mMatlabAcc = new AccelerationOnLineClass();

        /// <summary>
        /// 计算移动有效值（MATLAB函数一）
        /// </summary>
        /// <param name="Vacc_axlebox">double数组， cit原始通道数据</param>
        /// <param name="Fs">采样频率，2000：int类型，来自于配置参数</param>
        /// <param name="FilterFreq_H">带通滤波的上限频率，500 Hz: int类型，来自于配置参数</param>
        /// <param name="Len_win">计算移动有效值的窗长 60：int类型，来自于配置参数</param>
        /// <returns>移动有效值：double类型的数组</returns>
        public MWArray sub_calculate_moving_RMS_on_axlebox_acc(MWNumericArray Vacc_axlebox, int Fs, int FilterFreq_H, int Len_win)
        {
            return mMatlabAcc.sub_calculate_moving_RMS_on_axlebox_acc(Vacc_axlebox, Fs, FilterFreq_H, Len_win);
        }

        /// <summary>
        /// 对信号进行滤波（MATLAB函数二）
        /// </summary>
        /// <param name="Wx">原始信号： double数组，cit原始通道数据</param>
        /// <param name="t">时间或里程信号：double数组，cit中的里程数据（由km,m这两个通到计算）</param>
        /// <param name="Fs">采样频率：int类型，来自于配置参数</param>
        /// <param name="Freq_L">滤波下限频率：int类型，来自于配置参数</param>
        /// <param name="Freq_H">滤波上限频率：int类型，来自于配置参数</param>
        /// <returns>滤波后的信号：double类型数组</returns>
        public MWArray sub_filter_by_fft_and_ifft(MWNumericArray Wx, MWNumericArray t, int Fs, double Freq_L, double Freq_H)
        {
            return mMatlabAcc.sub_filter_by_fft_and_ifft(Wx, t, Fs, Freq_L, Freq_H);
        }

        /// <summary>
        /// 计算区段大值（MATLAB函数四）
        /// </summary>
        /// <param name="Wdisp">里程：double数组，来自于cit中的km, m通道</param>
        /// <param name="Wacc_0">有效值或幅值：函数1或者2的输出</param>
        /// <param name="Wvelo">速度：double数组，cit中的speed那个通道数据</param>
        /// <param name="Len_samp">重采样长度：int类型，从配置参数来</param>
        /// <returns>输出一个三个元素的数组，每个元素又是一个数组，如下：
        ///wdisp_merge  重采样后里程：double数组
        ///wvelo_merge  重采样后速度：double数组
        ///wstd_merge   重采样后有效值或幅值：double数组</returns>
        public MWArray sub_resampling_acceleration_criteria(MWNumericArray Wdisp, MWArray Wacc_0, MWNumericArray Wvelo, int Len_samp)
        {
            return mMatlabAcc.sub_resampling_acceleration_criteria(Wdisp, Wacc_0, Wvelo, Len_samp);
        }

        /// <summary>
        /// 计算区段大值（MATLAB函数三）
        /// </summary>
        /// <param name="Wdisp">里程：函数4的返回值</param>
        /// <param name="Wstd_0">有效值或幅值：函数4的返回值</param>
        /// <param name="wvelo">速度：函数4的返回值</param>
        /// <param name="len_merge">区段长度：int类型，最大值统计窗长</param>
        /// <param name="rms_mean">有效值平均值: double类型，每个通道有自己的数字，从access中来。作为测试，可以先选择成1.0到20.0之间的一个浮点数。</param>
        /// <returns>
        /// 因为返回的是数组的数组，下面的写法：ww_seg_maximum(:,1) 表示这是输出的数组的第一个元素（当然这个元素还是个数组）。
        /// ww_seg_maximum(:,1)平均速度：每个通道的输出都一样的：double数组
        /// ww_seg_maximum(:,2)开始里程：每个通道的输出都一样的：double数组
        /// ww_seg_maximum(:,3)最大值发生的里程：double数组
        /// ww_seg_maximum(:,4)有效值（前3个通道）或幅值（后4个通道）：double数组
        /// </returns>
        public MWArray sub_calculate_segment_maximum_value(MWArray Wdisp, MWArray Wstd_0, MWArray wvelo, int len_merge, double rms_mean)
        {
            return mMatlabAcc.sub_calculate_segment_maximum_value(Wdisp, Wstd_0, wvelo, len_merge, rms_mean);
        }

        /// <summary>
        /// 计算偏差（MATLAB函数五）
        /// </summary>
        /// <param name="Wdisp">里程：来自于函数4</param>
        /// <param name="wstd_0">有效值：来自于函数4</param>
        /// <param name="wvelo">速度：来自于函数4</param>
        /// <param name="disp_line">线路台账里程信息：double数组，里面是里程，来自台帐</param>
        /// <param name="type_line">线路台账类型：int数组，来自台帐，与上面的数据搭配</param>
        /// <param name="rms_mean">有效值平均值：根据：车+速度等级+通道+线路 查出一个double值</param>
        /// <param name="thresh_tii">
        /// 偏差阈值： 2x3的double数组
        /// thresh_tii（1，1：3） 非道岔区的1，2，3级偏差阈值
        /// thresh_tii（2，1：3） 道岔区的1，2，3级偏差阈值
        /// </param>
        /// <returns> Wdev  偏差信息，输出是个数组的数组，double类型，如下：
        /// wdev(:,1): 里程
        /// wdev(:,2): 有效值
        /// wdev(:,3): 轨道冲击指数
        /// wdev(:,4): 速度
        /// wdev(:,5): 偏差等级：根据返回值，对应到A,B,C
        /// wdev(:,6): 偏差长度
        /// wdev(:,7): 偏差处线路类型: 根据返回值，对应到直线，曲线，道岔
        /// </returns>
        public MWArray sub_calculate_deviation_from_axle_box_acceleration(MWArray Wdisp, MWArray wstd_0, MWArray wvelo, MWArray disp_line, MWArray type_line, double rms_mean, MWArray thresh_tii)
        {
            return mMatlabAcc.sub_calculate_deviation_from_axle_box_acceleration(Wdisp, wstd_0, wvelo, disp_line, type_line, rms_mean, thresh_tii);
        }
    }
}

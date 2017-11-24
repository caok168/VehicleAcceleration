using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Model;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using VehicleAcceleration.Common;
using System.IO;
using CitFileProcess;

namespace VehicleAcceleration.Classes
{
    public partial class MatlabCalcParamterDAL
    {
        public static void MatlabCalculate(MatlabCalcParamter matlabParamter, string dataDbPath)
        {
            waveDal = new WaveDataResultDAL(dataDbPath);
            overValueDal = new OverValueDataResultDAL(dataDbPath);

            double[] citDataA = matlabParamter.LeftAxisVerticalData;
            double[] citDataB = matlabParamter.RightAxisVerticalData;
            double[] citDataC = matlabParamter.LeftAxisHorizontalData;
            double[] citDataD = matlabParamter.FrameVerticalData;
            double[] citDataE = matlabParamter.FrameHorizontalData;
            double[] citDataF = matlabParamter.BodyHorizontalData;
            double[] citDataG = matlabParamter.BodyVerticalData;

            //公里
            double[] mile = matlabParamter.MilesData;
            //速度
            double[] speed = matlabParamter.SpeedData;

            MWNumericArray mwCitDataA = new MWNumericArray(citDataA);
            MWNumericArray mwCitDataB = new MWNumericArray(citDataB);
            MWNumericArray mwCitDataC = new MWNumericArray(citDataC);
            MWNumericArray mwCitDataD = new MWNumericArray(citDataD);
            MWNumericArray mwCitDataE = new MWNumericArray(citDataE);
            MWNumericArray mwCitDataF = new MWNumericArray(citDataF);
            MWNumericArray mwCitDataG = new MWNumericArray(citDataG);

            MWNumericArray mMile = new MWNumericArray(mile);
            MWNumericArray mSpeed = new MWNumericArray(speed);

            #region 调用函数一、函数二

            //调用MATLAB函数一（计算移动有效值）
            MWArray result_A = matlabApi.sub_calculate_moving_RMS_on_axlebox_acc(mwCitDataA, matlabParamter.SamplingFrequency, matlabParamter.LeftAxisVerticalUpper, matlabParamter.EffectiveValueLength);
            MWArray result_B = matlabApi.sub_calculate_moving_RMS_on_axlebox_acc(mwCitDataB, matlabParamter.SamplingFrequency, matlabParamter.RightAxisVerticalUpper, matlabParamter.EffectiveValueLength);
            MWArray result_C = matlabApi.sub_calculate_moving_RMS_on_axlebox_acc(mwCitDataC, matlabParamter.SamplingFrequency, matlabParamter.LeftAxisHorizontalUpper, matlabParamter.EffectiveValueLength);
            //调用MATLAB函数二（对信号进行滤波）
            MWArray result_D = matlabApi.sub_filter_by_fft_and_ifft(mwCitDataD, mMile, matlabParamter.SamplingFrequency, matlabParamter.FrameVerticalLower, matlabParamter.FrameVerticalUpper);
            MWArray result_E = matlabApi.sub_filter_by_fft_and_ifft(mwCitDataE, mMile, matlabParamter.SamplingFrequency, matlabParamter.FrameHorizontalLower, matlabParamter.FrameHorizontalUpper);
            MWArray result_F = matlabApi.sub_filter_by_fft_and_ifft(mwCitDataF, mMile, matlabParamter.SamplingFrequency, matlabParamter.BodyHorizontalLower, matlabParamter.BodyHorizontalUpper);
            MWArray result_G = matlabApi.sub_filter_by_fft_and_ifft(mwCitDataG, mMile, matlabParamter.SamplingFrequency, matlabParamter.BodyVerticalLower, matlabParamter.BodyVerticalUpper);

            #endregion

            #region 调用Matlab函数四

            #region 调用函数四

            //调用MATLAB函数四（计算区段大值）
            MWArray result_maxValue_A = matlabApi.sub_resampling_acceleration_criteria(mMile, result_A, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_B = matlabApi.sub_resampling_acceleration_criteria(mMile, result_B, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_C = matlabApi.sub_resampling_acceleration_criteria(mMile, result_C, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_D = matlabApi.sub_resampling_acceleration_criteria(mMile, result_D, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_E = matlabApi.sub_resampling_acceleration_criteria(mMile, result_E, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_F = matlabApi.sub_resampling_acceleration_criteria(mMile, result_F, mSpeed, matlabParamter.SamplingPoints);
            MWArray result_maxValue_G = matlabApi.sub_resampling_acceleration_criteria(mMile, result_G, mSpeed, matlabParamter.SamplingPoints);

            #endregion

            #region 处理函数四结果

            int length = 0;

            Array array_maxValue_A = result_maxValue_A.ToArray();
            Array array_maxValue_B = result_maxValue_B.ToArray();
            Array array_maxValue_C = result_maxValue_C.ToArray();
            Array array_maxValue_D = result_maxValue_D.ToArray();
            Array array_maxValue_E = result_maxValue_E.ToArray();
            Array array_maxValue_F = result_maxValue_F.ToArray();
            Array array_maxValue_G = result_maxValue_G.ToArray();

            length = array_maxValue_A.Length / 3;
            double[] dmile = new double[length];
            double[] dvalue_A = new double[length];
            double[] dspeed = new double[length];

            double[] dvalue_B = new double[length];
            double[] dvalue_C = new double[length];
            double[] dvalue_D = new double[length];
            double[] dvalue_E = new double[length];
            double[] dvalue_F = new double[length];
            double[] dvalue_G = new double[length];

            double[,] dArray_maxValue_A = (double[,])array_maxValue_A;
            double[,] dArray_maxValue_B = (double[,])array_maxValue_B;
            double[,] dArray_maxValue_C = (double[,])array_maxValue_C;
            double[,] dArray_maxValue_D = (double[,])array_maxValue_D;
            double[,] dArray_maxValue_E = (double[,])array_maxValue_E;
            double[,] dArray_maxValue_F = (double[,])array_maxValue_F;
            double[,] dArray_maxValue_G = (double[,])array_maxValue_G;

            for (int i = 0; i < length; i++)
            {
                dmile[i] = dArray_maxValue_A[i, 0];
                dspeed[i] = dArray_maxValue_A[i, 2];

                dvalue_A[i] = dArray_maxValue_A[i, 1];

                dvalue_B[i] = dArray_maxValue_B[i, 1];
                dvalue_C[i] = dArray_maxValue_C[i, 1];
                dvalue_D[i] = dArray_maxValue_D[i, 1];
                dvalue_E[i] = dArray_maxValue_E[i, 1];
                dvalue_F[i] = dArray_maxValue_F[i, 1];
                dvalue_G[i] = dArray_maxValue_G[i, 1];
            }


            //NOPIHelper nopi = new NOPIHelper();
            //string excelpath=@"H:\a1.xls";
            //nopi.CreateExcelForData(dmile, "第一个参数", excelpath, "里程");

            //excelpath = @"H:\a2.xls";
            //nopi.CreateExcelForData(dvalue_C, "第二个参数", excelpath, "值");

            //excelpath = @"H:\a3.xls";
            //nopi.CreateExcelForData(dspeed, "第三个参数", excelpath, "速度");

            MWNumericArray mwa_mile = new MWNumericArray(dmile);
            MWNumericArray mwa_speed = new MWNumericArray(dspeed);
            MWNumericArray mwa_value_A = new MWNumericArray(dvalue_A);
            MWNumericArray mwa_value_B = new MWNumericArray(dvalue_B);
            MWNumericArray mwa_value_C = new MWNumericArray(dvalue_C);
            MWNumericArray mwa_value_D = new MWNumericArray(dvalue_D);
            MWNumericArray mwa_value_E = new MWNumericArray(dvalue_E);
            MWNumericArray mwa_value_F = new MWNumericArray(dvalue_F);
            MWNumericArray mwa_value_G = new MWNumericArray(dvalue_G);

            #endregion

            #endregion

            #region 调用Matlab函数三

            #region 调用函数三

            //调用MATLAB函数三（计算区段大值）
            MWArray maxValue_A = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_A, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.LeftAxisVerticalRms_mean);
            MWArray maxValue_B = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_B, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.RightAxisVerticalRms_mean);
            MWArray maxValue_C = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_C, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.LeftAxisHorizontalRms_mean);
            MWArray maxValue_D = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_D, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.FrameVerticalRms_mean);
            MWArray maxValue_E = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_E, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.FrameHorizontalRms_mean);
            MWArray maxValue_F = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_F, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.BodyHorizontalRms_mean);
            MWArray maxValue_G = matlabApi.sub_calculate_segment_maximum_value(mwa_mile, mwa_value_G, mwa_speed, matlabParamter.MaxValueLength, matlabParamter.BodyVerticalRms_mean);

            Array maxValueArray_A = maxValue_A.ToArray();
            Array maxValueArray_B = maxValue_B.ToArray();
            Array maxValueArray_C = maxValue_C.ToArray();
            Array maxValueArray_D = maxValue_D.ToArray();
            Array maxValueArray_E = maxValue_E.ToArray();
            Array maxValueArray_F = maxValue_F.ToArray();
            Array maxValueArray_G = maxValue_G.ToArray();

            #endregion

            #region 处理函数三结果

            int count = maxValueArray_A.Length / 5;
            double[] dAvgSpeed = new double[count];   //平均速度
            double[] dStartMile = new double[count];   //开始里程

            double[] dMaxValueMile_A = new double[count];//最大值发生的里程
            double[] dRmsValue_A = new double[count];       //有效值/幅值
            double[] dPeakIndex_A = new double[count];   //轨道冲击指数(前三个通道)
            double[] dMaxValueMile_B = new double[count];
            double[] dRmsValue_B = new double[count];
            double[] dPeakIndex_B = new double[count];
            double[] dMaxValueMile_C = new double[count];
            double[] dRmsValue_C = new double[count];
            double[] dPeakIndex_C = new double[count];
            double[] dMaxValueMile_D = new double[count];
            double[] dRmsValue_D = new double[count];
            double[] dPeakIndex_D = new double[count];
            double[] dMaxValueMile_E = new double[count];
            double[] dRmsValue_E = new double[count];
            double[] dPeakIndex_E = new double[count];
            double[] dMaxValueMile_F = new double[count];
            double[] dRmsValue_F = new double[count];
            double[] dPeakIndex_F = new double[count];
            double[] dMaxValueMile_G = new double[count];
            double[] dRmsValue_G = new double[count];
            double[] dPeakIndex_G = new double[count];

            double[,] resultArray_A = (double[,])maxValueArray_A;
            double[,] resultArray_B = (double[,])maxValueArray_B;
            double[,] resultArray_C = (double[,])maxValueArray_C;
            double[,] resultArray_D = (double[,])maxValueArray_D;
            double[,] resultArray_E = (double[,])maxValueArray_E;
            double[,] resultArray_F = (double[,])maxValueArray_F;
            double[,] resultArray_G = (double[,])maxValueArray_G;
            for (int i = 0; i < count; i++)
            {
                dAvgSpeed[i] = resultArray_A[i, 0];
                dStartMile[i] = resultArray_A[i, 1];

                dMaxValueMile_A[i] = resultArray_A[i, 2];
                dRmsValue_A[i] = resultArray_A[i, 3];
                dPeakIndex_A[i] = resultArray_A[i, 4];

                dMaxValueMile_B[i] = resultArray_B[i, 2];
                dRmsValue_B[i] = resultArray_B[i, 3];
                dPeakIndex_B[i] = resultArray_B[i, 4];

                dMaxValueMile_C[i] = resultArray_C[i, 2];
                dRmsValue_C[i] = resultArray_C[i, 3];
                dPeakIndex_C[i] = resultArray_C[i, 4];

                dMaxValueMile_D[i] = resultArray_D[i, 2];
                dRmsValue_D[i] = resultArray_D[i, 3];
                dPeakIndex_D[i] = resultArray_D[i, 4];

                dMaxValueMile_E[i] = resultArray_E[i, 2];
                dRmsValue_E[i] = resultArray_E[i, 3];
                dPeakIndex_E[i] = resultArray_E[i, 4];

                dMaxValueMile_F[i] = resultArray_F[i, 2];
                dRmsValue_F[i] = resultArray_F[i, 3];
                dPeakIndex_F[i] = resultArray_F[i, 4];

                dMaxValueMile_G[i] = resultArray_G[i, 2];
                dRmsValue_G[i] = resultArray_G[i, 3];
                dPeakIndex_G[i] = resultArray_G[i, 4];
            }

            #endregion

            #region 保存到数据库

            List<WaveDataResult> listResult = new List<WaveDataResult>();
            for (int i = 0; i < count; i++)
            {
                WaveDataResult data = new WaveDataResult();
                data.AvgSpeed = dAvgSpeed[i];
                data.StartMile = dStartMile[i];
                data.LeftAxisVertical_MaxValueMile = dMaxValueMile_A[i];
                data.LeftAxisVertical_RmsValue = dRmsValue_A[i];
                data.LeftAxisVertical_PeakIndex = dPeakIndex_A[i];

                data.RightAxisVertical_MaxValueMile = dMaxValueMile_B[i];
                data.RightAxisVertical_RmsValue = dRmsValue_B[i];
                data.RightAxisVertical_PeakIndex = dPeakIndex_B[i];

                data.LeftAxisHorizontal_MaxValueMile = dMaxValueMile_C[i];
                data.LeftAxisHorizontal_RmsValue = dRmsValue_C[i];
                data.LeftAxisHorizontal_PeakIndex = dPeakIndex_C[i];

                data.FrameVertical_MaxValueMile = dMaxValueMile_D[i];
                data.FrameVertical_RmsValue = dRmsValue_D[i];
                data.FrameVertical_PeakIndex = dPeakIndex_D[i];

                data.FrameHorizontal_MaxValueMile = dMaxValueMile_E[i];
                data.FrameHorizontal_RmsValue = dRmsValue_E[i];
                data.FrameHorizontal_PeakIndex = dPeakIndex_E[i];

                data.BodyHorizontal_MaxValueMile = dMaxValueMile_F[i];
                data.BodyHorizontal_RmsValue = dRmsValue_F[i];
                data.BodyHorizontal_PeakIndex = dPeakIndex_F[i];

                data.BodyVertical_MaxValueMile = dMaxValueMile_G[i];
                data.BodyVertical_RmsValue = dRmsValue_G[i];
                data.BodyVertical_PeakIndex = dPeakIndex_G[i];

                listResult.Add(data);
            }

            waveDal.Add(listResult);

            #endregion

            #endregion

            #region 调用Matlab函数五

            #region 获取disp_line[] double数组 参数

            //double[] disp_line = new double[3];
            //disp_line[0] = dmile[0];
            //disp_line[1] = 12.7;//dmileA[length / 2];
            //disp_line[2] = dmile[length - 1];

            double[] disp_line = matlabParamter.disp_line;

            #endregion

            #region 获取type_line[] double数组 参数

            //Int64[] type_line = new Int64[2];
            //type_line[0] = 1;
            //type_line[1] = 2;

            Int64[] type_line = matlabParamter.type_line;

            #endregion

            #region 2*3的double数组

            double[,] thresh_tii = new double[2, 3];
            //thresh_tii[0, 0] = 4.0;
            //thresh_tii[0, 1] = 6;
            //thresh_tii[0, 2] = 8;
            //thresh_tii[1, 0] = 6;
            //thresh_tii[1, 1] = 8;
            //thresh_tii[1, 2] = 10;

            thresh_tii = matlabParamter.thresh_tii;

            //double[] thresh_tii = new double[6];
            //thresh_tii[0] = 4;
            //thresh_tii[1] = 6;
            //thresh_tii[2] = 8;
            //thresh_tii[3] = 6;
            //thresh_tii[4] = 8;
            //thresh_tii[5] = 10;

            #endregion

            //excelpath = @"H:\a4.xls";
            //nopi.CreateExcelForData(disp_line, "第四个参数", excelpath, "disp_line");

            //excelpath = @"H:\a5.xls";
            //nopi.CreateExcelForData(type_line, "第五个参数", excelpath, "type_line");

            MWNumericArray mwa_disp_line = new MWNumericArray(disp_line);
            MWNumericArray mwa_type_line = new MWNumericArray(type_line);
            MWNumericArray mwa_thresh_tii = new MWNumericArray(thresh_tii);


            MWArray devValue_A = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_A, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.LeftAxisVerticalRms_mean, mwa_thresh_tii);
            MWArray devValue_B = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_B, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.RightAxisVerticalRms_mean, mwa_thresh_tii);
            MWArray devValue_C = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_C, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.LeftAxisHorizontalRms_mean, mwa_thresh_tii);
            MWArray devValue_D = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_D, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.FrameVerticalRms_mean, mwa_thresh_tii);
            MWArray devValue_E = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_E, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.FrameHorizontalRms_mean, mwa_thresh_tii);
            MWArray devValue_F = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_F, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.BodyHorizontalRms_mean, mwa_thresh_tii);
            MWArray devValue_G = matlabApi.sub_calculate_deviation_from_axle_box_acceleration(mwa_mile, mwa_value_G, mwa_speed, mwa_disp_line, mwa_type_line, matlabParamter.BodyVerticalRms_mean, mwa_thresh_tii);


            Array devValueArray_A = devValue_A.ToArray();
            Array devValueArray_B = devValue_B.ToArray();
            Array devValueArray_C = devValue_C.ToArray();

            #region 函数五处理结果

            string channelName = "";
            List<OverValueDataResult> listOverValues = new List<OverValueDataResult>();
            if (devValueArray_A.Length > 0)
            {
                channelName = "左轴垂";
                List<OverValueDataResult> list = SetOverValue(devValueArray_A, channelName);
                listOverValues.AddRange(list);
            }
            if (devValueArray_B.Length > 0)
            {
                channelName = "右轴垂";
                List<OverValueDataResult> list = SetOverValue(devValueArray_B, channelName);
                listOverValues.AddRange(list);
            }
            if (devValueArray_C.Length > 0)
            {
                channelName = "左轴横";
                List<OverValueDataResult> list = SetOverValue(devValueArray_C, channelName);
                listOverValues.AddRange(list);
            }

            SaveToAccessDb(listOverValues);

            #endregion


            #endregion
        }

        /// <summary>
        /// 获取结果组织城List集合
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static List<OverValueDataResult> SetOverValue(Array array, string channelName)
        {
            int arrayLength = array.Length / 7;
            List<OverValueDataResult> list = new List<OverValueDataResult>();
            double[,] resultArray = (double[,])array;
            for (int i = 0; i < arrayLength; i++)
            {
                OverValueDataResult overValue = new OverValueDataResult();
                //里程
                overValue.Mile = resultArray[i, 0];
                //有效值
                overValue.OverValueRms = resultArray[i, 1];

                //轨道冲击指数
                overValue.OverValuePeak = resultArray[i, 2];

                //速度
                overValue.Speed = resultArray[i, 3];

                //偏差等级（A、B、C）
                double overLevelValue = resultArray[i, 4];
                if (overLevelValue == 1)
                {
                    overValue.OverLevel = "A";
                }
                if (overLevelValue == 2)
                {
                    overValue.OverLevel = "B";
                }
                if (overLevelValue == 3)
                {
                    overValue.OverLevel = "C";
                }

                //偏差长度
                overValue.OverLength = resultArray[i, 5];

                //偏差线路类型
                overValue.OverType = "";
                double overTypeValue = resultArray[i, 6];
                if (overTypeValue == 1)
                {
                    overValue.OverType = "直线";
                }
                if (overTypeValue == 2)
                {
                    overValue.OverType = "曲线";
                }
                if (overTypeValue == 3)
                {
                    overValue.OverType = "道岔";
                }

                overValue.IsValid = 1;
                overValue.ChannelName = channelName;

                list.Add(overValue);
            }
            return list;
        }

        /// <summary>
        /// 保存到数据库中
        /// </summary>
        /// <param name="list"></param>
        private static void SaveToAccessDb(List<OverValueDataResult> list)
        {
            overValueDal.Add(list);
        }
    }
}

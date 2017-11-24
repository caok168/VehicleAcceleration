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
using VehicleAcceleration.Classes.ChannelRmsMean;
using VehicleAcceleration.Classes.LineStandingBook;
using System.Windows.Forms;

namespace VehicleAcceleration.Classes
{
    /// <summary>
    /// 获取配置信息操作类
    /// </summary>
    public partial class MatlabCalcParamterDAL
    {
        private static CalculaterParamterDAL calcDal = new CalculaterParamterDAL();
        private static ChannelFreqParamterDAL channelDal = new ChannelFreqParamterDAL();
        private static Matlab_API matlabApi = new Matlab_API();

        private static WaveDataResultDAL waveDal = null;
        private static OverValueDataResultDAL overValueDal = null;

        private static RmsMeanDAL rmsMealDal = new RmsMeanDAL();

        private static StandingBookDAL standingDal = new StandingBookDAL();

        private static DeviationParameterDAL deviationDal = new DeviationParameterDAL();

        #region 获取Matlab计算需要的参数以及原始数据

        /// <summary>
        /// 加载实时计算配置的信息
        /// </summary>
        /// <returns></returns>
        public static MatlabCalcParamter LoadParameter()
        {
            try
            {
                MatlabCalcParamter matlabParamter = new MatlabCalcParamter();
                //matlabParamter.CalculatePoints = CommonClass.CalculatePoints;


                var calcParamter = calcDal.GetList().FirstOrDefault();
                if (calcParamter != null)
                {
                    matlabParamter.CalculatePoints = calcParamter.SamplingFrequency * calcParamter.ComputingTime;
                    matlabParamter.SamplingFrequency = calcParamter.SamplingFrequency;
                    matlabParamter.EffectiveValueLength = calcParamter.EffectiveValueLength;
                    matlabParamter.MaxValueLength = calcParamter.MaxValueLength;
                    matlabParamter.SamplingPoints = calcParamter.SamplingPoints;
                }
                else
                {
                    matlabParamter.CalculatePoints = 2000 * 300;
                    matlabParamter.SamplingFrequency = 2000;
                    matlabParamter.EffectiveValueLength = 60;
                    matlabParamter.MaxValueLength = 200;
                    matlabParamter.SamplingPoints = 6;
                }

                var channelParamter = channelDal.GetList().FirstOrDefault();
                if (channelParamter != null)
                {
                    matlabParamter.LeftAxisVerticalUpper = Convert.ToInt32(channelParamter.LeftAxisVerticalUpper);
                    matlabParamter.LeftAxisHorizontalUpper = Convert.ToInt32(channelParamter.LeftAxisHorizontalUpper);
                    matlabParamter.RightAxisVerticalUpper = Convert.ToInt32(channelParamter.RightAxisVerticalUpper);

                    matlabParamter.FrameVerticalLower = channelParamter.FrameVerticalLower;
                    matlabParamter.FrameVerticalUpper = channelParamter.FrameVerticalUpper;
                    matlabParamter.FrameHorizontalLower = channelParamter.FrameHorizontalLower;
                    matlabParamter.FrameHorizontalUpper = channelParamter.FrameHorizontalUpper;
                    matlabParamter.BodyVerticalLower = channelParamter.BodyVerticalLower;
                    matlabParamter.BodyVerticalUpper = channelParamter.BodyVerticalUpper;
                    matlabParamter.BodyHorizontalLower = channelParamter.BodyHorizontalLower;
                    matlabParamter.BodyHorizontalUpper = channelParamter.BodyHorizontalUpper;
                }
                else
                {
                    matlabParamter.LeftAxisVerticalUpper = 500;
                    matlabParamter.LeftAxisHorizontalUpper = 500;
                    matlabParamter.RightAxisVerticalUpper = 500;

                    matlabParamter.FrameVerticalLower = 0.1;
                    matlabParamter.FrameVerticalUpper = 20;
                    matlabParamter.FrameHorizontalLower = 0.1;
                    matlabParamter.FrameHorizontalUpper = 10;
                    matlabParamter.BodyVerticalLower = 0.1;
                    matlabParamter.BodyVerticalUpper = 20;
                    matlabParamter.BodyHorizontalLower = 0.1;
                    matlabParamter.BodyHorizontalUpper = 10;
                }

                return matlabParamter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载实时计算配置的信息出错" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 获取实时计算需要的原始数据
        /// </summary>
        /// <param name="mbr"></param>
        /// <param name="startpos"></param>
        /// <param name="endpos"></param>
        /// <param name="matlabParamter"></param>
        /// <returns></returns>
        public static MatlabCalcParamter LoadDataForMatlab(BinaryReader mbr, long startpos, long endpos, MatlabCalcParamter matlabParamter, CitFileHelper citHelper, BasicInfo basic)
        {
            matlabParamter.LeftAxisVerticalData = citHelper.GetSingleChannelData(mbr, 3, startpos, endpos);
            matlabParamter.RightAxisVerticalData = citHelper.GetSingleChannelData(mbr, 4, startpos, endpos);
            matlabParamter.LeftAxisHorizontalData = citHelper.GetSingleChannelData(mbr, 5, startpos, endpos);

            matlabParamter.FrameVerticalData = citHelper.GetSingleChannelData(mbr, 6, startpos, endpos);
            matlabParamter.FrameHorizontalData = citHelper.GetSingleChannelData(mbr, 7, startpos, endpos);
            matlabParamter.BodyHorizontalData = citHelper.GetSingleChannelData(mbr, 8, startpos, endpos);
            matlabParamter.BodyVerticalData = citHelper.GetSingleChannelData(mbr, 10, startpos, endpos);

            matlabParamter.MilesData = citHelper.GetMilesData(mbr, startpos, endpos);
            //速度需要查看
            matlabParamter.SpeedData = citHelper.GetSingleChannelData(mbr, 15, startpos, endpos);

            RmsMeanInfo rmsMean = rmsMealDal.GetRmsMeanInfo(basic.SurveyVehicleVersion, basic.LineName, matlabParamter.MilesData[matlabParamter.MilesData.Length - 1]);

            matlabParamter.LeftAxisVerticalRms_mean = rmsMean.Rms_mean_LeftAxisVertical;
            matlabParamter.RightAxisVerticalRms_mean = rmsMean.Rms_mean_RightAxisVertical;
            matlabParamter.LeftAxisHorizontalRms_mean = rmsMean.Rms_mean_LeftAxisHorizontal;

            matlabParamter.FrameVerticalRms_mean = 1;
            matlabParamter.FrameHorizontalRms_mean = 1;
            matlabParamter.BodyHorizontalRms_mean = 1;
            matlabParamter.BodyVerticalRms_mean = 1;

            StandingBook standingbook = standingDal.GetStandingBook().Where(s => s.LineName == basic.LineName).FirstOrDefault();
            if (standingbook != null)
            {
                List<StandingBookDetail> listDetail = standingDal.GetStandingBookDetail(standingbook.StandingBookName);
                List<double> listValues = new List<double>();
                List<Int64> listTypes = new List<Int64>();
                for (int i = 0; i < listDetail.Count; i++)
                {
                    if (!listValues.Contains(listDetail[i].StartMile))
                    {
                        listValues.Add(listDetail[i].StartMile);
                    }
                    if (!listValues.Contains(listDetail[i].EndMile))
                    {
                        listValues.Contains(listDetail[i].EndMile);
                    }

                    switch (listDetail[i].Type)
                    {
                        case "直线":
                            listTypes.Add((Int64)StandingBookEnum.直线);
                            break;
                        case "曲线":
                            listTypes.Add((Int64)StandingBookEnum.曲线);
                            break;
                        case "道岔":
                            listTypes.Add((Int64)StandingBookEnum.道岔);
                            break;
                        default:
                            break;
                    }
                }
                matlabParamter.disp_line = listValues.OrderBy(s => s).ToArray();
                matlabParamter.type_line = listTypes.ToArray();

                matlabParamter.thresh_tii = deviationDal.GetDeviationParameter();

            }

            return matlabParamter;
        }

        #endregion

        

        

    }
}

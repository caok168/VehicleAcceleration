using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;
using System.Data;

namespace VehicleAcceleration.Classes.ChannelRmsMean
{
    /// <summary>
    /// 用于获取各个通道的有效值操作类
    /// </summary>
    public class RmsMeanDAL
    {

        //记录日志
        NLog.Logger logger = NLog.LogManager.GetLogger("");

        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        #region 线路操作

        /// <summary>
        /// 查询所有线路信息
        /// </summary>
        /// <returns></returns>
        public List<LineInfo> GetLineInfo()
        {
            List<LineInfo> list = new List<LineInfo>();
            string sql = "select * from LineInfo ";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "LineInfo");
            list = DataTableToList_LineInfo(dt);

            return list;
        }

        /// <summary>
        /// 根据线路名查询线路信息
        /// </summary>
        /// <param name="lineName">线路名称</param>
        /// <returns></returns>
        public List<LineInfo> GetLineInfo(string lineName)
        {
            List<LineInfo> list = new List<LineInfo>();
            string sql = "select * from LineInfo where LineName=" + lineName;

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "LineInfo");
            list = DataTableToList_LineInfo(dt);

            return list;
        }

        /// <summary>
        /// 根据线路名和里程标确定一条线路信息
        /// </summary>
        /// <param name="lineName"></param>
        /// <param name="mile"></param>
        /// <returns></returns>
        public LineInfo GetLineInfo(string lineName, double mile)
        {
            List<LineInfo> list = new List<LineInfo>();
            string sql = "select * from LineInfo where LineName='" + lineName + "' and (StartMile<=" + mile + " and EndMile>=" + mile + " and EndMile>StartMile) or (EndMile<=" + mile + " and StartMile>=" + mile + " and StartMile>EndMile)";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "LineInfo");
            list = DataTableToList_LineInfo(dt);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 检测车有效值 操作

        /// <summary>
        /// 查询所有检测车信息
        /// </summary>
        /// <returns></returns>
        public List<RmsMeanInfo> GetRmsMeanInfo()
        {
            List<RmsMeanInfo> list = new List<RmsMeanInfo>();

            string sql = "select * from RmsMeanInfo ";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "RmsMeanInfo");
            list = DataTableToList_RmsMeanInfo(dt);

            return list;
        }

        /// <summary>
        /// 根据检测车号来查询检测车有效值信息
        /// </summary>
        /// <param name="SurveyVehicle">检测车</param>
        /// <returns></returns>
        public List<RmsMeanInfo> GetRmsMeanInfo(string surveyVehicle)
        {
            List<RmsMeanInfo> list = new List<RmsMeanInfo>();

            string sql = "select * from RmsMeanInfo where SurveyVehicle='" + surveyVehicle + "'";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "RmsMeanInfo");
            list = DataTableToList_RmsMeanInfo(dt);

            return list;
        }

        /// <summary>
        /// 根据 检测车、线路类型、速度等级 查询一个通道的有效值
        /// </summary>
        /// <param name="surveyVehicle">检测车</param>
        /// <param name="lineType">线路类型</param>
        /// <param name="speedLevel">速度等级</param>
        /// <returns></returns>
        public RmsMeanInfo GetRmsMeanInfoModel(string surveyVehicle, string lineType, double speedLevel)
        {
            List<RmsMeanInfo> list = new List<RmsMeanInfo>();

            string sql = "select * from RmsMeanInfo where SurveyVehicle='" + surveyVehicle + "' and LineType='" + lineType + "' and SpeedLevel=" + speedLevel;

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "RmsMeanInfo");
            list = DataTableToList_RmsMeanInfo(dt);

            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据 检测车、线路名、公里标查询有效值
        /// </summary>
        /// <param name="surveyVehicle">检测车</param>
        /// <param name="lineName">线路名</param>
        /// <param name="mile">公里标</param>
        /// <returns></returns>
        public RmsMeanInfo GetRmsMeanInfo(string surveyVehicle, string lineName, double mile)
        {
            logger.Debug(String.Format("方法：GetRmsMeanInfo，参数surveyVehicle【{0}】,lineName【{1}】,mile【{2}】", surveyVehicle, lineName, mile));

            try
            {
                LineInfo lineInfo = GetLineInfo(lineName, mile);

                if (lineInfo == null)
                {
                    logger.Debug(String.Format("lineInfo 为 null=====方法：GetRmsMeanInfo，参数surveyVehicle【{0}】,lineName【{1}】,mile【{2}】", surveyVehicle, lineName, mile));
                }

                return GetRmsMeanInfoModel(surveyVehicle, lineInfo.LineType, lineInfo.SpeedLevel);
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                return null;
            }
            
        }

        #endregion

        #region 私有方法

        private List<LineInfo> DataTableToList_LineInfo(DataTable dt)
        {
            List<LineInfo> list = new List<LineInfo>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LineInfo lineinfo = new LineInfo();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        lineinfo.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["LineName"] != null)
                    {
                        lineinfo.LineName = dt.Rows[i]["LineName"].ToString();
                    }
                    if (dt.Rows[i]["LineType"] != null)
                    {
                        lineinfo.LineType = dt.Rows[i]["LineType"].ToString();
                    }
                    if (dt.Rows[i]["SpeedLevel"] != null)
                    {
                        lineinfo.SpeedLevel = Convert.ToDouble(dt.Rows[i]["SpeedLevel"]);
                    }

                    if (dt.Rows[i]["StartMile"] != null)
                    {
                        lineinfo.StartMile = Convert.ToDouble(dt.Rows[i]["StartMile"]);
                    }

                    if (dt.Rows[i]["EndMile"] != null)
                    {
                        lineinfo.EndMile = Convert.ToDouble(dt.Rows[i]["EndMile"]);
                    }

                    list.Add(lineinfo);
                }
            }

            return list;
        }

        private List<RmsMeanInfo> DataTableToList_RmsMeanInfo(DataTable dt)
        {
            List<RmsMeanInfo> list = new List<RmsMeanInfo>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RmsMeanInfo rmsmean = new RmsMeanInfo();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        rmsmean.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["SurveyVehicle"] != null)
                    {
                        rmsmean.SurveyVehicle = dt.Rows[i]["SurveyVehicle"].ToString();
                    }
                    if (dt.Rows[i]["LineType"] != null)
                    {
                        rmsmean.LineType = dt.Rows[i]["LineType"].ToString();
                    }
                    if (dt.Rows[i]["SpeedLevel"] != null)
                    {
                        rmsmean.SpeedLevel = Convert.ToDouble(dt.Rows[i]["SpeedLevel"]);
                    }

                    if (dt.Rows[i]["SurveySystem"] != null)
                    {
                        rmsmean.SurveySystem = dt.Rows[i]["SurveySystem"].ToString();
                    }

                    if (dt.Rows[i]["Rms_mean_LeftAxisVertical"] != null)
                    {
                        rmsmean.Rms_mean_LeftAxisVertical = Convert.ToDouble(dt.Rows[i]["Rms_mean_LeftAxisVertical"]);
                    }

                    if (dt.Rows[i]["Rms_mean_RightAxisVertical"] != null)
                    {
                        rmsmean.Rms_mean_RightAxisVertical = Convert.ToDouble(dt.Rows[i]["Rms_mean_RightAxisVertical"]);
                    }

                    if (dt.Rows[i]["Rms_mean_LeftAxisHorizontal"] != null)
                    {
                        rmsmean.Rms_mean_LeftAxisHorizontal = Convert.ToDouble(dt.Rows[i]["Rms_mean_LeftAxisHorizontal"]);
                    }

                    list.Add(rmsmean);
                }
            }

            return list;
        }

        #endregion
    }
}

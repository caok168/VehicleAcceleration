using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using VehicleAcceleration.Model;
using System.Data;
using VehicleAcceleration.Common;

namespace VehicleAcceleration.Classes
{
    /// <summary>
    /// 操作波形数据类
    /// </summary>
    public partial class WaveDataResultDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("", "data.mdb");

        NLog.Logger logger = NLog.LogManager.GetLogger("");

        public WaveDataResultDAL(string fileFullPath)
        {
            connStr = ConfigHelper.GetAccessDbConn(1, fileFullPath);
        }

        /// <summary>
        /// 根据通道序号来获取通道波形数据
        /// </summary>
        /// <param name="channelID">通道序号</param>
        /// <returns></returns>
        public List<WaveDataResult> GetList()
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from WaveDataResult ", connStr, "WaveDataResult");
            list = DataTableToList_WaveDataResult_Calc2(dt);

            return list;
        }

        public List<WaveDataResult> GetListCalc()
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from WaveDataResult ", connStr, "WaveDataResult");
            list = DataTableToList_WaveDataResult_Calc(dt);

            return list;
        }

        public List<WaveDataResult> GetListTop500()
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select top 500 * from WaveDataResult ", connStr, "WaveDataResult");
            list = DataTableToList_WaveDataResult_Calc2(dt);

            return list;
        }

        public double GetActualMile()
        {
            List<WaveDataResult> list = GetList();
            double startMile = list.Select(s => s.StartMile).Min();
            double endMile = list.Select(s => s.StartMile).Max();

            double actualMile = endMile - startMile;

            return actualMile;
        }


        public bool Add(WaveDataResult data)
        {
            bool isok = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into WaveDataResult(");
            sbSql.Append("AvgSpeed,StartMile,");
            sbSql.Append("LeftAxisVertical_MaxValueMile,LeftAxisVertical_RmsValue,LeftAxisVertical_PeakIndex,");
            sbSql.Append("RightAxisVertical_MaxValueMile,RightAxisVertical_RmsValue,RightAxisVertical_PeakIndex,");
            sbSql.Append("LeftAxisHorizontal_MaxValueMile,LeftAxisHorizontal_RmsValue,LeftAxisHorizontal_PeakIndex,");
            sbSql.Append("FrameVertical_MaxValueMile,FrameVertical_RmsValue,FrameVertical_PeakIndex,");
            sbSql.Append("FrameHorizontal_MaxValueMile,FrameHorizontal_RmsValue,FrameHorizontal_PeakIndex,");
            sbSql.Append("BodyVertical_MaxValueMile,BodyVertical_RmsValue,BodyVertical_PeakIndex,");
            sbSql.Append("BodyHorizontal_MaxValueMile,BodyHorizontal_RmsValue,BodyHorizontal_PeakIndex ");
            sbSql.Append(") values(");

            sbSql.Append(data.AvgSpeed).Append(",").Append(data.StartMile).Append(",");
            sbSql.Append(data.LeftAxisVertical_MaxValueMile).Append(",").Append(data.LeftAxisVertical_RmsValue).Append(",").Append(data.LeftAxisVertical_PeakIndex).Append(",");
            sbSql.Append(data.RightAxisVertical_MaxValueMile).Append(",").Append(data.RightAxisVertical_RmsValue).Append(",").Append(data.RightAxisVertical_PeakIndex).Append(",");
            sbSql.Append(data.LeftAxisHorizontal_MaxValueMile).Append(",").Append(data.LeftAxisHorizontal_RmsValue).Append(",").Append(data.LeftAxisHorizontal_PeakIndex).Append(",");
            sbSql.Append(data.FrameVertical_MaxValueMile).Append(",").Append(data.FrameVertical_RmsValue).Append(",").Append(data.FrameVertical_PeakIndex).Append(",");
            sbSql.Append(data.FrameHorizontal_MaxValueMile).Append(",").Append(data.FrameHorizontal_RmsValue).Append(",").Append(data.FrameHorizontal_PeakIndex).Append(",");
            sbSql.Append(data.BodyVertical_MaxValueMile).Append(",").Append(data.BodyVertical_RmsValue).Append(",").Append(data.BodyVertical_PeakIndex).Append(",");
            sbSql.Append(data.BodyHorizontal_MaxValueMile).Append(",").Append(data.BodyHorizontal_RmsValue).Append(",").Append(data.BodyHorizontal_PeakIndex);

            sbSql.Append(")");

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isok = true;
            }

            return isok;
        }

        public bool Delete()
        {
            bool isok = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("delete from WaveDataResult ");


            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isok = true;
            }

            return isok;
        }


        public void Add(List<WaveDataResult> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                bool isok = Add(list[i]);
                if (!isok)
                {
                    logger.Error("插入WaveDataResult失败：开始里程：" + list[i].StartMile + "平均速度：" + list[i].AvgSpeed);
                }
            }
        }


        #region 将DataTable转换成List

        private List<WaveDataResult> DataTableToList_WaveDataResult(DataTable dt)
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WaveDataResult paramter = new WaveDataResult();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["AvgSpeed"] != null)
                    {
                        paramter.AvgSpeed = Convert.ToDouble(dt.Rows[i]["AvgSpeed"]);
                    }
                    if (dt.Rows[i]["StartMile"] != null)
                    {
                        paramter.StartMile = Convert.ToDouble(dt.Rows[i]["StartMile"]);
                    }


                    if (dt.Rows[i]["LeftAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["LeftAxisVertical_RmsValue"] != null)
                    {
                        paramter.LeftAxisVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_RmsValue"]);
                    }
                    if (dt.Rows[i]["LeftAxisVertical_PeakIndex"] != null)
                    {
                        paramter.LeftAxisVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["RightAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.RightAxisVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["RightAxisVertical_RmsValue"] != null)
                    {
                        paramter.RightAxisVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_RmsValue"]);
                    }
                    if (dt.Rows[i]["RightAxisVertical_PeakIndex"] != null)
                    {
                        paramter.RightAxisVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_RmsValue"] != null)
                    {
                        paramter.LeftAxisHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_RmsValue"]);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_PeakIndex"] != null)
                    {
                        paramter.LeftAxisHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_PeakIndex"]);
                    }

                    if (dt.Rows[i]["FrameVertical_MaxValueMile"] != null)
                    {
                        paramter.FrameVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["FrameVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["FrameVertical_RmsValue"] != null)
                    {
                        paramter.FrameVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["FrameVertical_RmsValue"]);
                    }
                    if (dt.Rows[i]["FrameVertical_PeakIndex"] != null)
                    {
                        paramter.FrameVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["FrameVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["FrameHorizontal_MaxValueMile"] != null)
                    {
                        paramter.FrameHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["FrameHorizontal_RmsValue"] != null)
                    {
                        paramter.FrameHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_RmsValue"]);
                    }
                    if (dt.Rows[i]["FrameHorizontal_PeakIndex"] != null)
                    {
                        paramter.FrameHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_PeakIndex"]);
                    }

                    if (dt.Rows[i]["BodyVertical_MaxValueMile"] != null)
                    {
                        paramter.BodyVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["BodyVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["BodyVertical_RmsValue"] != null)
                    {
                        paramter.BodyVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["BodyVertical_RmsValue"]);
                    }
                    if (dt.Rows[i]["BodyVertical_PeakIndex"] != null)
                    {
                        paramter.BodyVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["BodyVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["BodyHorizontal_MaxValueMile"] != null)
                    {
                        paramter.BodyHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["BodyHorizontal_RmsValue"] != null)
                    {
                        paramter.BodyHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_RmsValue"]);
                    }
                    if (dt.Rows[i]["BodyHorizontal_PeakIndex"] != null)
                    {
                        paramter.BodyHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_PeakIndex"]);
                    }


                    list.Add(paramter);
                }
            }

            return list;
        }


        private List<WaveDataResult> DataTableToList_WaveDataResult_Calc(DataTable dt)
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WaveDataResult paramter = new WaveDataResult();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["AvgSpeed"] != null)
                    {
                        paramter.AvgSpeed = Convert.ToDouble(dt.Rows[i]["AvgSpeed"]);
                    }
                    if (dt.Rows[i]["StartMile"] != null)
                    {
                        paramter.StartMile = Convert.ToDouble(dt.Rows[i]["StartMile"]);
                    }


                    if (dt.Rows[i]["LeftAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["LeftAxisVertical_RmsValue"] != null)
                    {
                        paramter.LeftAxisVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["LeftAxisVertical_PeakIndex"] != null)
                    {
                        paramter.LeftAxisVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["RightAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.RightAxisVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["RightAxisVertical_RmsValue"] != null)
                    {
                        paramter.RightAxisVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["RightAxisVertical_PeakIndex"] != null)
                    {
                        paramter.RightAxisVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["RightAxisVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_RmsValue"] != null)
                    {
                        paramter.LeftAxisHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_PeakIndex"] != null)
                    {
                        paramter.LeftAxisHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_PeakIndex"]);
                    }

                    if (dt.Rows[i]["FrameVertical_MaxValueMile"] != null)
                    {
                        paramter.FrameVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["FrameVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["FrameVertical_RmsValue"] != null)
                    {
                        paramter.FrameVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["FrameVertical_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["FrameVertical_PeakIndex"] != null)
                    {
                        paramter.FrameVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["FrameVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["FrameHorizontal_MaxValueMile"] != null)
                    {
                        paramter.FrameHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["FrameHorizontal_RmsValue"] != null)
                    {
                        paramter.FrameHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["FrameHorizontal_PeakIndex"] != null)
                    {
                        paramter.FrameHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["FrameHorizontal_PeakIndex"]);
                    }

                    if (dt.Rows[i]["BodyVertical_MaxValueMile"] != null)
                    {
                        paramter.BodyVertical_MaxValueMile = Convert.ToDouble(dt.Rows[i]["BodyVertical_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["BodyVertical_RmsValue"] != null)
                    {
                        paramter.BodyVertical_RmsValue = Convert.ToDouble(dt.Rows[i]["BodyVertical_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["BodyVertical_PeakIndex"] != null)
                    {
                        paramter.BodyVertical_PeakIndex = Convert.ToDouble(dt.Rows[i]["BodyVertical_PeakIndex"]);
                    }

                    if (dt.Rows[i]["BodyHorizontal_MaxValueMile"] != null)
                    {
                        paramter.BodyHorizontal_MaxValueMile = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_MaxValueMile"]);
                    }
                    if (dt.Rows[i]["BodyHorizontal_RmsValue"] != null)
                    {
                        paramter.BodyHorizontal_RmsValue = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_RmsValue"]) * 10;
                    }
                    if (dt.Rows[i]["BodyHorizontal_PeakIndex"] != null)
                    {
                        paramter.BodyHorizontal_PeakIndex = Convert.ToDouble(dt.Rows[i]["BodyHorizontal_PeakIndex"]);
                    }


                    list.Add(paramter);
                }
            }

            return list;
        }


        private List<WaveDataResult> DataTableToList_WaveDataResult_Calc2(DataTable dt)
        {
            List<WaveDataResult> list = new List<WaveDataResult>();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WaveDataResult paramter = new WaveDataResult();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["AvgSpeed"] != null)
                    {
                        paramter.AvgSpeed = Math.Round(Convert.ToDouble(dt.Rows[i]["AvgSpeed"]), 0);
                    }
                    if (dt.Rows[i]["StartMile"] != null)
                    {
                        paramter.StartMile = Math.Round(Convert.ToDouble(dt.Rows[i]["StartMile"]), 3);
                    }


                    if (dt.Rows[i]["LeftAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisVertical_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["LeftAxisVertical_RmsValue"] != null)
                    {
                        paramter.LeftAxisVertical_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["LeftAxisVertical_PeakIndex"] != null)
                    {
                        paramter.LeftAxisVertical_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisVertical_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["RightAxisVertical_MaxValueMile"] != null)
                    {
                        paramter.RightAxisVertical_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["RightAxisVertical_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["RightAxisVertical_RmsValue"] != null)
                    {
                        paramter.RightAxisVertical_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["RightAxisVertical_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["RightAxisVertical_PeakIndex"] != null)
                    {
                        paramter.RightAxisVertical_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["RightAxisVertical_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"] != null)
                    {
                        paramter.LeftAxisHorizontal_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_RmsValue"] != null)
                    {
                        paramter.LeftAxisHorizontal_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontal_PeakIndex"] != null)
                    {
                        paramter.LeftAxisHorizontal_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontal_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["FrameVertical_MaxValueMile"] != null)
                    {
                        paramter.FrameVertical_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameVertical_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["FrameVertical_RmsValue"] != null)
                    {
                        paramter.FrameVertical_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameVertical_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["FrameVertical_PeakIndex"] != null)
                    {
                        paramter.FrameVertical_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameVertical_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["FrameHorizontal_MaxValueMile"] != null)
                    {
                        paramter.FrameHorizontal_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameHorizontal_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["FrameHorizontal_RmsValue"] != null)
                    {
                        paramter.FrameHorizontal_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameHorizontal_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["FrameHorizontal_PeakIndex"] != null)
                    {
                        paramter.FrameHorizontal_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["FrameHorizontal_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["BodyVertical_MaxValueMile"] != null)
                    {
                        paramter.BodyVertical_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyVertical_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["BodyVertical_RmsValue"] != null)
                    {
                        paramter.BodyVertical_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyVertical_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["BodyVertical_PeakIndex"] != null)
                    {
                        paramter.BodyVertical_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyVertical_PeakIndex"]),2);
                    }

                    if (dt.Rows[i]["BodyHorizontal_MaxValueMile"] != null)
                    {
                        paramter.BodyHorizontal_MaxValueMile = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyHorizontal_MaxValueMile"]),3);
                    }
                    if (dt.Rows[i]["BodyHorizontal_RmsValue"] != null)
                    {
                        paramter.BodyHorizontal_RmsValue = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyHorizontal_RmsValue"]) * 10,2);
                    }
                    if (dt.Rows[i]["BodyHorizontal_PeakIndex"] != null)
                    {
                        paramter.BodyHorizontal_PeakIndex = Math.Round(Convert.ToDouble(dt.Rows[i]["BodyHorizontal_PeakIndex"]),2);
                    }


                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion
    }
}

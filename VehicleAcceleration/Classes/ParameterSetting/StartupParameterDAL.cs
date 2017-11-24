using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using VehicleAcceleration.Model;
using VehicleAcceleration.Common;

namespace VehicleAcceleration.Classes
{
    /// <summary>
    /// 启动参数操作类
    /// </summary>
    public class StartupParameterDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");


        #region 获取检测车型号、线路名、行别、增减里程类型、检测方向、运行方向

        /// <summary>
        /// 获取检测车型号
        /// </summary>
        /// <returns></returns>
        public List<string> getSurveyVehicleVersion()
        {
            List<string> list = new List<string>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from SurveyVehicleVersion", connStr, "SurveyVehicleVersion");
            list = DataTableToList(dt);

            return list;
        }

        /// <summary>
        /// 获取线路名
        /// </summary>
        /// <returns></returns>
        public List<string> getLineName()
        {
            List<string> list = new List<string>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from Line", connStr, "Line");
            list = DataTableToList(dt);

            return list;
        }

        /// <summary>
        /// 获取行别
        /// </summary>
        /// <returns></returns>
        public List<string> getWalkType()
        {
            List<string> list = new List<string>();
            list.Add("上行");
            list.Add("下行");
            list.Add("单线");

            return list;
        }

        /// <summary>
        /// 获取增减里程类型
        /// </summary>
        /// <returns></returns>
        public List<string> getMileageType()
        {
            List<string> list = new List<string>();
            list.Add("增里程");
            list.Add("减里程");

            return list;
        }

        /// <summary>
        /// 获取检测方向
        /// </summary>
        /// <returns></returns>
        public List<string> getSurveyDirection()
        {
            List<string> list = new List<string>();
            //list.Add("1车在前");
            //list.Add("8车在后");
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from SurveyDirection", connStr, "SurveyDirection");
            list = DataTableToList(dt);

            return list;
        }

        /// <summary>
        /// 获取运行方向
        /// </summary>
        /// <returns></returns>
        public List<string> getRunDirection()
        {
            List<string> list = new List<string>();
            list.Add("正向运行");
            list.Add("反向运行");

            return list;
        }


        #endregion

        #region 启动参数数据库操作

        /// <summary>
        /// 获取保存的启动参数信息
        /// </summary>
        /// <returns></returns>
        public List<StartupParameter> getStartupParamter()
        {
            List<StartupParameter> list = new List<StartupParameter>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from StartupParamter", connStr, "StartupParamter");
            list = DataTableToList_Paramter(dt);

            return list;
        }

        /// <summary>
        /// 保存启动参数信息
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public bool SaveStartupParamter(StartupParameter paramter)
        {
            bool isOk = false;
            if (paramter.ID != null)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update StartupParamter set ");
                sbSql.Append(" SurveyorName='").Append(paramter.SurveyorName).Append("',");
                sbSql.Append(" SurveyVehicleVersion='").Append(paramter.SurveyVehicleVersion).Append("',");
                sbSql.Append(" LineName='").Append(paramter.LineName).Append("',");
                sbSql.Append(" WalkType='").Append(paramter.WalkType).Append("',");
                sbSql.Append(" MileageType='").Append(paramter.MileageType).Append("',");
                sbSql.Append(" OrigialMileage=").Append(paramter.OrigialMileage).Append(",");
                sbSql.Append(" SurveyDirection='").Append(paramter.SurveyDirection).Append("',");
                sbSql.Append(" RunDirection='").Append(paramter.RunDirection).Append("' ");
                sbSql.Append(" where ID=").Append(paramter.ID);

                int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
                if (i > 0)
                {
                    isOk = true;
                }
            }
            else
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into StartupParamter(SurveyorName,SurveyVehicleVersion,LineName,");
                sbSql.Append("WalkType,MileageType,OrigialMileage,SurveyDirection,RunDirection) values (");
                sbSql.Append("'").Append(paramter.SurveyorName).Append("',");
                sbSql.Append("'").Append(paramter.SurveyVehicleVersion).Append("',");
                sbSql.Append("'").Append(paramter.LineName).Append("',");
                sbSql.Append("'").Append(paramter.WalkType).Append("',");
                sbSql.Append("'").Append(paramter.MileageType).Append("',");
                sbSql.Append("").Append(paramter.OrigialMileage).Append(",");
                sbSql.Append("'").Append(paramter.SurveyDirection).Append("',");
                sbSql.Append("'").Append(paramter.RunDirection).Append("')");

                int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
                if (i > 0)
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        #endregion

        #region 私有方法 将DataTable转换成List集合

        private List<string> DataTableToList(DataTable dt)
        {
            List<string> list = new List<string>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Name"] != null)
                    {
                        list.Add(dt.Rows[i]["Name"].ToString());
                    }
                }
            }

            return list;
        }


        private List<StartupParameter> DataTableToList_Paramter(DataTable dt)
        {
            List<StartupParameter> list = new List<StartupParameter>();
            if (dt != null)
            {
                StartupParameter paramter = new StartupParameter();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["SurveyorName"] != null)
                    {
                        paramter.SurveyorName = dt.Rows[i]["SurveyorName"].ToString();
                    }
                    if (dt.Rows[i]["SurveyVehicleVersion"] != null)
                    {
                        paramter.SurveyVehicleVersion = dt.Rows[i]["SurveyVehicleVersion"].ToString();
                    }
                    if (dt.Rows[i]["LineName"] != null)
                    {
                        paramter.LineName = dt.Rows[i]["LineName"].ToString();
                    }
                    if (dt.Rows[i]["WalkType"] != null)
                    {
                        paramter.WalkType = dt.Rows[i]["WalkType"].ToString();
                    }
                    if (dt.Rows[i]["MileageType"] != null)
                    {
                        paramter.MileageType = dt.Rows[i]["MileageType"].ToString();
                    }
                    if (dt.Rows[i]["OrigialMileage"] != null)
                    {
                        paramter.OrigialMileage = Convert.ToDouble(dt.Rows[i]["OrigialMileage"]);
                    }
                    if (dt.Rows[i]["SurveyDirection"] != null)
                    {
                        paramter.SurveyDirection = dt.Rows[i]["SurveyDirection"].ToString();
                    }
                    if (dt.Rows[i]["RunDirection"] != null)
                    {
                        paramter.RunDirection = dt.Rows[i]["RunDirection"].ToString();
                    }
                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion

    }
}

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
    /// 用于记录生成文件的基本信息
    /// </summary>
    public class BasicInfoDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        public List<BasicInfo> GetList(bool isComplete = true)
        {
            List<BasicInfo> list = new List<BasicInfo>();

            string sql = "select * from BasicInfo ";
            if (isComplete)
            {
                sql += " where IsComplete<>0 ";//不等于0
            }
            sql += " order by ID desc ";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list;
        }

        public BasicInfo Get(int ID)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from BasicInfo where ID=" + ID, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public BasicInfo Get(string LineName)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            string strSql = "select * from BasicInfo where LineName='" + LineName + "'  order by ID desc ";
            DataTable dt = DataAccess.AccessHelper.Get_DataTable(strSql, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public BasicInfo Get(string LineName, string SurveyorName)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            string strSql = "select * from BasicInfo where LineName='" + LineName + "' and SurveyorName='"+ SurveyorName +"' order by ID desc ";
            DataTable dt = DataAccess.AccessHelper.Get_DataTable(strSql, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public BasicInfo Get(string LineName, string RunDirection, string SurveyDirection)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            string strSql = "select * from BasicInfo where LineName='" + LineName + "' and RunDirection='" + RunDirection + "' and SurveyDirection='" + SurveyDirection + "' order by RunDate desc ";
            DataTable dt = DataAccess.AccessHelper.Get_DataTable(strSql, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public BasicInfo Get(string LineName, string SurveyorName, string RunDirection, string SurveyDirection)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            string strSql = "select * from BasicInfo where LineName='" + LineName + "' and RunDirection='" + RunDirection + "' and SurveyDirection='" + SurveyDirection + "' and SurveyorName='" + SurveyorName + "' order by RunDate desc ";
            DataTable dt = DataAccess.AccessHelper.Get_DataTable(strSql, connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public BasicInfo GetLatest()
        {
            List<BasicInfo> list = new List<BasicInfo>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select top 10 * from BasicInfo order by ID desc " , connStr, "BasicInfo");
            list = DataTableToList_BasicInfo(dt);

            return list.FirstOrDefault();
        }

        public int Add(BasicInfo model)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into BasicInfo(SurveyorName,SurveyVehicleVersion,LineName,");
            sbSql.Append("WalkType,MileageType,OrigialMileage,SurveyDirection,RunDirection,RunDate,RunTime,SerialNumber,IsComplete,ActualMile,MileMore200 ");
            sbSql.Append(") values (");
            sbSql.Append("'").Append(model.SurveyorName).Append("',");
            sbSql.Append("'").Append(model.SurveyVehicleVersion).Append("',");
            sbSql.Append("'").Append(model.LineName).Append("',");
            sbSql.Append("'").Append(model.WalkType).Append("',");
            sbSql.Append("'").Append(model.MileageType).Append("',");
            sbSql.Append("").Append(model.OrigialMileage).Append(",");
            sbSql.Append("'").Append(model.SurveyDirection).Append("',");
            sbSql.Append("'").Append(model.RunDirection).Append("',");

            sbSql.Append("'").Append(model.RunDate).Append("',");
            sbSql.Append("'").Append(model.RunTime).Append("',");
            sbSql.Append("'").Append(model.SerialNumber).Append("',");
            sbSql.Append("").Append(model.IsComplete).Append(",");
            sbSql.Append("").Append(model.ActualMile).Append(",");
            sbSql.Append("").Append(model.MileMore200).Append("");

            sbSql.Append(")");

            //int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            //if (i > 0)
            //{
            //    isOk = true;
            //}

            int ID = DataAccess.AccessHelper.GetInsertID(sbSql.ToString(), connStr);

            return ID;
        }

        public bool UpdateState(int ID, int IsComplete, string runTime)
        {
            bool isOk = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update BasicInfo set ");

            sbSql.Append(" RunTime='").Append(runTime).Append("', ");
            sbSql.Append(" IsComplete=").Append(IsComplete).Append(" ");

            sbSql.Append(" where ID=").Append(ID);

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isOk = true;
            }

            return isOk;
        }

        public bool UpdateState(int ID, int IsComplete, string runTime, double actualMile, double mileMore200)
        {
            bool isOk = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update BasicInfo set ");

            sbSql.Append(" RunTime='").Append(runTime).Append("', ");
            sbSql.Append(" IsComplete=").Append(IsComplete).Append(" ,");

            sbSql.Append(" ActualMile=").Append(actualMile).Append(" ,");
            sbSql.Append(" MileMore200=").Append(mileMore200).Append(" ");

            sbSql.Append(" where ID=").Append(ID);

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isOk = true;
            }

            return isOk;
        }

        public bool Update(BasicInfo model)
        {
            bool isOk = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update BasicInfo set ");
            sbSql.Append(" SurveyorName='").Append(model.SurveyorName).Append("',");
            sbSql.Append(" SurveyVehicleVersion='").Append(model.SurveyVehicleVersion).Append("',");
            sbSql.Append(" LineName='").Append(model.LineName).Append("',");
            sbSql.Append(" WalkType='").Append(model.WalkType).Append("',");
            sbSql.Append(" MileageType='").Append(model.MileageType).Append("',");
            sbSql.Append(" OrigialMileage=").Append(model.OrigialMileage).Append(",");
            sbSql.Append(" SurveyDirection='").Append(model.SurveyDirection).Append("',");
            sbSql.Append(" RunDirection='").Append(model.RunDirection).Append("', ");

            sbSql.Append(" RunDate='").Append(model.RunDate).Append("', ");
            sbSql.Append(" RunTime='").Append(model.RunTime).Append("', ");
            sbSql.Append(" SerialNumber='").Append(model.SerialNumber).Append("', ");
            sbSql.Append(" IsComplete=").Append(model.IsComplete).Append(" ");

            sbSql.Append(" where ID=").Append(model.ID);

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isOk = true;
            }

            return isOk;
        }

        public bool Delete(int ID)
        {
            bool isOk = false;
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("delete from BasicInfo where ID=").Append(ID);

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isOk = true;
            }

            return isOk;
        }



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
        /// 获取线路所有信息
        /// </summary>
        /// <returns></returns>
        public List<Line> getLine()
        {
            List<Line> list = new List<Line>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from Line", connStr, "Line");
            list = DataTableTo_LineList(dt);

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


        #region 私有方法


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

        private List<Line> DataTableTo_LineList(DataTable dt)
        {
            List<Line> list = new List<Line>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Line line = new Line();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        line.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["Name"] != null)
                    {
                        line.LineName = dt.Rows[i]["Name"].ToString();
                    }

                    if (dt.Rows[i]["LineNameCn"] != null)
                    {
                        line.LineNameCn = dt.Rows[i]["LineNameCn"].ToString();
                    }

                    list.Add(line);
                }
            }

            return list;
        }


        private List<BasicInfo> DataTableToList_BasicInfo(DataTable dt)
        {
            List<BasicInfo> list = new List<BasicInfo>();
            if (dt != null)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BasicInfo paramter = new BasicInfo();

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

                    if (dt.Rows[i]["RunDate"] != null)
                    {
                        paramter.RunDate = dt.Rows[i]["RunDate"].ToString();
                    }

                    if (dt.Rows[i]["RunTime"] != null)
                    {
                        paramter.RunTime = dt.Rows[i]["RunTime"].ToString();
                    }

                    if (dt.Rows[i]["SerialNumber"] != null)
                    {
                        paramter.SerialNumber = dt.Rows[i]["SerialNumber"].ToString();
                    }

                    if (dt.Rows[i]["IsComplete"] != null)
                    {
                        paramter.IsComplete = Convert.ToInt32(dt.Rows[i]["IsComplete"]);
                    }


                    if (dt.Rows[i]["ActualMile"] != null)
                    {
                        paramter.ActualMile = Convert.ToDouble(dt.Rows[i]["ActualMile"]);
                    }

                    if (dt.Rows[i]["MileMore200"] != null)
                    {
                        paramter.MileMore200 = Convert.ToDouble(dt.Rows[i]["MileMore200"]);
                    }


                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion

    }
}

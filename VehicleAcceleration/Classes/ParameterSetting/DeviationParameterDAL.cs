using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;
using System.Data;

namespace VehicleAcceleration.Classes
{
    /// <summary>
    /// 偏差阈值参数设置 操作类
    /// </summary>
    public class DeviationParameterDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        /// <summary>
        /// 获取偏差阈值参数
        /// </summary>
        /// <returns></returns>
        public List<DeviationParameter> GetDeviationParameterList()
        {
            List<DeviationParameter> list = new List<DeviationParameter>();
            string sql = "select * from DeviationParameter ";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "DeviationParameter");
            list = DataTableToList_DeviationParameter(dt);

            return list;
        }

        /// <summary>
        /// 获取偏差阈值参数（2*3 double数组）
        /// </summary>
        /// <returns></returns>
        public double[,] GetDeviationParameter()
        {
            double[,] thresh_tii = new double[2, 3];
            DeviationParameter param = GetDeviationParameterList().FirstOrDefault();
            if (param != null)
            {
                thresh_tii[0, 0] = param.Value1_1;
                thresh_tii[0, 1] = param.Value1_2;
                thresh_tii[0, 2] = param.Value1_3;
                                   
                thresh_tii[1, 0] = param.Value2_1;
                thresh_tii[1, 1] = param.Value2_2;
                thresh_tii[1, 2] = param.Value2_3;
            }
            return thresh_tii;
        }


        public bool Save(DeviationParameter paramter)
        {
            bool isOk = false;
            StringBuilder sbSql = new StringBuilder();

            if (paramter.ID != null)
            {
                sbSql.Append("update DeviationParameter set ");
                sbSql.Append(" value1_1=").Append(paramter.Value1_1).Append(",");
                sbSql.Append(" value1_2=").Append(paramter.Value1_2).Append(",");
                sbSql.Append(" value1_3=").Append(paramter.Value1_3).Append(",");

                sbSql.Append(" value2_1=").Append(paramter.Value2_1).Append(",");
                sbSql.Append(" value2_2=").Append(paramter.Value2_2).Append(",");
                sbSql.Append(" value2_3=").Append(paramter.Value2_3).Append("");

                sbSql.Append(" where ID=").Append(paramter.ID);
            }
            else
            {
                sbSql.Append("insert into DeviationParameter(");
                sbSql.Append("value1_1,value1_2,value1_3,value2_1,value2_2,value2_3) values(");
                sbSql.Append(paramter.Value1_1).Append(",");
                sbSql.Append(paramter.Value1_2).Append(",");
                sbSql.Append(paramter.Value1_3).Append(",");
                sbSql.Append(paramter.Value2_1).Append(",");
                sbSql.Append(paramter.Value2_2).Append(",");
                sbSql.Append(paramter.Value2_3).Append(")");
            }

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isOk = true;
            }

            return isOk;
        }

        #region 私有方法

        private List<DeviationParameter> DataTableToList_DeviationParameter(DataTable dt)
        {
            List<DeviationParameter> list = new List<DeviationParameter>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DeviationParameter parameter = new DeviationParameter();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        parameter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["Value1_1"] != null)
                    {
                        parameter.Value1_1 = Convert.ToDouble(dt.Rows[i]["Value1_1"]);
                    }
                    if (dt.Rows[i]["Value1_2"] != null)
                    {
                        parameter.Value1_2 = Convert.ToDouble(dt.Rows[i]["Value1_2"]);
                    }
                    if (dt.Rows[i]["Value1_3"] != null)
                    {
                        parameter.Value1_3 = Convert.ToDouble(dt.Rows[i]["Value1_3"]);
                    }

                    if (dt.Rows[i]["Value2_1"] != null)
                    {
                        parameter.Value2_1 = Convert.ToDouble(dt.Rows[i]["Value2_1"]);
                    }
                    if (dt.Rows[i]["Value2_2"] != null)
                    {
                        parameter.Value2_2 = Convert.ToDouble(dt.Rows[i]["Value2_2"]);
                    }
                    if (dt.Rows[i]["Value2_3"] != null)
                    {
                        parameter.Value2_3 = Convert.ToDouble(dt.Rows[i]["Value2_3"]);
                    }

                    list.Add(parameter);
                }
            }

            return list;
        }

        #endregion

    }
}

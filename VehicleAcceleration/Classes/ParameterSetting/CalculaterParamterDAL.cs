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
    /// 计算参数操作类
    /// </summary>
    public class CalculaterParamterDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        /// <summary>
        /// 读取计算参数信息
        /// </summary>
        /// <returns></returns>
        public List<CalculaterParamter> GetList()
        {
            List<CalculaterParamter> list = new List<CalculaterParamter>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from CalculaterParamter", connStr, "CalculaterParamter");
            list = DataTableToList_CalcParamter(dt);

            return list;
        }

        /// <summary>
        /// 保存计算参数信息
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public bool Save(CalculaterParamter paramter)
        {
            bool isOk = false;

            if (paramter.ID != null)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update CalculaterParamter set ");
                sbSql.Append(" ComputingTime=").Append(paramter.ComputingTime).Append(",");
                sbSql.Append(" SamplingFrequency=").Append(paramter.SamplingFrequency).Append(",");
                sbSql.Append(" EffectiveValueLength=").Append(paramter.EffectiveValueLength).Append(",");
                sbSql.Append(" SamplingPoints=").Append(paramter.SamplingPoints).Append(",");
                sbSql.Append(" SpeedGrade=").Append(paramter.SpeedGrade).Append(",");
                sbSql.Append(" MaxValueLength=").Append(paramter.MaxValueLength).Append(",");
                sbSql.Append(" LowSpeedControlValue='").Append(paramter.LowSpeedControlValue).Append("',");
                sbSql.Append(" LowSpeedControlRate=").Append(paramter.LowSpeedControlRate).Append(" ");
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
                sbSql.Append("insert into CalculaterParamter(ComputingTime,SamplingFrequency,EffectiveValueLength,SamplingPoints,");
                sbSql.Append("SpeedGrade,MaxValueLength,LowSpeedControlValue,LowSpeedControlRate) values(");
                sbSql.Append(paramter.ComputingTime).Append(",");
                sbSql.Append(paramter.SamplingFrequency).Append(",");
                sbSql.Append(paramter.EffectiveValueLength).Append(",");
                sbSql.Append(paramter.SamplingPoints).Append(",");
                sbSql.Append(paramter.SpeedGrade).Append(",");
                sbSql.Append(paramter.MaxValueLength).Append(",");
                sbSql.Append(paramter.LowSpeedControlValue).Append(",");
                sbSql.Append(paramter.LowSpeedControlRate).Append(")");

                int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
                if (i > 0)
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        #region 私有方法

        /// <summary>
        /// 将计算参数的DataTable转换成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<CalculaterParamter> DataTableToList_CalcParamter(DataTable dt)
        {
            List<CalculaterParamter> list = new List<CalculaterParamter>();
            if (dt != null)
            {
                CalculaterParamter paramter = new CalculaterParamter();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["ComputingTime"] != null)
                    {
                        paramter.ComputingTime = Convert.ToInt32(dt.Rows[i]["ComputingTime"]);
                    }
                    if (dt.Rows[i]["SamplingFrequency"] != null)
                    {
                        paramter.SamplingFrequency = Convert.ToInt32(dt.Rows[i]["SamplingFrequency"]);
                    }
                    if (dt.Rows[i]["EffectiveValueLength"] != null)
                    {
                        paramter.EffectiveValueLength = Convert.ToInt32(dt.Rows[i]["EffectiveValueLength"]);
                    }
                    if (dt.Rows[i]["SamplingPoints"] != null)
                    {
                        paramter.SamplingPoints = Convert.ToInt32(dt.Rows[i]["SamplingPoints"]);
                    }
                    if (dt.Rows[i]["SpeedGrade"] != null)
                    {
                        paramter.SpeedGrade = Convert.ToInt32(dt.Rows[i]["SpeedGrade"]);
                    }
                    if (dt.Rows[i]["MaxValueLength"] != null)
                    {
                        paramter.MaxValueLength = Convert.ToInt32(dt.Rows[i]["MaxValueLength"]);
                    }
                    if (dt.Rows[i]["LowSpeedControlValue"] != null)
                    {
                        paramter.LowSpeedControlValue = Convert.ToInt32(dt.Rows[i]["LowSpeedControlValue"]);
                    }
                    if (dt.Rows[i]["LowSpeedControlRate"] != null)
                    {
                        paramter.LowSpeedControlRate = Convert.ToDouble(dt.Rows[i]["LowSpeedControlRate"]);
                    }
                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion
    }
}

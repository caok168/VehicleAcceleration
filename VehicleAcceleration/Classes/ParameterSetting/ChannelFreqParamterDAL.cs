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
    /// 通道参数操作类
    /// </summary>
    public class ChannelFreqParamterDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        /// <summary>
        /// 读取计算参数信息
        /// </summary>
        /// <returns></returns>
        public List<ChannelFreqParamter> GetList()
        {
            List<ChannelFreqParamter> list = new List<ChannelFreqParamter>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from ChannelFreqParamter", connStr, "ChannelFreqParamter");
            list = DataTableToList_ChannelParamter(dt);

            return list;
        }

        /// <summary>
        /// 保存通道参数信息
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public bool Save(ChannelFreqParamter paramter)
        {
            bool isOk = false;

            if (paramter.ID != null)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update ChannelFreqParamter set ");
                sbSql.Append(" LeftAxisVerticalLower=").Append(paramter.LeftAxisVerticalLower).Append(",");
                sbSql.Append(" LeftAxisVerticalUpper=").Append(paramter.LeftAxisVerticalUpper).Append(",");
                sbSql.Append(" RightAxisVerticalLower=").Append(paramter.RightAxisVerticalLower).Append(",");
                sbSql.Append(" RightAxisVerticalUpper=").Append(paramter.RightAxisVerticalUpper).Append(",");

                sbSql.Append(" LeftAxisHorizontalLower=").Append(paramter.LeftAxisHorizontalLower).Append(",");
                sbSql.Append(" LeftAxisHorizontalUpper=").Append(paramter.LeftAxisHorizontalUpper).Append(",");

                sbSql.Append(" FrameVerticalLower=").Append(paramter.FrameVerticalLower).Append(",");
                sbSql.Append(" FrameVerticalUpper=").Append(paramter.FrameVerticalUpper).Append(",");
                sbSql.Append(" FrameHorizontalLower=").Append(paramter.FrameHorizontalLower).Append(",");
                sbSql.Append(" FrameHorizontalUpper=").Append(paramter.FrameHorizontalUpper).Append(",");

                sbSql.Append(" BodyVerticalLower=").Append(paramter.BodyVerticalLower).Append(",");
                sbSql.Append(" BodyVerticalUpper=").Append(paramter.BodyVerticalUpper).Append(",");
                sbSql.Append(" BodyHorizontalLower=").Append(paramter.BodyHorizontalLower).Append(",");
                sbSql.Append(" BodyHorizontalUpper=").Append(paramter.BodyHorizontalUpper).Append(" ");
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
                sbSql.Append("insert into ChannelFreqParamter(");
                sbSql.Append("LeftAxisVerticalLower,LeftAxisVerticalUpper,RightAxisVerticalLower,RightAxisVerticalUpper,");
                sbSql.Append("LeftAxisHorizontalLower,LeftAxisHorizontalUpper,");
                sbSql.Append("FrameVerticalLower,FrameVerticalUpper,FrameHorizontalLower,FrameHorizontalUpper,");
                sbSql.Append("BodyVerticalLower,BodyVerticalUpper,BodyHorizontalLower,BodyHorizontalUpper) values(");
                sbSql.Append(paramter.LeftAxisVerticalLower).Append(",");
                sbSql.Append(paramter.LeftAxisVerticalUpper).Append(",");
                sbSql.Append(paramter.RightAxisVerticalLower).Append(",");
                sbSql.Append(paramter.RightAxisVerticalUpper).Append(",");

                sbSql.Append(paramter.LeftAxisHorizontalLower).Append(",");
                sbSql.Append(paramter.LeftAxisHorizontalUpper).Append(",");

                sbSql.Append(paramter.FrameVerticalLower).Append(",");
                sbSql.Append(paramter.FrameVerticalUpper).Append(",");
                sbSql.Append(paramter.FrameHorizontalLower).Append(",");
                sbSql.Append(paramter.FrameHorizontalUpper).Append(",");

                sbSql.Append(paramter.BodyVerticalLower).Append(",");
                sbSql.Append(paramter.BodyVerticalUpper).Append(",");
                sbSql.Append(paramter.BodyHorizontalLower).Append(",");
                sbSql.Append(paramter.BodyHorizontalUpper).Append(")");

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
        private List<ChannelFreqParamter> DataTableToList_ChannelParamter(DataTable dt)
        {
            List<ChannelFreqParamter> list = new List<ChannelFreqParamter>();
            if (dt != null)
            {
                ChannelFreqParamter paramter = new ChannelFreqParamter();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["LeftAxisVerticalLower"] != null)
                    {
                        paramter.LeftAxisVerticalLower = Convert.ToDouble(dt.Rows[i]["LeftAxisVerticalLower"]);
                    }
                    if (dt.Rows[i]["LeftAxisVerticalUpper"] != null)
                    {
                        paramter.LeftAxisVerticalUpper = Convert.ToDouble(dt.Rows[i]["LeftAxisVerticalUpper"]);
                    }
                    if (dt.Rows[i]["RightAxisVerticalLower"] != null)
                    {
                        paramter.RightAxisVerticalLower = Convert.ToDouble(dt.Rows[i]["RightAxisVerticalLower"]);
                    }
                    if (dt.Rows[i]["RightAxisVerticalUpper"] != null)
                    {
                        paramter.RightAxisVerticalUpper = Convert.ToDouble(dt.Rows[i]["RightAxisVerticalUpper"]);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontalLower"] != null)
                    {
                        paramter.LeftAxisHorizontalLower = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontalLower"]);
                    }
                    if (dt.Rows[i]["LeftAxisHorizontalUpper"] != null)
                    {
                        paramter.LeftAxisHorizontalUpper = Convert.ToDouble(dt.Rows[i]["LeftAxisHorizontalUpper"]);
                    }
                    if (dt.Rows[i]["FrameVerticalLower"] != null)
                    {
                        paramter.FrameVerticalLower = Convert.ToDouble(dt.Rows[i]["FrameVerticalLower"]);
                    }
                    if (dt.Rows[i]["FrameVerticalUpper"] != null)
                    {
                        paramter.FrameVerticalUpper = Convert.ToDouble(dt.Rows[i]["FrameVerticalUpper"]);
                    }
                    if (dt.Rows[i]["FrameHorizontalLower"] != null)
                    {
                        paramter.FrameHorizontalLower = Convert.ToDouble(dt.Rows[i]["FrameHorizontalLower"]);
                    }
                    if (dt.Rows[i]["FrameHorizontalUpper"] != null)
                    {
                        paramter.FrameHorizontalUpper = Convert.ToDouble(dt.Rows[i]["FrameHorizontalUpper"]);
                    }
                    if (dt.Rows[i]["BodyVerticalLower"] != null)
                    {
                        paramter.BodyVerticalLower = Convert.ToDouble(dt.Rows[i]["BodyVerticalLower"]);
                    }
                    if (dt.Rows[i]["BodyVerticalUpper"] != null)
                    {
                        paramter.BodyVerticalUpper = Convert.ToDouble(dt.Rows[i]["BodyVerticalUpper"]);
                    }
                    if (dt.Rows[i]["BodyHorizontalLower"] != null)
                    {
                        paramter.BodyHorizontalLower = Convert.ToDouble(dt.Rows[i]["BodyHorizontalLower"]);
                    }
                    if (dt.Rows[i]["BodyHorizontalUpper"] != null)
                    {
                        paramter.BodyHorizontalUpper = Convert.ToDouble(dt.Rows[i]["BodyHorizontalUpper"]);
                    }

                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion
    }
}

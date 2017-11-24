using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Common;
using System.Data;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Classes
{
    /// <summary>
    /// 操作超限结果类
    /// </summary>
    public partial class OverValueDataResultDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("", "data.mdb");

        NLog.Logger logger = NLog.LogManager.GetLogger("");

        public OverValueDataResultDAL(string fileFullPath)
        {
            connStr = ConfigHelper.GetAccessDbConn(1, fileFullPath);
        }

        /// <summary>
        /// 根据通道序号来获取通道波形数据
        /// </summary>
        /// <param name="channelID">通道序号</param>
        /// <returns></returns>
        public List<OverValueDataResult> GetList()
        {
            List<OverValueDataResult> list = new List<OverValueDataResult>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from OverValueDataResult ", connStr, "OverValueDataResult");
            list = DataTableToList_OverValueDataResult(dt);

            return list;
        }


        //public List<OverValueDataResult> GetListOrder()
        //{
        //    List<OverValueDataResult> list = new List<OverValueDataResult>();
        //    DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from OverValueDataResult order by ID ", connStr, "OverValueDataResult");
        //    list = DataTableToList_OverValueDataResult(dt);

        //    return list;
        //}

        public List<OverValueDataResult> GetListOrder()
        {
            List<OverValueDataResult> list = new List<OverValueDataResult>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from OverValueDataResult order by ChannelID ,Mile desc ", connStr, "OverValueDataResult");
            list = DataTableToList_OverValueDataResult(dt);

            return list;
        }


        public bool Add(OverValueDataResult data)
        {
            bool isok = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into OverValueDataResult(");
            sbSql.Append("Mile,Speed,");
            sbSql.Append("OverType,OverValueRms,OverValuePeak,");
            sbSql.Append("OverLength,OverLevel,IsValid,ChannelName,ChannelID");
            sbSql.Append(") values(");

            sbSql.Append(data.Mile).Append(",").Append(data.Speed).Append(",");
            sbSql.Append("'").Append(data.OverType).Append("',");
            sbSql.Append(data.OverValueRms).Append(",");
            sbSql.Append(data.OverValuePeak).Append(",");
            sbSql.Append(data.OverLength).Append(",");
            sbSql.Append("'").Append(data.OverLevel).Append("',");
            sbSql.Append(data.IsValid).Append(",");
            sbSql.Append("'").Append(data.ChannelName).Append("',");
            sbSql.Append(data.ChannelID).Append("");

            sbSql.Append(")");

            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isok = true;
            }

            return isok;
        }


        public bool Update(int id,int isValid)
        {
            bool isok = false;

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update OverValueDataResult set IsValid=").Append(isValid).Append(" where id=").Append(id);

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
            sbSql.Append("delete from OverValueDataResult ");


            int i = DataAccess.AccessHelper.Run_SQL(sbSql.ToString(), connStr);
            if (i > 0)
            {
                isok = true;
            }

            return isok;
        }


        public void Add(List<OverValueDataResult> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                bool isok = Add(list[i]);
                if (!isok)
                {
                    logger.Error("插入OverValueDataResult失败：里程：" + list[i].Mile + "速度：" + list[i].Speed);
                }
            }
        }


        #region 将DataTable转换成List

        private List<OverValueDataResult> DataTableToList_OverValueDataResult(DataTable dt)
        {
            List<OverValueDataResult> list = new List<OverValueDataResult>();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OverValueDataResult paramter = new OverValueDataResult();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        paramter.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["Mile"] != null)
                    {
                        paramter.Mile = Math.Round(Convert.ToDouble(dt.Rows[i]["Mile"]), 3);
                    }
                    if (dt.Rows[i]["Speed"] != null)
                    {
                        paramter.Speed = Math.Round(Convert.ToDouble(dt.Rows[i]["Speed"]), 0);
                    }

                    if (dt.Rows[i]["OverType"] != null)
                    {
                        paramter.OverType = dt.Rows[i]["OverType"].ToString();
                    }
                    if (dt.Rows[i]["OverValueRms"] != null)
                    {
                        paramter.OverValueRms = Math.Round(Convert.ToDouble(dt.Rows[i]["OverValueRms"]) * 10, 2);
                    }
                    if (dt.Rows[i]["OverValuePeak"] != null)
                    {
                        paramter.OverValuePeak = Math.Round(Convert.ToDouble(dt.Rows[i]["OverValuePeak"]), 2);
                    }

                    if (dt.Rows[i]["OverLength"] != null)
                    {
                        paramter.OverLength = Convert.ToDouble(dt.Rows[i]["OverLength"]);
                    }
                    if (dt.Rows[i]["OverLevel"] != null)
                    {
                        paramter.OverLevel = dt.Rows[i]["OverLevel"].ToString();
                    }
                    if (dt.Rows[i]["IsValid"] != null)
                    {
                        paramter.IsValid = Convert.ToInt32(dt.Rows[i]["IsValid"]);
                    }

                    if (dt.Rows[i]["ChannelName"] != null)
                    {
                        paramter.ChannelName = dt.Rows[i]["ChannelName"].ToString();
                    }

                    if (dt.Rows[i]["ChannelID"] != null)
                    {
                        paramter.ChannelID = Convert.ToInt32(dt.Rows[i]["ChannelID"]);
                    }
                    
                    list.Add(paramter);
                }
            }

            return list;
        }

        #endregion
    }
}

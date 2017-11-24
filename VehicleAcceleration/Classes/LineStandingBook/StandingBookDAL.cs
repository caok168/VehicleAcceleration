using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;
using System.Data;

namespace VehicleAcceleration.Classes.LineStandingBook
{
    /// <summary>
    /// 用于获取台账信息
    /// </summary>
    public class StandingBookDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        #region 台账信息、台账详情信息

        /// <summary>
        /// 获取所有线路的台账信息表
        /// </summary>
        /// <returns></returns>
        public List<StandingBook> GetStandingBook()
        {
            List<StandingBook> list = new List<StandingBook>();
            string sql = "select * from StandingBook ";

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, "StandingBook");
            list = DataTableToList_StandingBook(dt);

            return list;
        }

        /// <summary>
        /// 查询所有线路的台账详情
        /// </summary>
        /// <returns></returns>
        public List<StandingBookDetail> GetStandingBookDetail(string tableName)
        {
            List<StandingBookDetail> list = new List<StandingBookDetail>();
            string sql = "select * from " + tableName;

            DataTable dt = DataAccess.AccessHelper.Get_DataTable(sql, connStr, tableName);
            list = DataTableToList_StandingBookDetail(dt);

            return list;
        }

        

        #endregion

        #region 私有方法

        private List<StandingBook> DataTableToList_StandingBook(DataTable dt)
        {
            List<StandingBook> list = new List<StandingBook>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StandingBook book = new StandingBook();

                    if (dt.Rows[i]["ID"] != null)
                    {
                        book.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    }
                    if (dt.Rows[i]["LineName"] != null)
                    {
                        book.LineName = dt.Rows[i]["LineName"].ToString();
                    }
                    if (dt.Rows[i]["StandingBookName"] != null)
                    {
                        book.StandingBookName = dt.Rows[i]["StandingBookName"].ToString();
                    }
                    
                    list.Add(book);
                }
            }

            return list;
        }

        private List<StandingBookDetail> DataTableToList_StandingBookDetail(DataTable dt)
        {
            List<StandingBookDetail> list = new List<StandingBookDetail>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StandingBookDetail bookDetail = new StandingBookDetail();

                    if (dt.Rows[i]["StartMile"] != null)
                    {
                        bookDetail.StartMile = Convert.ToDouble(dt.Rows[i]["StartMile"]);
                    }

                    if (dt.Rows[i]["EndMile"] != null)
                    {
                        bookDetail.EndMile = Convert.ToDouble(dt.Rows[i]["EndMile"]);
                    }

                    if (dt.Rows[i]["Type"] != null)
                    {
                        bookDetail.Type = dt.Rows[i]["Type"].ToString();
                    }

                    list.Add(bookDetail);
                }
            }

            return list;
        }

        #endregion

    }
}

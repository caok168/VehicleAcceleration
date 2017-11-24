using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DataAccess
{
    /// <summary>
    /// 操作Access 数据库文件
    /// </summary>
    public partial class AccessHelper
    {
        #region 打开、关闭数据库链接
        /// <summary>
        /// 打开数据库链接
        /// </summary>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static OleDbConnection Open_Conn(string ConnStr)
        {
            OleDbConnection Conn = new OleDbConnection(ConnStr);
            Conn.Open();
            return Conn;
        }

        /// <summary>
        /// 关闭数据库链接
        /// </summary>
        /// <param name="Conn"></param>
        public static void Close_Conn(OleDbConnection Conn)
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
            GC.Collect();
        }

        #endregion

        #region 运行OleDb语句

        /// <summary>
        /// 运行OleDb语句
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static int Run_SQL(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbCommand Cmd = Create_Cmd(SQL, Conn);
            try
            {
                int result_count = Cmd.ExecuteNonQuery();
                Close_Conn(Conn);
                return result_count;
            }
            catch(Exception ex)
            {
                Close_Conn(Conn);
                return 0;
            }
        }

        #endregion

        #region 获取自动增长列ID

        public static int GetInsertID(string SQL,string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbCommand Cmd = Create_Cmd(SQL, Conn);
            try
            {
                int result_count = Cmd.ExecuteNonQuery();

                SQL = "SELECT @@IDENTITY";
                Cmd = Create_Cmd(SQL, Conn);
                int ID = (Int32)Cmd.ExecuteScalar();
                Close_Conn(Conn);
                return ID;
            }
            catch (Exception ex)
            {
                Close_Conn(Conn);
                return 0;
            }

        }

        #endregion

        #region 生成Command对象

        /// <summary>
        ///  生成Command对象 
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="Conn"></param>
        /// <returns></returns>
        public static OleDbCommand Create_Cmd(string SQL, OleDbConnection Conn)
        {
            OleDbCommand Cmd = new OleDbCommand(SQL, Conn);
            return Cmd;
        }

        #endregion

        #region 返回DataTable

        /// <summary>
        ///  运行OleDb语句返回 DataTable
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <param name="Table_name"></param>
        /// <returns></returns>
        public static DataTable Get_DataTable(string SQL, string ConnStr, string Table_name)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            DataTable dt = new DataTable(Table_name);
            Da.Fill(dt);
            return dt;
        }

        #endregion

        #region 返回OleDbDataReader对象

        /// <summary>
        ///  运行OleDb语句返回 OleDbDataReader对象
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static OleDbDataReader Get_Reader(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbCommand Cmd = Create_Cmd(SQL, Conn);
            OleDbDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return Dr;
        }

        #endregion

        #region 返回OleDbDataAdapter对象

        /// <summary>
        ///  运行OleDb语句返回 OleDbDataAdapter对象 
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static OleDbDataAdapter Get_Adapter(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbDataAdapter Da = new OleDbDataAdapter(SQL, Conn);
            return Da;
        }

        #endregion

        #region 返回DataSet对象

        /// <summary>
        ///  运行OleDb语句,返回DataSet对象
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            return Ds;
        }

        /// <summary>
        ///  运行OleDb语句,返回DataSet对象
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <param name="Ds"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds, string tablename)
        {
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }

        /// <summary>
        ///  运行OleDb语句,返回DataSet对象，将数据进行了分页
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <param name="Ds"></param>
        /// <param name="StartIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataSet Get_DataSet(string SQL, string ConnStr, DataSet Ds, int StartIndex, int PageSize, string tablename)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            OleDbDataAdapter Da = Get_Adapter(SQL, ConnStr);
            try
            {
                Da.Fill(Ds, StartIndex, PageSize, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Close_Conn(Conn);
            return Ds;
        }

        #endregion

        #region 返回结果的第一行第一列

        /// <summary>
        ///  返回OleDb语句执行结果的第一行第一列
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static string Get_Row1_Col1_Value(string SQL, string ConnStr)
        {
            OleDbConnection Conn = Open_Conn(ConnStr);
            string result;
            OleDbDataReader Dr;
            try
            {
                Dr = Create_Cmd(SQL, Conn).ExecuteReader();
                if (Dr.Read())
                {
                    result = Dr[0].ToString();
                    Dr.Close();
                }
                else
                {
                    result = "";
                    Dr.Close();
                }
            }
            catch
            {
                throw new Exception(SQL);
            }
            Close_Conn(Conn);
            return result;
        }

        #endregion

    }
}

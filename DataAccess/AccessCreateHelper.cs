using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ADOX;
using System.Data.OleDb;
using System.Data;

namespace DataAccess
{
    public partial class AccessHelper
    {
        #region 判断数据库是否存在

        /// <summary>
        /// 判断是不是存在当前路径名称的数据库
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsExistAccessDb(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 创建数据库

        /// <summary>
        /// 创建access数据库 （数据库文件名将以 Data+线路名+运行日期+NO+ID）
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateAccessDb(string filePath)
        {
            ADOX.Catalog catalog = new Catalog();
            if (!File.Exists(filePath))
            {
                try
                {
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Jet OLEDB:Engine Type=5");
                }
                catch (System.Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 创建数据库表结构

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="filePath">数据库文件路径</param>
        /// <param name="tableName">数据库表名称</param>
        /// <param name="colums">数据库表的列</param>
        /// <param name="isContainKeyID">是否包含主键ID自动增长列</param>
        public static void CreateAccessTable(string filePath, string tableName, ADOX.Column[] colums,bool isContainKeyID=true)
        {
            ADOX.Catalog catalog = new Catalog();
            //数据库文件不存在则创建
            if (!File.Exists(filePath))
            {
                try
                {
                    catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Jet OLEDB:Engine Type=5");
                }
                catch (System.Exception ex)
                {

                }
            }
            ADODB.Connection cn = new ADODB.Connection();
            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath, null, null, -1);
            catalog.ActiveConnection = cn;
            ADOX.Table table = new ADOX.Table();
            table.Name = tableName;
            if (isContainKeyID)
            {
                ADOX.Column column = new ADOX.Column();
                column.ParentCatalog = catalog;
                column.Name = "ID";  //列名称 
                column.Type = DataTypeEnum.adInteger; //列数据类型 
                column.DefinedSize = 9;//大小 
                column.Properties["AutoIncrement"].Value = true; //是否是自动增加属性 
                table.Columns.Append(column, DataTypeEnum.adInteger, 9); //增加第一列 
                table.Keys.Append("TablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
            }

            foreach (var col in colums)
            {
                table.Columns.Append(col.Name,col.Type,col.DefinedSize);
            }

            catalog.Tables.Append(table); //增加当前的表
            cn.Close();
        }

        #endregion

        #region 判断数据库中是否存在指定的表名

        /// <summary>
        /// 判断数据库中是否存在指定的表名
        /// </summary>
        /// <param name="filePath">数据库文件路径</param>
        /// <param name="tableName">数据库表名</param>
        /// <returns></returns>
        public static bool IsExistAccessTable(string filePath,string tableName)
        {
            if (IsExistAccessDb(filePath))
            {
                DataTable dataTable = GetAccessTables(filePath);

                List<string> list = new List<string>();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    list.Add(dataTable.Rows[i]["TABLE_NAME"].ToString());
                }

                if (list.Contains(tableName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        #endregion

        #region 获取数据库中所有表的信息

        /// <summary>
        /// 获取指定数据库的所有的表结构信息
        /// </summary>
        /// <param name="filePath">数据库文件路径</param>
        /// <returns></returns>
        public static DataTable GetAccessTables(string filePath)
        {
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Jet OLEDB:Engine Type=5";

            using (OleDbConnection connection = new
               OleDbConnection(connStr))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }

        #endregion

        #region 调用生成数据库表结构示例

        //========================================================================================调用
        //ADOX.Column[] columns = {
        //                     new ADOX.Column(){Name="id",Type=DataTypeEnum.adInteger,DefinedSize=9},
        //                     new ADOX.Column(){Name="col1",Type=DataTypeEnum.adWChar,DefinedSize=50},
        //                     new ADOX.Column(){Name="col2",Type=DataTypeEnum.adLongVarChar,DefinedSize=50}
        //                 };
        // AccessDbHelper.CreateAccessTable("d:\\111.mdb", "testTable", columns);

        //ADOX.Column[] columns = {
        //                                     new ADOX.Column(){Name="Mile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
        //                                     new ADOX.Column(){Name="Speed",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
        //                                     new ADOX.Column(){Name="OverType",Type=ADOX.DataTypeEnum.adLongVarWChar},
        //                                     new ADOX.Column(){Name="OverValueRms",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
        //                                     new ADOX.Column(){Name="OverValuePeak",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
        //                                     new ADOX.Column(){Name="OverLength",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
        //                                     new ADOX.Column(){Name="OverLevel",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0},
        //                                     new ADOX.Column(){Name="IsValid",Type=ADOX.DataTypeEnum.adInteger,DefinedSize=0},
        //                                     new ADOX.Column(){Name="LineType",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0}
        //                                 };

        #endregion
    }
}

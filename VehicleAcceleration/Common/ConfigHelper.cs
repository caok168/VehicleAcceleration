using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VehicleAcceleration.Common
{
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件连接access数据字符串
        /// </summary>
        /// <param name="appConfigKey">Key值</param>
        /// <returns></returns>
        public static string GetAccessDbConn(string appConfigKey)
        {
            string str = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=";

            string folderPath = System.Windows.Forms.Application.StartupPath;

            string dbName = ConfigurationManager.AppSettings[appConfigKey].ToString();

            string connStr = str + folderPath + "\\" + dbName;

            return connStr;
        }

        /// <summary>
        /// 根据根目录下的文件夹名称路径和数据库名称获取 连接access数据字符串
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static string GetAccessDbConn(string folder, string dbName)
        {
            string str = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=";

            string folderPath = System.Windows.Forms.Application.StartupPath;

            string connStr = str + folderPath + "\\" + dbName;

            if (!String.IsNullOrWhiteSpace(folder))
            {
                connStr = str + folderPath + "\\" + folder + "\\" + dbName;
            }
            
            return connStr;
        }


        /// <summary>
        /// 根据type类型获取链接字符串
        /// </summary>
        /// <param name="type">1</param>
        /// <param name="fileFullPath">文件的全部路径</param>
        /// <returns></returns>
        public static string GetAccessDbConn(int type, string fileFullPath)
        {
            string str = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=";

            string connStr = "";

            if (type == 1)
            {
                connStr = str + fileFullPath;
            }

            return connStr;
        }

    }
}

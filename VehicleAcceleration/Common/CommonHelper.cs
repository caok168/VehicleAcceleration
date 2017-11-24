using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Common
{
    public class CommonHelper
    {
        /// <summary>
        /// 获取要查询的文件的名称（文件名称组成   Data+线路名+日期+NO+序号ID）
        /// </summary>
        /// <returns></returns>
        public static string GetFileName()
        {
            string fileName = "";

            BasicInfoDAL basicDal = new BasicInfoDAL();
            BasicInfo basic = basicDal.GetLatest();

            if (basic != null)
            {
                fileName = "Data" + basic.LineName + basic.RunDate + "NO" + basic.ID + ".mdb";
            }

            return fileName;
        }

        public static string GetFileNameWithOutExtension()
        {
            string fileName = "";

            BasicInfoDAL basicDal = new BasicInfoDAL();
            BasicInfo basic = basicDal.GetLatest();

            if (basic != null)
            {
                fileName = "Data" + basic.LineName + basic.RunDate + "NO" + basic.ID;
            }

            return fileName;
        }
    }
}

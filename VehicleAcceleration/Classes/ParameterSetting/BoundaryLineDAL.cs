using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;
using System.Data;

namespace VehicleAcceleration.Classes
{
    public class BoundaryLineDAL
    {
        public static string connStr = ConfigHelper.GetAccessDbConn("basicDb");

        public BoundaryLine GetModel()
        {
            List<BoundaryLine> list = new List<BoundaryLine>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from BoundaryLine ", connStr, "BoundaryLine");
            list = DataTableToList_BoundaryLine(dt);

            return list.FirstOrDefault();
        }

        public BoundaryLine Get(string lineName,string directionName)
        {
            List<BoundaryLine> list = new List<BoundaryLine>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from BoundaryLine where LINENAME like '" + lineName + "%' and DIRECTIONNAME='" + directionName + "'", connStr, "BoundaryLine");
            list = DataTableToList_BoundaryLine(dt);

            return list.FirstOrDefault();
        }

        public List<BoundaryLine> GetList(string lineName, string directionName)
        {
            List<BoundaryLine> list = new List<BoundaryLine>();
            DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from BoundaryLine where LINENAME like '" + lineName + "%' and DIRECTIONNAME='" + directionName + "'", connStr, "BoundaryLine");
            list = DataTableToList_BoundaryLine(dt);

            return list;
        }

        private List<BoundaryLine> DataTableToList_BoundaryLine(DataTable dt)
        {
            List<BoundaryLine> list = new List<BoundaryLine>();
            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BoundaryLine paramter = new BoundaryLine();

                    if (dt.Rows[i]["UNITCODE"] != null)
                    {
                        paramter.UNITCODE = dt.Rows[i]["UNITCODE"].ToString();
                    }
                    if (dt.Rows[i]["路局"] != null)
                    {
                        paramter.路局 = dt.Rows[i]["路局"].ToString();
                    }
                    if (dt.Rows[i]["LINECODE"] != null)
                    {
                        paramter.LINECODE = dt.Rows[i]["LINECODE"].ToString();
                    }
                    if (dt.Rows[i]["LINENAME"] != null)
                    {
                        paramter.LINENAME = dt.Rows[i]["LINENAME"].ToString();
                    }
                    if (dt.Rows[i]["DIRECTIONID"] != null)
                    {
                        paramter.DIRECTIONID = dt.Rows[i]["DIRECTIONID"].ToString();
                    }
                    if (dt.Rows[i]["DIRECTIONNAME"] != null)
                    {
                        paramter.DIRECTIONNAME = dt.Rows[i]["DIRECTIONNAME"].ToString();
                    }

                    if (dt.Rows[i]["STARTMILE"] != null)
                    {
                        paramter.STARTMILE = Convert.ToDouble(dt.Rows[i]["STARTMILE"]);
                    }
                    if (dt.Rows[i]["ENDMILE"] != null)
                    {
                        paramter.ENDMILE = Convert.ToDouble(dt.Rows[i]["ENDMILE"]);
                    }

                    list.Add(paramter);
                }
            }

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 线路管界类
    /// </summary>
    public class BoundaryLine
    {

        public string UNITCODE { get; set; }

        public string 路局 { get; set; }

        public string LINECODE { get; set; }

        public string LINENAME { get; set; }

        public string DIRECTIONID { get; set; }

        public string DIRECTIONNAME { get; set; }

        public double STARTMILE { get; set; }

        public double ENDMILE { get; set; }
    }
}

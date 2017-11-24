using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class ReplaceWordData
    {
        /// <summary>
        /// 检测日期
        /// </summary>
        public string SurveyDate { get; set; }

        /// <summary>
        /// 检测车型号
        /// </summary>
        public string SurveyVehicleVersion { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 行别
        /// </summary>
        public string WalkType { get; set; }

        /// <summary>
        /// 检测方向
        /// </summary>
        public string SurveyDirection { get; set; }

        /// <summary>
        /// 运行方向
        /// </summary>
        public string RunDirection { get; set; }


        public List<DeviationTable> Records { get; set; }


        public byte[] PointImage { get; set; }
    }
}

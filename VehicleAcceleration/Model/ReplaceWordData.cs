using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 生成Word文档中需要的信息 类
    /// </summary>
    public class ReplaceWordData
    {
        /// <summary>
        /// 检测区间
        /// </summary>
        public string SurveyRegion { get; set; }

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
        /// 线路名称中文名
        /// </summary>
        public string LineNameCn { get; set; }

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

        /// <summary>
        /// 实际检测里程
        /// </summary>
        public string ActualMile { get; set; }

        /// <summary>
        /// 高于200公里/小时以上的里程
        /// </summary>
        public string MileMore200 { get; set; }

        /// <summary>
        /// 检测处理结果
        /// </summary>
        public string SurveyResult { get; set; }

        /// <summary>
        /// 记录人
        /// </summary>
        public string RecordPerson { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        public string CheckPerson { get; set; }


        public int CountA { get; set; }

        public int CountB { get; set; }

        public int CountC { get; set; }


        public string ImageUrl1 { get; set; }

        public string ImageUrl2 { get; set; }

        public string ImageUrl3 { get; set; }
    }
}

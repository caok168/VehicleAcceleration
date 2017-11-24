using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class DeviationTable
    {
        public int ID { get; set; }

        /// <summary>
        /// 局名
        /// </summary>
        public string BureauName { get; set; }

        /// <summary>
        /// 线名
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 里程
        /// </summary>
        public double Miles { get; set; }

        /// <summary>
        /// 轴箱加速度测试内容
        /// </summary>
        public string AccTestContent { get; set; }

        /// <summary>
        /// 有效值/峰值
        /// </summary>
        public double RmsOrPeakValue { get; set; }

        /// <summary>
        /// 轨道冲击指数
        /// </summary>
        public double TrackImpactIndex { get; set; }

        /// <summary>
        /// 偏差等级
        /// </summary>
        public string DeviationGrade { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// 线形
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}

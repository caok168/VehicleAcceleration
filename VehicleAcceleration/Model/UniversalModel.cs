using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    /// <summary>
    /// 通用Model
    /// </summary>
    public class UniversalModel
    {
        /// <summary>
        /// 序号（自动增长列）
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}

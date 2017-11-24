using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Model
{
    public class ThreadParameter
    {
        public BasicInfo basic { get; set; }
        /// <summary>
        /// cit文件的路径
        /// </summary>
        public string filePath { get; set; }

        /// <summary>
        /// db存储文件夹路径
        /// </summary>
        public string folderPath { get; set; }
    }
}

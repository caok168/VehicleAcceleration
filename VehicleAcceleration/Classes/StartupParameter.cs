using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleAcceleration.Classes
{
    public class StartupParameter
    {
        /// <summary>
        /// 获取检测车型号
        /// </summary>
        /// <returns></returns>
        public static List<string> getMeasuringCarVersion()
        {
            List<string> list = new List<string>();


            return list;
        }

        /// <summary>
        /// 获取线路名
        /// </summary>
        /// <returns></returns>
        public static List<string> getLineName()
        {
            List<string> list = new List<string>();


            return list;
        }

        /// <summary>
        /// 获取行别
        /// </summary>
        /// <returns></returns>
        public static List<string> getWalkType()
        {
            List<string> list = new List<string>();
            list.Add("上行");
            list.Add("下行");
            list.Add("单线");

            return list;
        }

        /// <summary>
        /// 获取增减里程类型
        /// </summary>
        /// <returns></returns>
        public static List<string> getMileageType()
        {
            List<string> list = new List<string>();
            list.Add("增里程");
            list.Add("减里程");

            return list;
        }

        /// <summary>
        /// 获取检测方向
        /// </summary>
        /// <returns></returns>
        public static List<string> getSurveyDirection()
        {
            List<string> list = new List<string>();
            //list.Add("1车在前");
            //list.Add("8车在后");

            return list;
        }

        /// <summary>
        /// 获取运行方向
        /// </summary>
        /// <returns></returns>
        public static List<string> getRunDirection()
        {
            List<string> list = new List<string>();
            list.Add("正向运行");
            list.Add("反向运行");

            return list;
        }

    }
}

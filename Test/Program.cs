using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using DataAccess;
using Test.Model;
using System.Data;
using Test.Excel;

namespace Test
{

    class Program
    {
        

        static void Main(string[] args)
        {

            NOPIHelper obj = new NOPIHelper();
            obj.Test();


            //ReadCit();

            //ReadAccess();

            //LogTest();

            //CreateWord();

            //TaskMethod();

            //ParallelMethod();

            //CreateAccess();

            ValidAccess();

            Console.ReadLine();
        }

        static void ValidAccess()
        {
            string filePath = "E:\\Temp\\data.mdb";
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Jet OLEDB:Engine Type=5";

            bool isExist = AccessHelper.IsExistAccessTable(filePath, "WaveData_BodyVertical");
            bool isExist1 = AccessHelper.IsExistAccessTable(filePath, "WaveData_BodyVertical1");

            bool isExist2 = AccessHelper.IsExistAccessTable("123", "WaveData_BodyVertical1");

            //DataTable table = AccessHelper.GetAccessTables(connStr);

            //List<string> list = new List<string>();

            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    DataRow row = table.Rows[i];

            //    list.Add(table.Rows[i]["TABLE_NAME"].ToString());
            //}
        }


        static void CreateAccess()
        {
            string filePath="E:\\Temp\\data.mdb";

            AccessHelper.CreateAccessDb(filePath);


        }

        static void TaskMethod()
        {
            Console.WriteLine(DateTime.Now.ToString());
            Task.Factory.StartNew(()=>{
                Thread.Sleep(1000);
                Console.WriteLine("1=" + DateTime.Now.ToString());
            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("2=" + DateTime.Now.ToString());
            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("3=" + DateTime.Now.ToString());
            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("4=" + DateTime.Now.ToString());
            });

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("5=" + DateTime.Now.ToString());
            });
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(6000);
                Console.WriteLine("6=" + DateTime.Now.ToString());
            });
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("7=" + DateTime.Now.ToString());
            });

            Console.ReadLine();
        }

        static void ParallelMethod()
        {
            Console.WriteLine(DateTime.Now.ToString());
            Parallel.Invoke(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("2=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("3=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("4=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("5=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(6000);
                Console.WriteLine("6=" + DateTime.Now.ToString());
            }, () =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("7=" + DateTime.Now.ToString());
            }
            );

            Console.ReadLine();
        }


        static void CreateWord()
        {
            string tempPath = "E:\\test.doc";
            string targetPath = "E:\\normal.doc";

            string imgFile = "E:\\ck.jpg";


            GenerateWord word = new GenerateWord(tempPath, targetPath);

            ReplaceWordData data = new ReplaceWordData();
            data.SurveyDate = DateTime.Now.ToString();
            List<DeviationTable> records = new List<DeviationTable>();
            records.Add(new DeviationTable { ID = 1, BureauName = "铁路局1", LineName = "线路1" });
            records.Add(new DeviationTable { ID = 2, BureauName = "铁路局2", LineName = "线路2" });
            records.Add(new DeviationTable { ID = 3, BureauName = "铁路局3", LineName = "线路3" });
            records.Add(new DeviationTable { ID = 4, BureauName = "铁路局4", LineName = "线路4" });

            data.Records = records;

            FileStream fs = new FileStream(imgFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            data.PointImage = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
            br.Close();
            fs.Close();

            word.OverWriteWord(data);
        }


        static void ReadAccess()
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=G:\\Temp\\铁科院\\test.mdb";

            System.Data.DataTable dt = DataAccess.AccessHelper.Get_DataTable("select * from person", strConn, "Person");

            //int i = DataAccess.AccessHelper.Run_SQL("", strConn);
        }


        static void ReadCit()
        {
            CitFileProcess.CitFileHelper helper = new CitFileProcess.CitFileHelper();
            string strFile = "G:\\Temp\\GNHS-HANGZHOU-NANJING-14052016-175302-1减变增.cit";

            CitFileProcess.DataHeadInfo header = helper.GetDataInfoHead(strFile);

            List<CitFileProcess.DataChannelInfo> channelInfoList = helper.GetDataChannelInfoHead(strFile);

            //float[] flist = helper.GetSingleChannelDataFloat(strFile, 1);
            //double[] dlist = helper.GetSingleChannelData(strFile, 1);

            //byte[] b = helper.GetExtraInfo(strFile);

            string channelName = helper.GetChannelUnit(3, channelInfoList);
        }

        static void LogTest()
        {
            NLog.Logger log = NLog.LogManager.GetLogger("");
            log.Info("测试");

            log.Error("出错了");

            log.Trace("Trace");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Model;
using CitFileProcess;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using AccelerationOnLine;
using VehicleAcceleration.Common;
using System.Threading;
using DataAccess;
using System.Configuration;

namespace VehicleAcceleration.Forms.SystemMenu
{
    public partial class RealTime : Form
    {
        MainForm main;

        //记录日志
        NLog.Logger logger = NLog.LogManager.GetLogger("");

        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now;

        long position = 0;
        int bytesneed = 0;


        //读取cit文件
        CitFileHelper citHelper = new CitFileHelper();
        BasicInfoDAL basicDAL = new BasicInfoDAL();
        private static CalculaterParamterDAL calcDal = new CalculaterParamterDAL();
        //存储结果的db路径
        string dataDbPath = "";
        int ID = 0;

        BasicInfo basicGlobal;
        string citFilePathGlobal = "";
        string dbFolderPathGlobal = "";

        BinaryReader mbr;
        DataHeadInfo headInfo;

        public RealTime()
        {
            InitializeComponent();

            this.Load += new EventHandler(RealTime_Load);//添加委托--load
        }


        void RealTime_Load(object sender, EventArgs e)
        {
            LoadData();//加载基础数据
            //返回序列中的第一个元素；如果序列中不包含任何元素，则返回默认值。 
            //在使用时，如果返回的是对象， 建议使用FirstOrDefault ， 并对返回的对象进行判空操作
            BasicInfo basic = basicDAL.GetList().FirstOrDefault();

            if (basic != null)
            {
                //this.txt_surveyorName.Text = basic.SurveyorName;
                this.cmb_LineName.SelectedItem = basic.LineName;//线路名
                this.cmb_RunDirection.SelectedItem = basic.RunDirection;//运行方向
                this.cmb_SurveyDirection.SelectedItem = basic.SurveyDirection;//检测方向
                this.cmb_SurveyVehicleVersion.SelectedItem = basic.SurveyVehicleVersion;//检测车型号
                this.cmb_WalkType.SelectedItem = basic.WalkType;//行别
                this.cmb_MileageType.SelectedItem = basic.MileageType;//增减里程
            }

            main = (MainForm)this.Owner;//目地是将值传给定义的main（父窗体）
        }


        #region 按钮事件——确定、取消

        /// <summary>
        /// 确定保存启动参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.txtFolder.Text.Trim() == "")
            {
                MessageBox.Show("请选择要监控的文件夹");
                return;
            }
            BasicInfo basic = new BasicInfo();
            basic.SurveyorName = this.txt_surveyorName.Text.Trim();
            basic.SurveyVehicleVersion = this.cmb_SurveyVehicleVersion.SelectedItem.ToString();
            basic.LineName = this.cmb_LineName.SelectedItem.ToString();
            basic.WalkType = this.cmb_WalkType.SelectedItem.ToString();
            basic.MileageType = this.cmb_MileageType.SelectedItem.ToString();
            basic.OrigialMileage = Convert.ToDouble(this.txt_origialMileage.Text.Trim());
            basic.SurveyDirection = this.cmb_SurveyDirection.SelectedItem.ToString();
            basic.RunDirection = this.cmb_RunDirection.SelectedItem.ToString();

            basic.RunDate = DateTime.Now.ToString("yyyy-MM-dd");//获取现在的时间
            basic.RunTime = "";
            basic.IsComplete = 0;

            //方法用于获得应用程序当前工作目录
            string path = System.Windows.Forms.Application.StartupPath;
            //string filePath = path + "\\CitData_160424063432_CNGX.cit";

            string fileName = "CitData_160821175616_GJHS.cit";
            //从app.config中取值为：CitData_160821175616_GJHS.cit
            fileName = ConfigurationManager.AppSettings["citFileName"];

            string filePath = "";
            //string filePath = path + "\\citFiles\\" + fileName;
            if (this.txtFolder.Text.Trim() == "")//判断监控文件是否为空
            {
                filePath = path + "\\citFiles\\" + fileName;
            }
            else
            {
                filePath = this.txtFolder.Text.Trim() + "\\" + fileName;
            }

            basic.RunDate = DateTime.Now.ToString("yyyy-MM-dd");
            basic.RunTime = DateTime.Now.Hour + "时" + DateTime.Now.Minute + "分" + DateTime.Now.Second + "秒";

            //var dataHeader = citHelper.GetDataInfoHead(filePath);
            //if (dataHeader != null)
            //{
            //    basic.RunDate = dataHeader.sDate.ToString();
            //    basic.RunTime = dataHeader.sTime;
            //}

            //double[] dataMiles = citHelper.GetMilesData(filePath);
            //if (dataMiles != null && dataMiles.Length > 250)
            //{
            //    basic.ActualMile = Math.Abs(dataMiles[100] - dataMiles[dataMiles.Length - 100]);
            //    //Math.Round((wavelist.Where(s => s.StartMile > 200).Count() / wavelist.Count) * Convert.ToDouble(data.ActualMile), 2).ToString();
            //    int count = dataMiles.Where(s => s > 200).Count();
            //    basic.MileMore200 = Math.Round((count / dataMiles.Length) * basic.ActualMile, 2);
            //}
            
            
            string folderPath = path + "\\db\\data\\";

            ID = basicDAL.Add(basic);//用于判断是否增加成功
            //Data+线路名+运行日期+NO+ID
            string dbfileName = "Data" + basic.LineName + basic.RunDate + "NO" + ID + ".mdb";

            string citFolderPath = path + "\\citFiles";
            if (this.txtFolder.Text.Trim() != "")
            { 
                citFolderPath = this.txtFolder.Text.Trim();
            }
            basicGlobal = basic;
            citFilePathGlobal = filePath;
            dbFolderPathGlobal = folderPath;

            main.thread = new Thread(Calculate);//主窗体开启一个线程

            main.fileWatcher = new FileSystemWatcher(citFolderPath, "*.cit");
            main.fileWatcher.EnableRaisingEvents = true;
            main.fileWatcher.Changed += new FileSystemEventHandler(fileWatcher_Changed);
            main.fileWatcher.Renamed += new RenamedEventHandler(fileWatcher_Renamed);
            main.Controls["lbl_Info"].Text = folderPath + dbfileName;

            //main.Controls["Status_Striplbl_info"].Text = folderPath + dbfileName;

            main.StatusStrip_status.Items["Status_Striplbl_info"].Text = folderPath + dbfileName;

            MenuStrip menu = (MenuStrip)main.Controls["MainMenuStrip1"];
            var menuItem = (ToolStripMenuItem)menu.Items["toolStrip_System"];
            menuItem.DropDownItems["toolStrip_RealTime"].Enabled = false;
            menuItem.DropDownItems["toolStrip_Stop"].Enabled = true;

            startTime = DateTime.Now;

            main.startTime = DateTime.Now;
            main.ID = ID;

            logger.Info("开始计算时间:" + startTime);

            CreateDbTable(basic, folderPath);
            this.Close();
        }

        /// <summary>
        /// 退出启动参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region FileWatcher的事件

        void fileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            citFilePathGlobal = e.FullPath;

            main.monitorCitFilePath = citFilePathGlobal;

            if (CheckCitPoints(citFilePathGlobal))
            {
                if (main.thread.ThreadState == ThreadState.Unstarted)
                {
                    main.thread.Start();
                }
                if (main.thread.ThreadState == ThreadState.Suspended || main.thread.ThreadState == ThreadState.Stopped)
                {
                    main.thread = null;
                    main.thread = new Thread(Calculate);
                    main.thread.Start();
                }
                if (main.thread.ThreadState == ThreadState.AbortRequested || main.thread.ThreadState == ThreadState.Aborted)
                {
                    main.thread = null;
                    main.thread = new Thread(Calculate);
                }
            }
        }

        void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            citFilePathGlobal = e.FullPath;

            main.monitorCitFilePath = citFilePathGlobal;

            if (CheckCitPoints(citFilePathGlobal))
            {
                if (main.thread.ThreadState == ThreadState.Unstarted)
                {
                    main.thread.Start();
                }
                if (main.thread.ThreadState == ThreadState.Suspended || main.thread.ThreadState == ThreadState.Stopped)
                {
                    main.thread = null;
                    main.thread = new Thread(Calculate);
                    main.thread.Start();
                }
                if (main.thread.ThreadState == ThreadState.AbortRequested || main.thread.ThreadState == ThreadState.Aborted)
                {
                    main.thread = null;
                    main.thread = new Thread(Calculate);
                }
            }
        }

        #endregion

        /// <summary>
        /// 创建数据存储表结构
        /// </summary>
        /// <param name="basic"></param>
        /// <param name="dbFolderPath">数据库文件文件夹路径</param>
        private void CreateDbTable(BasicInfo basic, string dbFolderPath)
        {
            if (ID != 0)
            {
                //Data+线路名+运行日期+NO+ID
                string fileName = "Data" + basic.LineName + basic.RunDate + "NO" + ID + ".mdb";
                dataDbPath = dbFolderPath + fileName;
                try
                {
                    //初始化存储数据库，并创建相应的表
                    if (AccessHelper.IsExistAccessDb(dataDbPath))//判断是否存在这个表
                    {
                        File.Delete(dataDbPath);
                    }
                    else
                    {
                        logger.Info("开始创建数据库表结构");

                        #region WaveDataColumns

                        ADOX.Column[] waveDataColumns = { 
                                                        new ADOX.Column(){Name="AvgSpeed",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="StartMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="LeftAxisVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="RightAxisVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="RightAxisVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="RightAxisVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="LeftAxisHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="FrameVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="FrameHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="BodyHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="BodyVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0}
                                                        };

                        #endregion

                        //AccessHelper.CreateAccessTable(dataDbPath, "WaveDataResult");
                        AccessHelper.CreateAccessTable(dataDbPath, "WaveDataResult", waveDataColumns);

                        #region OverValueDataColumns

                        ADOX.Column[] columns = {
                                             new ADOX.Column(){Name="Mile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="Speed",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverType",Type=ADOX.DataTypeEnum.adLongVarWChar},
                                             new ADOX.Column(){Name="OverValueRms",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverValuePeak",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverLength",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverLevel",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0},
                                             new ADOX.Column(){Name="IsValid",Type=ADOX.DataTypeEnum.adInteger,DefinedSize=0},
                                             new ADOX.Column(){Name="ChannelName",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0},
                                             new ADOX.Column(){Name="ChannelID",Type=ADOX.DataTypeEnum.adInteger,DefinedSize=0}
                                         };

                        #endregion

                        AccessHelper.CreateAccessTable(dataDbPath, "OverValueDataResult", columns);

                        logger.Info("创建数据库表结构完成");
                    }

                    //读取Cit文件并且进行计算存储
                    //OperateCitFile(paramter.filePath, paramter.basic);
                }
                catch (Exception ex)
                {
                    //basicDAL.Delete(ID);
                    //File.Delete(dataDbPath);
                    DateTime endTime = DateTime.Now;

                    logger.Info("异常结束计算时间:" + endTime);

                    logger.Error(ex);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("基本参数保存失败");
            }
        }

        /// <summary>
        /// 判断点数是否达到点数
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns></returns>
        private bool CheckCitPoints(string citFile)
        {
            if (mbr == null)
            {
                headInfo = citHelper.GetDataInfoHead(citFile);
                List<DataChannelInfo> channelInfoList = citHelper.GetDataChannelInfoHead(citFile);

                FileStream fsRead = new FileStream(citFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                mbr = new BinaryReader(fsRead, Encoding.UTF8);

                var calcParamter = calcDal.GetList().FirstOrDefault();
                if (calcParamter != null)
                {
                    int samplepointnum = calcParamter.SamplingFrequency * calcParamter.ComputingTime;
                    int onepointbyte = headInfo.iChannelNumber * 2;
                    bytesneed = samplepointnum * onepointbyte;
                }
                else
                {
                    int samplepointnum = CommonClass.CalculatePoints;
                    int onepointbyte = headInfo.iChannelNumber * 2;
                    bytesneed = samplepointnum * onepointbyte;
                }

                mbr.ReadBytes(120); // read header
                mbr.ReadBytes(65 * headInfo.iChannelNumber); //read channel definition
                mbr.ReadBytes(BitConverter.ToInt32(mbr.ReadBytes(4), 0)); // read tail

                position = mbr.BaseStream.Position;
            }
            else
            {
                FileStream fsRead = new FileStream(citFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                mbr = new BinaryReader(fsRead, Encoding.UTF8);
                mbr.BaseStream.Position = position;
            }

            if ((mbr.BaseStream.Length - mbr.BaseStream.Position) > bytesneed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Calculate()
        {
            try
            {
                MatlabCalcParamter matlabParamter = MatlabCalcParamterDAL.LoadParameter();

                int samplepointnum = matlabParamter.CalculatePoints;
                int onepointbyte = headInfo.iChannelNumber * 2;
                int bytesneed = samplepointnum * onepointbyte;
                int count = Convert.ToInt32((mbr.BaseStream.Length - mbr.BaseStream.Position) / bytesneed);

                for (int i = 0; i < count; i++)
                {
                    long startpos = mbr.BaseStream.Position;
                    long endpos = mbr.BaseStream.Position + bytesneed;
                    matlabParamter = MatlabCalcParamterDAL.LoadDataForMatlab(mbr, startpos, endpos, matlabParamter, citHelper, basicGlobal);

                    //Matlab进行计算
                    MatlabCalcParamterDAL.MatlabCalculate(matlabParamter, dataDbPath);

                    position += bytesneed;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "正在中止线程")
                {

                }
                else if (ex.Message == "由于代码已经过优化或者本机框架位于调用堆栈之上，无法计算表达式的值。")
                {
                    logger.Error(ex.Message + ex);
                }
                else
                {
                    logger.Error(ex.Message + ex);
                    MessageBox.Show(ex.Message + ex.StackTrace);
                    endTime = DateTime.Now;
                    logger.Info("异常结束计算时间：" + endTime);

                    string runTimeStr = (endTime - startTime).Hours + "时" + (endTime - startTime).Minutes + "分" + (endTime - startTime).Seconds + "秒";

                    logger.Info("用时：" + runTimeStr);

                    basicDAL.UpdateState(ID, 2, runTimeStr);

                    if (main.fileWatcher != null)
                    {
                        main.fileWatcher.EnableRaisingEvents = false;
                        main.fileWatcher = null;
                    }

                    if (main.thread != null)
                    {
                        main.thread.Abort();
                        main.thread = null;
                    }
                }
            }
            main.thread.Abort();
            if (main.thread.IsAlive)
            {
                Thread.Sleep(2000);
            }
        }



        #region 获取并加载 检测车型号、线路名、行别、增减里程、检测方向、运行方向等数据源

        /// <summary>
        /// 加载基础数据
        /// </summary>
        private void LoadData()
        {
            getWalkType();
            getMileageType();
            getRunDirection();
            getSurveyVehicleVersion();
            getLineName();
            getSurveyDirection();

        }

        /// <summary>
        /// 获取行别
        /// </summary>
        private void getWalkType()
        {
            this.cmb_WalkType.Items.Clear();
            List<string> list = basicDAL.getWalkType();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_WalkType.Items.Add(list[i]);
            }

            this.cmb_WalkType.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取增减里程类型
        /// </summary>
        private void getMileageType()
        {
            this.cmb_MileageType.Items.Clear();
            List<string> list = basicDAL.getMileageType();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_MileageType.Items.Add(list[i]);
            }

            this.cmb_MileageType.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取运行方向
        /// </summary>
        private void getRunDirection()
        {
            this.cmb_RunDirection.Items.Clear();
            List<string> list = basicDAL.getRunDirection();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_RunDirection.Items.Add(list[i]);
            }

            this.cmb_RunDirection.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取检测车型号
        /// </summary>
        private void getSurveyVehicleVersion()
        {
            this.cmb_SurveyVehicleVersion.Items.Clear();
            List<string> list = basicDAL.getSurveyVehicleVersion();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_SurveyVehicleVersion.Items.Add(list[i]);
            }

            this.cmb_SurveyVehicleVersion.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取线路名
        /// </summary>
        private void getLineName()
        {
            this.cmb_LineName.Items.Clear();
            List<string> list = basicDAL.getLineName();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_LineName.Items.Add(list[i]);
            }

            this.cmb_LineName.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取检测方向
        /// </summary>
        private void getSurveyDirection()
        {
            this.cmb_SurveyDirection.Items.Clear();
            List<string> list = basicDAL.getSurveyDirection();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_SurveyDirection.Items.Add(list[i]);
            }

            this.cmb_SurveyDirection.SelectedIndex = 0;
        }

        #endregion


        #region 备注为以后使用

        public void StartFunc(BasicInfo basic, string citFilePath, string folderPath)
        {
            ID = basicDAL.Add(basic);
            if (ID != 0)
            {
                MessageBox.Show("开始读取Cit文件");

                //Data+线路名+运行日期+NO+ID
                string fileName = "Data" + basic.LineName + basic.RunDate + "NO" + ID + ".mdb";
                dataDbPath = folderPath + fileName;
                try
                {
                    //初始化存储数据库，并创建相应的表
                    if (AccessHelper.IsExistAccessDb(dataDbPath))
                    {
                        File.Delete(dataDbPath);
                    }
                    else
                    {
                        #region WaveDataColumns

                        ADOX.Column[] waveDataColumns = { 
                                                        new ADOX.Column(){Name="AvgSpeed",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="StartMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="LeftAxisVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="RightAxisVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="RightAxisVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="RightAxisVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="LeftAxisHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="LeftAxisHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="FrameVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="FrameHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="FrameHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="BodyHorizontal_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyHorizontal_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyHorizontal_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},

                                                        new ADOX.Column(){Name="BodyVertical_MaxValueMile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyVertical_RmsValue",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                                        new ADOX.Column(){Name="BodyVertical_PeakIndex",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0}
                                                        };

                        #endregion

                        //AccessHelper.CreateAccessTable(dataDbPath, "WaveDataResult");
                        AccessHelper.CreateAccessTable(dataDbPath, "WaveDataResult", waveDataColumns);

                        #region OverValueDataColumns

                        ADOX.Column[] columns = {
                                             new ADOX.Column(){Name="Mile",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="Speed",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverType",Type=ADOX.DataTypeEnum.adLongVarWChar},
                                             new ADOX.Column(){Name="OverValueRms",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverValuePeak",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverLength",Type=ADOX.DataTypeEnum.adDouble,DefinedSize=0},
                                             new ADOX.Column(){Name="OverLevel",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0},
                                             new ADOX.Column(){Name="IsValid",Type=ADOX.DataTypeEnum.adInteger,DefinedSize=0},
                                             new ADOX.Column(){Name="ChannelName",Type=ADOX.DataTypeEnum.adLongVarWChar,DefinedSize=0},
                                             new ADOX.Column(){Name="ChannelID",Type=ADOX.DataTypeEnum.adInteger,DefinedSize=0}
                                         };

                        #endregion

                        AccessHelper.CreateAccessTable(dataDbPath, "OverValueDataResult", columns);

                    }

                    //读取Cit文件并且进行计算存储
                    //OperateCitFile(citFilePath, basic);
                }
                catch (Exception ex)
                {
                    //basicDAL.Delete(ID);
                    //File.Delete(dataDbPath);
                    DateTime endTime = DateTime.Now;

                    logger.Info("异常结束计算时间:" + endTime);

                    logger.Error(ex);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("基本参数保存失败");
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}

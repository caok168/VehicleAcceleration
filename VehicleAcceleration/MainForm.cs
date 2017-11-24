using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Forms.SystemMenu;
using VehicleAcceleration.Forms.WaveFormProcessing;
using VehicleAcceleration.Forms.SectionStatistics;
using VehicleAcceleration.Forms.ReportPrint;
using System.Configuration;
using System.Threading;
using System.IO;
using CitFileProcess;
using System.Xml;
using System.Diagnostics;

namespace VehicleAcceleration
{
    public partial class MainForm : Form
    {
        public string tipMessage = "当前没有加载文件";
        public string Auxiliarytools = "辅助工具";
        

        //记录日志
        NLog.Logger logger = NLog.LogManager.GetLogger("");
        public Thread thread = null;

        public DateTime startTime;
        public DateTime endTime;
        public int ID;

        public string monitorCitFilePath = "";

        BasicInfoDAL basicDAL = new BasicInfoDAL();

        //读取cit文件
        CitFileHelper citHelper = new CitFileHelper();


        /// <summary>
        /// 监控文件
        /// </summary>
        public FileSystemWatcher fileWatcher;

        public MainForm()
        {
            InitializeComponent();
            DateTime DT = System.DateTime.Now;
            string dt = System.DateTime.Now.ToLongDateString().ToString();
            this.Status_Striplbl_info.Text = tipMessage;
            Status_Striplbl_time.Text ="当前时间是:"+ dt;
            this.lbl_Info.Visible=false;
            //打印设置
            this.toolStrip_PrintSet.Enabled = false;
            //停止处理
            this.toolStrip_Stop.Enabled = false;
            //打印散点图
            this.toolStrip_Print_ScatterDiagram.Enabled = false;
        }

        

        

        #region 系统菜单

        /// <summary>
        /// 实时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_RealTime_Click(object sender, EventArgs e)
        {
            using (RealTime realtime = new RealTime())
            {
                DialogResult dr = realtime.ShowDialog(this);//显示启动设置窗口
                if (dr == DialogResult.OK)
                {

                }
            }
        }

        /// <summary>
        /// 停止处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                endTime = DateTime.Now;
                logger.Info("结束计算时间：" + endTime);

                string runTimeStr = (endTime - startTime).Hours + "时" + (endTime - startTime).Minutes + "分" + (endTime - startTime).Seconds + "秒";

                logger.Info("用时：" + runTimeStr);

                double actualMile = 0.0;
                double mileMore200 = 0.0;

                if (monitorCitFilePath != "")
                {
                    double[] dataMiles = citHelper.GetMilesData(monitorCitFilePath);

                    var channelList = citHelper.GetDataChannelInfoHead(monitorCitFilePath);

                    int channelId = citHelper.GetChannelId("速度",channelList);

                    double[] speedDatas = citHelper.GetSingleChannelData(monitorCitFilePath, channelId);

                    if (dataMiles != null && dataMiles.Length > 250)
                    {
                        actualMile = Math.Abs(dataMiles[100] - dataMiles[dataMiles.Length - 100]);
                    }
                    if (speedDatas != null && speedDatas.Length > 0)
                    {
                        int count = speedDatas.Where(s => s > 200).Count();
                        double resultValue = Convert.ToDouble(count) / Convert.ToDouble(dataMiles.Length) * actualMile;
                        mileMore200 = Math.Round(resultValue, 2);
                    }
                }

                //basicDAL.UpdateState(ID, 1, runTimeStr);
                basicDAL.UpdateState(ID, 1, runTimeStr, actualMile, mileMore200);

                if (fileWatcher != null)
                {
                    fileWatcher.EnableRaisingEvents = false;
                    fileWatcher = null;
                }
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }


                this.toolStrip_Stop.Enabled = false;
                this.toolStrip_RealTime.Enabled = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                if (fileWatcher != null)
                {
                    fileWatcher.EnableRaisingEvents = false;
                    fileWatcher = null;
                }
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }
                this.toolStrip_Stop.Enabled = false;
                this.toolStrip_RealTime.Enabled = true;

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_LoadData_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                MessageBox.Show("当前正在进行实时处理，不能加载数据");
            }
            else
            {
                using (ShowData showData = new ShowData())
                {
                    showData.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 打印设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_PrintSet_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath + "\\db\\data\\" + "DataGJHX2016-10-19NO39.mdb";

            this.panel1.Controls.Clear();
            ScatterDiagram diagram = new ScatterDiagram(filePath);
            diagram.FormBorderStyle = FormBorderStyle.None;
            diagram.TopLevel = false;
            //fm.Parent = ((TabControl)sender).SelectedTab;

            //diagram.Parent=((Panel)sender).
            diagram.ControlBox = false;
            diagram.Dock = DockStyle.Fill;
            diagram.Show();
            this.panel1.Controls.Add(diagram);

            //using (ScatterDiagram diagram = new ScatterDiagram())
            //{
            //    //diagram.Show(this.panel1);
            //}
        }

        /// <summary>
        /// 计算参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_ParamSet_Click(object sender, EventArgs e)
        {
            using (ParameterSet param = new ParameterSet())
            {
                param.ShowDialog();
            }
        }

        #endregion

        #region 波形处理

        private void toolStrip_ScatterDiagram_Click(object sender, EventArgs e)
        {
            if (this.lbl_Info.Text.Trim() != "" && this.lbl_Info.Text.Trim() != tipMessage)
            {
                ScatterDiagram diagram = new ScatterDiagram();
                diagram.Show(this);
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }
        }

        #endregion

        #region 区段统计

        /// <summary>
        /// 区段最大值统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_SectionMaxValue_Click(object sender, EventArgs e)
        {
            if (this.lbl_Info.Text.Trim() != "" && this.lbl_Info.Text.Trim() != tipMessage)
            {
                MaxValueStatictics maxValue = new MaxValueStatictics();
                maxValue.Show(this);
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }
        }

        /// <summary>
        /// 区段超限值统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_SectionOverValue_Click(object sender, EventArgs e)
        {
            if (this.lbl_Info.Text.Trim() != "" && this.lbl_Info.Text.Trim() != tipMessage)
            {
                OverValueStatistics overValue = new OverValueStatistics();
                overValue.Show(this);
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }
        }

        #endregion

        #region 报表打印

        /// <summary>
        /// 散点图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Print_ScatterDiagram_Click(object sender, EventArgs e)
        {
            ScatterDiagramSet diagramSet = new ScatterDiagramSet();
            diagramSet.Show(this);
        }

        /// <summary>
        /// 生成Excel日报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Print_ReportExcel_Click(object sender, EventArgs e)
        {
            using (BuildReportExcel excel = new BuildReportExcel())
            {
                excel.ShowDialog(this);
            }
        }

        /// <summary>
        /// 生成Word日报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Print_ReportWord_Click(object sender, EventArgs e)
        {
            using (BuildReportWord word = new BuildReportWord())
            {
                word.ShowDialog(this);
            }
        }

        #endregion


        #region MainForm事件

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MainForm_Resize(sender, e);
            toolStrip();
        }
        //动态添加数据ToolStripMenuItem
        private void toolStrip() {
            Dictionary<string,string> list = new Dictionary<string,string>();
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(@"config.xml", settings);//读取xml文件
            doc.Load(reader);
            XmlNode xn = doc.SelectSingleNode("additional");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
               // MODEL.BookModel bookModel = new MODEL.BookModel();
                XmlElement xe = (XmlElement)xn1;
                // bookModel.BookISBN = xe.GetAttribute("ISBN").ToString();
                // bookModel.BookType = xe.GetAttribute("Type").ToString();
                // 得到Book节点的所有子节点   
                XmlNodeList xnl0 = xe.ChildNodes;
                int a=xnl0.Count;
                for (int n=0;n<a;n++) {
                   string url= xnl0.Item(n).Attributes["url"].Value;
                    list.Add(xnl0.Item(n).InnerText, url);
                }
               
            }
            reader.Close();
            ToolStripMenuItem myItem = new ToolStripMenuItem();
            myItem.Text = Auxiliarytools;
            foreach (var item in list)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(item.Key);
                mi.Text = item.Key;
                mi.Tag = item.Value;
                mi.Click += new EventHandler(CustomItem_Click);
                myItem.DropDownItems.Add(mi);
            }
            MainMenuStrip1.Items.Insert(MainMenuStrip1.Items.Count-2,myItem);
        }
        //动态添加数据后的点击事件
        private void CustomItem_Click(object sender, EventArgs e)
        {
            Process m_Process = null;
            m_Process = new Process();
            string Suffix = ((ToolStripMenuItem)sender).Tag.ToString().Substring(((ToolStripMenuItem)sender).Tag.ToString().Length-4);
            if (Suffix.Equals(".exe"))
            {
               // MessageBox.Show("程序存在.exe");
                m_Process.StartInfo.FileName = Application.StartupPath + "\\" + ((ToolStripMenuItem)sender).Tag.ToString() ;
            }
            else {
               // MessageBox.Show("程序不存在.exe"+Suffix);
                m_Process.StartInfo.FileName = Application.StartupPath + "\\" + ((ToolStripMenuItem)sender).Tag.ToString() + ".exe";
            }
           // m_Process.StartInfo.FileName = Application.StartupPath +"\\"+ ((ToolStripMenuItem)sender).Tag.ToString() + ".exe";
            if (!System.IO.File.Exists(m_Process.StartInfo.FileName))
            {
                MessageBox.Show("程序不存在");
            }
            else {
                m_Process.Start();
            }
           
        }
       
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.Width < 800 || this.Height < 600)
            {
                this.Width = 800;
                this.Height = 600;
            }
            //初始化4个基本控件的高度
            MainMenuStrip1.Height = CommonClass.CommonControlHeight;

            //软件主菜单
            MainMenuStrip1.Left = 1;
            MainMenuStrip1.Top = 1;
            MainMenuStrip1.Width = this.ClientSize.Width - 2;

            panel1.Height = this.ClientSize.Height - MainMenuStrip1.Height - 2 - 20;
            panel1.Width = this.ClientSize.Width - 2;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                if (MessageBox.Show("正在进行实时计算，确认要关闭窗口吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (fileWatcher != null)
                    {
                        fileWatcher.EnableRaisingEvents = false;
                        fileWatcher = null;
                    }

                    if (thread != null)
                    {
                        thread.Abort();
                        thread = null;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion
        /// <summary>
        /// 选项卡查看下面的---工具事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStrip_Tool_Click(object sender, EventArgs e)
        {
            
            if (ToolStrip_Tool.CheckState == CheckState.Checked) {
                
                toolStrip_tools.Visible = false;
                ToolStrip_Tool.Checked = false;//设置为不选中状态
            } else if (ToolStrip_Tool.CheckState == CheckState.Unchecked) {
                ToolStrip_Tool.Checked = true;//设置为选中状态
                toolStrip_tools.Visible = true;
              
            }
           
        }
        /// <summary>
        ///  选项卡查看下面的---状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStrip_state_Click(object sender, EventArgs e)
        {
            if (ToolStrip_state.CheckState == CheckState.Checked) {
                StatusStrip_status.Visible = false;
                ToolStrip_state.Checked = false;
            } else if (ToolStrip_state.CheckState==CheckState.Unchecked) {
                StatusStrip_status.Visible = true;
                ToolStrip_state.Checked = true;
            }
        }
        //toolstrip重绘。去掉状态栏的边框
        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            //if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            //{
            //    Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width, this.toolStrip1.Height - 2);
            //    e.Graphics.SetClip(rect);
            //}
        }

        private void toolStrip_Examine_Click(object sender, EventArgs e)
        {

        }
    }
}

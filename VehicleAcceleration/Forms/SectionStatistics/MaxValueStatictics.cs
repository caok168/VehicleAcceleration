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
using VehicleAcceleration.Common;
using System.Threading;

namespace VehicleAcceleration.Forms.SectionStatistics
{
    public partial class MaxValueStatictics : Form
    {
        Thread thread = null;
        ThreadStart threadStart = null;

        MainForm main;

        string fileFullPath = "";

        List<WaveDataResult> listAll = new List<WaveDataResult>();

        public MaxValueStatictics()
        {
            InitializeComponent();
        }

        public MaxValueStatictics(string path)
        {
            fileFullPath = path;
        }

        private void MaxValueStatictics_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.Owner;

            InitDataGridView(fileFullPath);

            if (main.Controls["lbl_Info"].Text.Trim() != "")
            {
                fileFullPath = main.Controls["lbl_Info"].Text.Trim();

                if (main.thread != null)
                {
                    threadStart = new ThreadStart(() => { LoadData(fileFullPath, true); });
                    threadStart.BeginInvoke(new AsyncCallback(showCallBack), null);
                    thread = new Thread(threadStart);
                    thread.Start();
                }
                else
                {
                    LoadData(fileFullPath, false);
                    DisplayGrid(listAll);
                }
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }

            

            this.MaxValueStatictics_Resize(sender, e);
        }

        private void InitDataGridView(string fileFullPath)
        {
            CreateColumn();
        }

        private void showCallBack(IAsyncResult ar)
        {
            try
            {
                this.Invoke((EventHandler)(delegate
                {
                    DisplayGrid(listAll);
                }));
            }
            catch (Exception ex)
            {

            }
            Thread.Sleep(15000);

            threadStart.BeginInvoke(new AsyncCallback(showCallBack), null);
        }

        private void LoadData(string fileFullPath,bool isRefresh)
        {
            WaveDataResultDAL dal = new WaveDataResultDAL(fileFullPath);
            List<WaveDataResult> list = new List<WaveDataResult>();
            if (isRefresh)
            {
                list = dal.GetList();
            }
            else
            {
                list = dal.GetList();
            }

            listAll = list;
        }

        private void DisplayGrid(List<WaveDataResult> list)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows.Add(list[i].AvgSpeed, list[i].StartMile,
                    list[i].LeftAxisVertical_MaxValueMile, list[i].LeftAxisVertical_RmsValue, list[i].LeftAxisVertical_PeakIndex,
                    list[i].RightAxisVertical_MaxValueMile, list[i].RightAxisVertical_RmsValue, list[i].RightAxisVertical_PeakIndex,
                    list[i].LeftAxisHorizontal_MaxValueMile, list[i].LeftAxisHorizontal_RmsValue, list[i].LeftAxisHorizontal_PeakIndex,
                    list[i].FrameVertical_MaxValueMile, list[i].FrameVertical_RmsValue, list[i].FrameVertical_PeakIndex,
                    list[i].FrameHorizontal_MaxValueMile, list[i].FrameHorizontal_RmsValue, list[i].FrameHorizontal_PeakIndex,
                    list[i].BodyVertical_MaxValueMile, list[i].BodyVertical_RmsValue, list[i].BodyVertical_PeakIndex,
                    list[i].BodyHorizontal_MaxValueMile, list[i].BodyHorizontal_RmsValue, list[i].BodyHorizontal_PeakIndex);

                dataGridView1.RowHeadersWidth = 75;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadData(fileFullPath,true);
                //while (!backgroundWorker1.CancellationPending)
                //{
                    
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DisplayGrid(listAll);
        }


        #region


        /// <summary>
        /// 创建列
        /// </summary>
        private void CreateColumn()
        {
            dataGridView1.ColumnCount = 23;

            dataGridView1.Columns[0].Name = "平均速度";
            dataGridView1.Columns[1].Name = "开始里程";

            dataGridView1.Columns[2].Name = "里程";
            dataGridView1.Columns[3].Name = "左轴垂-有效值";
            dataGridView1.Columns[4].Name = "轨道冲击指数";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;

            dataGridView1.Columns[5].Name = "里程";
            dataGridView1.Columns[6].Name = "右轴垂-有效值";
            dataGridView1.Columns[7].Name = "轨道冲击指数";
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 120;

            dataGridView1.Columns[8].Name = "里程";
            dataGridView1.Columns[9].Name = "左轴横-有效值";
            dataGridView1.Columns[10].Name = "轨道冲击指数";
            dataGridView1.Columns[9].Width = 120;
            dataGridView1.Columns[10].Width = 120;

            dataGridView1.Columns[11].Name = "里程";
            dataGridView1.Columns[12].Name = "构架垂-幅值";
            dataGridView1.Columns[13].Name = "轨道冲击指数";
            dataGridView1.Columns[12].Width = 120;
            dataGridView1.Columns[13].Width = 120;

            dataGridView1.Columns[14].Name = "里程";
            dataGridView1.Columns[15].Name = "构架横-幅值";
            dataGridView1.Columns[16].Name = "轨道冲击指数";
            dataGridView1.Columns[15].Width = 120;
            dataGridView1.Columns[16].Width = 120;

            dataGridView1.Columns[17].Name = "里程";
            dataGridView1.Columns[18].Name = "车体垂-幅值";
            dataGridView1.Columns[19].Name = "轨道冲击指数";
            dataGridView1.Columns[18].Width = 120;
            dataGridView1.Columns[19].Width = 120;

            dataGridView1.Columns[20].Name = "里程";
            dataGridView1.Columns[21].Name = "车体横-幅值";
            dataGridView1.Columns[22].Name = "轨道冲击指数";
            dataGridView1.Columns[21].Width = 120;
            dataGridView1.Columns[22].Width = 120;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void MaxValueStatictics_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.ClientSize.Height - CommonClass.CommonControlHeight - 2;
            dataGridView1.Width = this.ClientSize.Width - 15;
        }

        #endregion

    }
}

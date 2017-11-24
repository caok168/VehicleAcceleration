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
    public partial class OverValueStatistics : Form
    {
        Thread thread = null;
        ThreadStart threadStart = null;

        MainForm main;

        public static string fileFullPath = "";

        List<OverValueDataResult> listAll = new List<OverValueDataResult>();

        public OverValueStatistics()
        {
            InitializeComponent();
            this.Load += new EventHandler(OverValueStatistics_Load);
        }

        public OverValueStatistics(string filePath)
        {
            InitializeComponent();

            fileFullPath = filePath;

            this.Load += new EventHandler(OverValueStatistics_Load);
        }

        void OverValueStatistics_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.Owner;

            if (main.Controls["lbl_Info"].Text.Trim() != "")
            {
                fileFullPath = main.Controls["lbl_Info"].Text.Trim();
                if (main.thread != null)
                {
                    threadStart = new ThreadStart(() => { LoadData(fileFullPath); });
                    threadStart.BeginInvoke(new AsyncCallback(showCallBack), null);
                    thread = new Thread(threadStart);
                    thread.Start();
                }
                else
                {
                    LoadData(fileFullPath);
                    DisplayGrid(listAll);
                }
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }

            this.OverValueStatistics_Resize(sender, e);
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

        private void LoadData(string fileFullPath)
        {
            OverValueDataResultDAL overValueDal = new OverValueDataResultDAL(fileFullPath);
            List<OverValueDataResult> list = overValueDal.GetListOrder();

            listAll = list;
        }

        private void DisplayGrid(List<OverValueDataResult> list)
        {
            this.dataGridView1.DataSource = list;
        }

        private void OverValueStatistics_Resize(object sender, EventArgs e)
        {
            dataGridView1.Height = this.ClientSize.Height - CommonClass.CommonControlHeight - 2;
            dataGridView1.Width = this.ClientSize.Width - 15;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            int isValid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IsValid"].Value);

            string path = System.Windows.Forms.Application.StartupPath;
            if (String.IsNullOrWhiteSpace(fileFullPath))
            {
                fileFullPath = path + "\\db\\data\\" + CommonHelper.GetFileName();
            }
            OverValueDataResultDAL overValueDal = new OverValueDataResultDAL(fileFullPath);
            bool isOk = overValueDal.Update(id, isValid);
            if (!isOk)
            {
                MessageBox.Show("保存失败");
            }
        }


    }
}

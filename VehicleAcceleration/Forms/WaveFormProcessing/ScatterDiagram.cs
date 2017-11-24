using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;
using System.Threading;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Forms.WaveFormProcessing
{
    public partial class ScatterDiagram : Form
    {
        MainForm main;

        public string fileFullPath = "";
        public string imageFilePath = "";
        public int typeGloble = 0;

        public int typeRealTime = -1;

        Thread thread = null;
        ThreadStart threadStart = null;

        List<Model.WaveDataResult> listAll = new List<Model.WaveDataResult>();

        public ScatterDiagram()
        {
            InitializeComponent();
            this.Load += new EventHandler(ScatterDiagram_Load);
        }

        public ScatterDiagram(string path)
        {
            InitializeComponent();

            fileFullPath = path;

            this.Load += new EventHandler(ScatterDiagram_Load);
        }

        public ScatterDiagram(string path,string imagePath,int type)
        {
            InitializeComponent();

            fileFullPath = path;

            imageFilePath = imagePath;

            typeGloble = type;

            this.Load += new EventHandler(ScatterDiagram_Load);
        }

        void ScatterDiagram_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.Owner;
            if (fileFullPath == "")
            {
                fileFullPath = main.Controls["lbl_Info"].Text.Trim();
            }
            
            if (fileFullPath != "")
            {
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
                    if (imageFilePath != "")
                    {
                        this.pointChart1.Screenshort().Save(imageFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("请先加载数据");
            }
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
            Thread.Sleep(5000);

            threadStart.BeginInvoke(new AsyncCallback(showCallBack), null);
        }

        private void LoadData(string fileFullPath)
        {
            WaveDataResultDAL dataDal = new WaveDataResultDAL(fileFullPath);

            List<WaveDataResult> list = dataDal.GetListCalc();

            listAll = list;
        }

        private void DisplayGrid(List<WaveDataResult> list)
        {
            if (typeRealTime != -1)
            {
                typeGloble = typeRealTime;
            }
            this.pointChart1.SetDataList(list, typeGloble, ref typeRealTime);
        }

        private void ScatterDiagram_Resize(object sender, EventArgs e)
        {
            this.pointChart1.Width = this.Width - 10;
            this.pointChart1.Height = this.Height - 2;
        }
    }
}

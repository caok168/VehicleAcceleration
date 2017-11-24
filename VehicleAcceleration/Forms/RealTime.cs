using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;

namespace VehicleAcceleration.Forms
{
    public partial class RealTime : Form
    {
        public RealTime()
        {
            InitializeComponent();

            this.Load += new EventHandler(RealTime_Load);
        }

        void RealTime_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        #region 获取并加载 检测车型号、线路名、行别、增减里程、检测方向、运行方向等数据源

        private void LoadData()
        {
            getWalkType();
            getMileageType();
            getRunDirection();
        }


        private void getWalkType()
        {
            this.cmb_WalkType.Items.Clear();
            List<string> list = StartupParameter.getWalkType();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_WalkType.Items.Add(list[i]);
            }

            this.cmb_WalkType.SelectedIndex = 0;
        }

        private void getMileageType()
        {
            this.cmb_MileageType.Items.Clear();
            List<string> list = StartupParameter.getMileageType();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_MileageType.Items.Add(list[i]);
            }

            this.cmb_MileageType.SelectedIndex = 0;
        }

        private void getRunDirection()
        {
            this.cmb_RunDirection.Items.Clear();
            List<string> list = StartupParameter.getRunDirection();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmb_RunDirection.Items.Add(list[i]);
            }

            this.cmb_RunDirection.SelectedIndex = 0;
        }

        #endregion

    }
}

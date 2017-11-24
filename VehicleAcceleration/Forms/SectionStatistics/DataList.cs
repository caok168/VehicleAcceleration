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

namespace VehicleAcceleration.Forms.SectionStatistics
{
    public partial class DataList : Form
    {
        BasicInfoDAL basicDal = new BasicInfoDAL();

        public int showType = 0;

        public DataList()
        {
            InitializeComponent();
        }

        public DataList(int type)
        {
            InitializeComponent();
            showType = type;
        }

        private void DataList_Load(object sender, EventArgs e)
        {
            List<BasicInfo> list = basicDal.GetList(false);

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = list;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string lineName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string runDate = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string fileName = "Data" + lineName + runDate + "NO" + ID + ".mdb";
            string filePath = Application.StartupPath + "\\db\\data\\" + fileName;

            this.Close();

            if (showType == 1)
            {
                using (MaxValueStatictics diagram = new MaxValueStatictics(filePath))
                {
                    diagram.FormBorderStyle = FormBorderStyle.None;
                    diagram.TopLevel = false;
                    diagram.ControlBox = false;
                    diagram.Dock = DockStyle.Fill;
                    diagram.Show();

                    this.Owner.Controls["panel1"].Controls.Clear();
                    this.Owner.Controls["panel1"].Controls.Add(diagram);
                }
            }
            else
            {
                using (OverValueStatistics diagram = new OverValueStatistics(filePath))
                {
                    diagram.FormBorderStyle = FormBorderStyle.None;
                    diagram.TopLevel = false;
                    diagram.ControlBox = false;
                    diagram.Dock = DockStyle.Fill;
                    diagram.Show();

                    this.Owner.Controls["panel1"].Controls.Clear();
                    this.Owner.Controls["panel1"].Controls.Add(diagram);
                }
            }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string lineName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string runDate = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string fileName = "Data" + lineName + runDate + "NO" + ID + ".mdb";
                string filePath = Application.StartupPath + "\\db\\data\\" + fileName;

                this.Close();

                if (showType == 1)
                {
                    MaxValueStatictics diagram = new MaxValueStatictics(filePath);

                    diagram.FormBorderStyle = FormBorderStyle.None;
                    diagram.TopLevel = false;
                    diagram.ControlBox = false;
                    diagram.Dock = DockStyle.Fill;
                    diagram.Show();

                    this.Owner.Controls["panel1"].Controls.Clear();
                    this.Owner.Controls["panel1"].Controls.Add(diagram);
                }
                else
                {
                    OverValueStatistics diagram = new OverValueStatistics(filePath);

                    diagram.FormBorderStyle = FormBorderStyle.None;
                    diagram.TopLevel = false;
                    diagram.ControlBox = false;
                    diagram.Dock = DockStyle.Fill;
                    diagram.Show();

                    this.Owner.Controls["panel1"].Controls.Clear();
                    this.Owner.Controls["panel1"].Controls.Add(diagram);
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.RowHeadersWidth = 60;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int j = i + 1;
                dataGridView1.Rows[i].HeaderCell.Value = j.ToString();
            }
        }
        
    }
}

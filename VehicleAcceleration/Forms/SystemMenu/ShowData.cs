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
using VehicleAcceleration.Forms.WaveFormProcessing;
using System.IO;

namespace VehicleAcceleration.Forms.SystemMenu
{
    public partial class ShowData : Form
    {
        MainForm main;

        BasicInfoDAL basicDal = new BasicInfoDAL();

        public ShowData()
        {
            InitializeComponent();
        }

        private void ShowData_Load(object sender, EventArgs e)
        {
            List<BasicInfo> list = basicDal.GetList();

            foreach (var item in list)
            {
                if (item.IsComplete == 0)
                {
                    item.CompleteState = "初始状态";
                }
                else if (item.IsComplete == 1)
                {
                    item.CompleteState = "正常结束";
                }
                else if (item.IsComplete == 2)
                {
                    item.CompleteState = "异常结束";
                }
            }

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = list;

            main = (MainForm)this.Owner;//目地是将值传给定义的main（父窗体）
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string lineName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string runDate = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string fileName = "Data" + lineName + runDate + "NO" + ID + ".mdb";
           // MessageBox.Show(fileName);
            string filePath = Application.StartupPath + "\\db\\data\\" + fileName;

            

            if (File.Exists(filePath))
            {
                this.Owner.Controls["lbl_Info"].Text = filePath;
                main.StatusStrip_status.Items["Status_Striplbl_info"].Text = filePath;
                this.Close();

                ScatterDiagram diagram = new ScatterDiagram(filePath);
                diagram.Show(this.Owner);
            }
            else
            {
                MessageBox.Show("不存在该数据文件" + filePath);
            }
            
            //ScatterDiagram diagram = new ScatterDiagram(filePath);
            //diagram.FormBorderStyle = FormBorderStyle.None;
            //diagram.TopLevel = false;
            //diagram.ControlBox = false;
            //diagram.Dock = DockStyle.Fill;
            //diagram.Show();

            //this.Owner.Controls["panel1"].Controls.Clear();
            //this.Owner.Controls["panel1"].Controls.Add(diagram);

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

                if (File.Exists(filePath))
                {
                    this.Owner.Controls["lbl_Info"].Text = filePath;
                    main.StatusStrip_status.Items["Status_Striplbl_info"].Text = filePath;
                    this.Close();

                    ScatterDiagram diagram = new ScatterDiagram(filePath);
                    diagram.Show(this.Owner);
                }
                else
                {
                    MessageBox.Show("不存在该数据文件" + filePath);
                }

                //diagram.FormBorderStyle = FormBorderStyle.None;
                //diagram.TopLevel = false;
                //diagram.ControlBox = false;
                //diagram.Dock = DockStyle.Fill;
                //diagram.Show();

                //this.Owner.Controls["panel1"].Controls.Clear();
                //this.Owner.Controls["panel1"].Controls.Add(diagram);

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

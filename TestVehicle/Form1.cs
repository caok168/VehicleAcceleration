using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestVehicle.WindowForms;
using TestVehicle.Forms;

namespace TestVehicle
{
    public partial class Form1 : Form
    {
        public Window1 w1;
        public Window2 w2;
        public Window3 w3;

        public FormContent form;

        public Form1()
        {
            InitializeComponent();

            w1 = new Window1();
            w2 = new Window2();
            w3 = new Window3();

            form = new FormContent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w1.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            w2.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            w3.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(w3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(form);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehicleAcceleration
{
    public partial class BootPage : Form
    {
        public BootPage()
        {
            InitializeComponent();
        }
        public static DateTime dt = DateTime.Now; //页面启动时的时间
        private void BootPage_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;//开始启动定时器
            timer1.Interval = 1000;//设置定时器时间为3秒钟
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt);//时间差
            if (ts.Seconds >= 3)//时间差里的秒数
            {
                
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
                timer1.Stop();
                timer1.Enabled = false;
            }
        }
    }
}

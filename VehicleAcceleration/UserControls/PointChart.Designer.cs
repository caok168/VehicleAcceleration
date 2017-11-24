namespace VehicleAcceleration.UserControls
{
    partial class PointChart
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Dundas.Charting.WinControl.Legend legend11 = new Dundas.Charting.WinControl.Legend();
            this.Chart1 = new Dundas.Charting.WinControl.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.轴箱左垂有效值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轴箱右垂有效值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轴箱左横有效值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轴箱左垂轨道冲击指数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轴箱右垂轨道冲击指数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.轴箱左横轨道冲击指数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.构架垂向幅值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.构架横向幅值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.车体垂向幅值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.车体横向幅值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chart1
            // 
            this.Chart1.AlwaysRecreateHotregions = true;
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.Chart1.BackGradientEndColor = System.Drawing.SystemColors.Control;
            this.Chart1.BackGradientType = Dundas.Charting.WinControl.GradientType.TopBottom;
            this.Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend11.Alignment = System.Drawing.StringAlignment.Far;
            legend11.Docking = Dundas.Charting.WinControl.LegendDocking.Top;
            legend11.MaxAutoSize = 100F;
            legend11.Name = "Default";
            legend11.ShadowOffset = 10;
            legend11.TitleSeparator = Dundas.Charting.WinControl.LegendSeparatorType.ThickGradientLine;
            this.Chart1.Legends.Add(legend11);
            this.Chart1.Location = new System.Drawing.Point(0, 0);
            this.Chart1.Name = "Chart1";
            this.Chart1.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            this.Chart1.Size = new System.Drawing.Size(561, 320);
            this.Chart1.TabIndex = 2;
            this.Chart1.UI.Toolbar.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dot;
            this.Chart1.UI.Toolbar.Enabled = true;
            this.Chart1.UI.Toolbar.ShadowOffset = 5;
            this.Chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.轴箱左垂有效值ToolStripMenuItem,
            this.轴箱右垂有效值ToolStripMenuItem,
            this.轴箱左横有效值ToolStripMenuItem,
            this.轴箱左垂轨道冲击指数ToolStripMenuItem,
            this.轴箱右垂轨道冲击指数ToolStripMenuItem,
            this.轴箱左横轨道冲击指数ToolStripMenuItem,
            this.构架垂向幅值ToolStripMenuItem,
            this.构架横向幅值ToolStripMenuItem,
            this.车体垂向幅值ToolStripMenuItem,
            this.车体横向幅值ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 246);
            // 
            // 轴箱左垂有效值ToolStripMenuItem
            // 
            this.轴箱左垂有效值ToolStripMenuItem.Name = "轴箱左垂有效值ToolStripMenuItem";
            this.轴箱左垂有效值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱左垂有效值ToolStripMenuItem.Text = "轴箱左垂有效值";
            this.轴箱左垂有效值ToolStripMenuItem.Click += new System.EventHandler(this.轴箱左垂有效值ToolStripMenuItem_Click);
            // 
            // 轴箱右垂有效值ToolStripMenuItem
            // 
            this.轴箱右垂有效值ToolStripMenuItem.Name = "轴箱右垂有效值ToolStripMenuItem";
            this.轴箱右垂有效值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱右垂有效值ToolStripMenuItem.Text = "轴箱右垂有效值";
            this.轴箱右垂有效值ToolStripMenuItem.Click += new System.EventHandler(this.轴箱右垂有效值ToolStripMenuItem_Click);
            // 
            // 轴箱左横有效值ToolStripMenuItem
            // 
            this.轴箱左横有效值ToolStripMenuItem.Name = "轴箱左横有效值ToolStripMenuItem";
            this.轴箱左横有效值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱左横有效值ToolStripMenuItem.Text = "轴箱左横有效值";
            this.轴箱左横有效值ToolStripMenuItem.Click += new System.EventHandler(this.轴箱左横有效值ToolStripMenuItem_Click);
            // 
            // 轴箱左垂轨道冲击指数ToolStripMenuItem
            // 
            this.轴箱左垂轨道冲击指数ToolStripMenuItem.Name = "轴箱左垂轨道冲击指数ToolStripMenuItem";
            this.轴箱左垂轨道冲击指数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱左垂轨道冲击指数ToolStripMenuItem.Text = "轴箱左垂轨道冲击指数";
            this.轴箱左垂轨道冲击指数ToolStripMenuItem.Click += new System.EventHandler(this.轴箱左垂轨道冲击指数ToolStripMenuItem_Click);
            // 
            // 轴箱右垂轨道冲击指数ToolStripMenuItem
            // 
            this.轴箱右垂轨道冲击指数ToolStripMenuItem.Name = "轴箱右垂轨道冲击指数ToolStripMenuItem";
            this.轴箱右垂轨道冲击指数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱右垂轨道冲击指数ToolStripMenuItem.Text = "轴箱右垂轨道冲击指数";
            this.轴箱右垂轨道冲击指数ToolStripMenuItem.Click += new System.EventHandler(this.轴箱右垂轨道冲击指数ToolStripMenuItem_Click);
            // 
            // 轴箱左横轨道冲击指数ToolStripMenuItem
            // 
            this.轴箱左横轨道冲击指数ToolStripMenuItem.Name = "轴箱左横轨道冲击指数ToolStripMenuItem";
            this.轴箱左横轨道冲击指数ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.轴箱左横轨道冲击指数ToolStripMenuItem.Text = "轴箱左横轨道冲击指数";
            this.轴箱左横轨道冲击指数ToolStripMenuItem.Click += new System.EventHandler(this.轴箱左横轨道冲击指数ToolStripMenuItem_Click);
            // 
            // 构架垂向幅值ToolStripMenuItem
            // 
            this.构架垂向幅值ToolStripMenuItem.Name = "构架垂向幅值ToolStripMenuItem";
            this.构架垂向幅值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.构架垂向幅值ToolStripMenuItem.Text = "构架垂向幅值";
            this.构架垂向幅值ToolStripMenuItem.Click += new System.EventHandler(this.构架垂向幅值ToolStripMenuItem_Click);
            // 
            // 构架横向幅值ToolStripMenuItem
            // 
            this.构架横向幅值ToolStripMenuItem.Name = "构架横向幅值ToolStripMenuItem";
            this.构架横向幅值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.构架横向幅值ToolStripMenuItem.Text = "构架横向幅值";
            this.构架横向幅值ToolStripMenuItem.Click += new System.EventHandler(this.构架横向幅值ToolStripMenuItem_Click);
            // 
            // 车体垂向幅值ToolStripMenuItem
            // 
            this.车体垂向幅值ToolStripMenuItem.Name = "车体垂向幅值ToolStripMenuItem";
            this.车体垂向幅值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.车体垂向幅值ToolStripMenuItem.Text = "车体垂向幅值";
            this.车体垂向幅值ToolStripMenuItem.Click += new System.EventHandler(this.车体垂向幅值ToolStripMenuItem_Click);
            // 
            // 车体横向幅值ToolStripMenuItem
            // 
            this.车体横向幅值ToolStripMenuItem.Name = "车体横向幅值ToolStripMenuItem";
            this.车体横向幅值ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.车体横向幅值ToolStripMenuItem.Text = "车体横向幅值";
            this.车体横向幅值ToolStripMenuItem.Click += new System.EventHandler(this.车体横向幅值ToolStripMenuItem_Click);
            // 
            // PointChart
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PointChart";
            this.Size = new System.Drawing.Size(561, 320);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dundas.Charting.WinControl.Chart Chart1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 轴箱左垂有效值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轴箱右垂有效值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轴箱左横有效值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轴箱左垂轨道冲击指数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轴箱右垂轨道冲击指数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 轴箱左横轨道冲击指数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 构架垂向幅值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 构架横向幅值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 车体垂向幅值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 车体横向幅值ToolStripMenuItem;
    }
}

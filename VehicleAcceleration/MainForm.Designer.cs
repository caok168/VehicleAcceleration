namespace VehicleAcceleration
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbl_Info = new System.Windows.Forms.Label();
            this.toolStrip_System = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_RealTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_LoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_PrintSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_ParamSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_WaveProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_ScatterDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_SectionStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_SectionMaxValue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_SectionOverValue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_ReportPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Print_ScatterDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Print_ReportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Print_ReportWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Examine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_state = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Hlpe = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip_tools = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.StatusStrip_status = new System.Windows.Forms.StatusStrip();
            this.Status_Striplbl_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Striplbl_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip_tools.SuspendLayout();
            this.StatusStrip_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(12, 533);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(0, 12);
            this.lbl_Info.TabIndex = 2;
            // 
            // toolStrip_System
            // 
            this.toolStrip_System.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_RealTime,
            this.toolStrip_Stop,
            this.toolStrip_LoadData,
            this.toolStripSeparator3,
            this.toolStrip_PrintSet,
            this.toolStripSeparator4,
            this.toolStrip_ParamSet});
            this.toolStrip_System.Name = "toolStrip_System";
            this.toolStrip_System.Size = new System.Drawing.Size(59, 20);
            this.toolStrip_System.Text = "系统(&S)";
            // 
            // toolStrip_RealTime
            // 
            this.toolStrip_RealTime.Name = "toolStrip_RealTime";
            this.toolStrip_RealTime.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_RealTime.Text = "实时处理";
            this.toolStrip_RealTime.Click += new System.EventHandler(this.toolStrip_RealTime_Click);
            // 
            // toolStrip_Stop
            // 
            this.toolStrip_Stop.Name = "toolStrip_Stop";
            this.toolStrip_Stop.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_Stop.Text = "停止处理";
            this.toolStrip_Stop.Click += new System.EventHandler(this.toolStrip_Stop_Click);
            // 
            // toolStrip_LoadData
            // 
            this.toolStrip_LoadData.Name = "toolStrip_LoadData";
            this.toolStrip_LoadData.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_LoadData.Text = "加载数据";
            this.toolStrip_LoadData.Click += new System.EventHandler(this.toolStrip_LoadData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStrip_PrintSet
            // 
            this.toolStrip_PrintSet.Name = "toolStrip_PrintSet";
            this.toolStrip_PrintSet.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_PrintSet.Text = "打印设置";
            this.toolStrip_PrintSet.Click += new System.EventHandler(this.toolStrip_PrintSet_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStrip_ParamSet
            // 
            this.toolStrip_ParamSet.Name = "toolStrip_ParamSet";
            this.toolStrip_ParamSet.Size = new System.Drawing.Size(148, 22);
            this.toolStrip_ParamSet.Text = "计算参数设置";
            this.toolStrip_ParamSet.Click += new System.EventHandler(this.toolStrip_ParamSet_Click);
            // 
            // toolStrip_WaveProcess
            // 
            this.toolStrip_WaveProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_ScatterDiagram});
            this.toolStrip_WaveProcess.Name = "toolStrip_WaveProcess";
            this.toolStrip_WaveProcess.Size = new System.Drawing.Size(88, 20);
            this.toolStrip_WaveProcess.Text = "波形处理(&W)";
            // 
            // toolStrip_ScatterDiagram
            // 
            this.toolStrip_ScatterDiagram.Name = "toolStrip_ScatterDiagram";
            this.toolStrip_ScatterDiagram.Size = new System.Drawing.Size(112, 22);
            this.toolStrip_ScatterDiagram.Text = "散点图";
            this.toolStrip_ScatterDiagram.Click += new System.EventHandler(this.toolStrip_ScatterDiagram_Click);
            // 
            // toolStrip_SectionStatistics
            // 
            this.toolStrip_SectionStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_SectionMaxValue,
            this.toolStrip_SectionOverValue});
            this.toolStrip_SectionStatistics.Name = "toolStrip_SectionStatistics";
            this.toolStrip_SectionStatistics.Size = new System.Drawing.Size(84, 20);
            this.toolStrip_SectionStatistics.Text = "区段统计(&A)";
            // 
            // toolStrip_SectionMaxValue
            // 
            this.toolStrip_SectionMaxValue.Name = "toolStrip_SectionMaxValue";
            this.toolStrip_SectionMaxValue.Size = new System.Drawing.Size(160, 22);
            this.toolStrip_SectionMaxValue.Text = "区段最大值统计";
            this.toolStrip_SectionMaxValue.Click += new System.EventHandler(this.toolStrip_SectionMaxValue_Click);
            // 
            // toolStrip_SectionOverValue
            // 
            this.toolStrip_SectionOverValue.Name = "toolStrip_SectionOverValue";
            this.toolStrip_SectionOverValue.Size = new System.Drawing.Size(160, 22);
            this.toolStrip_SectionOverValue.Text = "区段超限值统计";
            this.toolStrip_SectionOverValue.Click += new System.EventHandler(this.toolStrip_SectionOverValue_Click);
            // 
            // toolStrip_ReportPrint
            // 
            this.toolStrip_ReportPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Print_ScatterDiagram,
            this.toolStripSeparator1,
            this.toolStrip_Print_ReportExcel,
            this.toolStrip_Print_ReportWord});
            this.toolStrip_ReportPrint.Name = "toolStrip_ReportPrint";
            this.toolStrip_ReportPrint.Size = new System.Drawing.Size(83, 20);
            this.toolStrip_ReportPrint.Text = "报表打印(&P)";
            // 
            // toolStrip_Print_ScatterDiagram
            // 
            this.toolStrip_Print_ScatterDiagram.Name = "toolStrip_Print_ScatterDiagram";
            this.toolStrip_Print_ScatterDiagram.Size = new System.Drawing.Size(157, 22);
            this.toolStrip_Print_ScatterDiagram.Text = "散点图";
            this.toolStrip_Print_ScatterDiagram.Click += new System.EventHandler(this.toolStrip_Print_ScatterDiagram_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStrip_Print_ReportExcel
            // 
            this.toolStrip_Print_ReportExcel.Name = "toolStrip_Print_ReportExcel";
            this.toolStrip_Print_ReportExcel.Size = new System.Drawing.Size(157, 22);
            this.toolStrip_Print_ReportExcel.Text = "生成日报Excel";
            this.toolStrip_Print_ReportExcel.Click += new System.EventHandler(this.toolStrip_Print_ReportExcel_Click);
            // 
            // toolStrip_Print_ReportWord
            // 
            this.toolStrip_Print_ReportWord.Name = "toolStrip_Print_ReportWord";
            this.toolStrip_Print_ReportWord.Size = new System.Drawing.Size(157, 22);
            this.toolStrip_Print_ReportWord.Text = "生成日报Word";
            this.toolStrip_Print_ReportWord.Click += new System.EventHandler(this.toolStrip_Print_ReportWord_Click);
            // 
            // toolStrip_Examine
            // 
            this.toolStrip_Examine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_Tool,
            this.ToolStrip_state});
            this.toolStrip_Examine.Name = "toolStrip_Examine";
            this.toolStrip_Examine.Size = new System.Drawing.Size(60, 20);
            this.toolStrip_Examine.Text = "查看(&V)";
            this.toolStrip_Examine.Click += new System.EventHandler(this.toolStrip_Examine_Click);
            // 
            // ToolStrip_Tool
            // 
            this.ToolStrip_Tool.Name = "ToolStrip_Tool";
            this.ToolStrip_Tool.Size = new System.Drawing.Size(152, 22);
            this.ToolStrip_Tool.Text = "工具栏(T)";
            this.ToolStrip_Tool.Click += new System.EventHandler(this.ToolStrip_Tool_Click);
            // 
            // ToolStrip_state
            // 
            this.ToolStrip_state.Name = "ToolStrip_state";
            this.ToolStrip_state.Size = new System.Drawing.Size(152, 22);
            this.ToolStrip_state.Text = "状态栏(S)";
            this.ToolStrip_state.Click += new System.EventHandler(this.ToolStrip_state_Click);
            // 
            // toolStrip_Hlpe
            // 
            this.toolStrip_Hlpe.Name = "toolStrip_Hlpe";
            this.toolStrip_Hlpe.Size = new System.Drawing.Size(61, 20);
            this.toolStrip_Hlpe.Text = "帮助(&H)";
            // 
            // MainMenuStrip1
            // 
            this.MainMenuStrip1.AutoSize = false;
            this.MainMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(222)))), ((int)(((byte)(230)))));
            this.MainMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_System,
            this.toolStrip_WaveProcess,
            this.toolStrip_SectionStatistics,
            this.toolStrip_ReportPrint,
            this.toolStrip_Examine,
            this.toolStrip_Hlpe});
            this.MainMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip1.Name = "MainMenuStrip1";
            this.MainMenuStrip1.Size = new System.Drawing.Size(1009, 24);
            this.MainMenuStrip1.TabIndex = 0;
            this.MainMenuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.toolStrip_tools);
            this.panel1.Controls.Add(this.StatusStrip_status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 540);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip_tools
            // 
            this.toolStrip_tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripSeparator5,
            this.toolStripButton5,
            this.toolStripSeparator6,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip_tools.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_tools.Name = "toolStrip_tools";
            this.toolStrip_tools.Size = new System.Drawing.Size(1009, 25);
            this.toolStrip_tools.TabIndex = 0;
            this.toolStrip_tools.Text = "toolStrip1";
            this.toolStrip_tools.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::VehicleAcceleration.Properties.Resources.shishi;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "实时处理";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStrip_RealTime_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::VehicleAcceleration.Properties.Resources.加载;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "加载数据";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStrip_LoadData_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::VehicleAcceleration.Properties.Resources.计算;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "计算参数设置";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStrip_ParamSet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::VehicleAcceleration.Properties.Resources.散点;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "散点图";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStrip_ScatterDiagram_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::VehicleAcceleration.Properties.Resources.统计;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "区段最大值统计";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStrip_SectionMaxValue_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::VehicleAcceleration.Properties.Resources.超限统计;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "区段超限值统计";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStrip_SectionOverValue_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::VehicleAcceleration.Properties.Resources.excel_表;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "生成日志报表Excel";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStrip_Print_ReportExcel_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::VehicleAcceleration.Properties.Resources.word;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "生成日报Word";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStrip_Print_ReportWord_Click);
            // 
            // StatusStrip_status
            // 
            this.StatusStrip_status.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip_status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StatusStrip_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_Striplbl_info,
            this.Status_Striplbl_time});
            this.StatusStrip_status.Location = new System.Drawing.Point(0, 518);
            this.StatusStrip_status.Name = "StatusStrip_status";
            this.StatusStrip_status.Size = new System.Drawing.Size(1009, 22);
            this.StatusStrip_status.TabIndex = 1;
            this.StatusStrip_status.Text = "statusStrip1";
            this.StatusStrip_status.Visible = false;
            this.StatusStrip_status.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip1_Paint);
            // 
            // Status_Striplbl_info
            // 
            this.Status_Striplbl_info.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.Status_Striplbl_info.Name = "Status_Striplbl_info";
            this.Status_Striplbl_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Status_Striplbl_info.Size = new System.Drawing.Size(923, 17);
            this.Status_Striplbl_info.Spring = true;
            this.Status_Striplbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Status_Striplbl_time
            // 
            this.Status_Striplbl_time.Name = "Status_Striplbl_time";
            this.Status_Striplbl_time.Size = new System.Drawing.Size(71, 17);
            this.Status_Striplbl_time.Text = "当前时间是:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 564);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车载加速度";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainMenuStrip1.ResumeLayout(false);
            this.MainMenuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip_tools.ResumeLayout(false);
            this.toolStrip_tools.PerformLayout();
            this.StatusStrip_status.ResumeLayout(false);
            this.StatusStrip_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_System;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_RealTime;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Stop;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_LoadData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_PrintSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_ParamSet;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_WaveProcess;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_ScatterDiagram;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_SectionStatistics;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_SectionMaxValue;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_SectionOverValue;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_ReportPrint;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Print_ScatterDiagram;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Print_ReportExcel;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Print_ReportWord;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Examine;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_Tool;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_state;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Hlpe;
        private System.Windows.Forms.MenuStrip MainMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip_tools;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripStatusLabel Status_Striplbl_info;
        private System.Windows.Forms.ToolStripStatusLabel Status_Striplbl_time;
        public System.Windows.Forms.StatusStrip StatusStrip_status;
    }
}
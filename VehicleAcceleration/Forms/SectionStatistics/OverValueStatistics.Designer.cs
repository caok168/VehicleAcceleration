namespace VehicleAcceleration.Forms.SectionStatistics
{
    partial class OverValueStatistics
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverValueRms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverValuePeak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsValid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.通道ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChannelName,
            this.ID,
            this.Mile,
            this.Speed,
            this.OverType,
            this.OverValueRms,
            this.OverValuePeak,
            this.OverLength,
            this.OverLevel,
            this.IsValid,
            this.通道ID});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(958, 501);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "ChannelName";
            this.ChannelName.HeaderText = "通道名称";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Mile
            // 
            this.Mile.DataPropertyName = "Mile";
            this.Mile.HeaderText = "里程";
            this.Mile.Name = "Mile";
            this.Mile.ReadOnly = true;
            // 
            // Speed
            // 
            this.Speed.DataPropertyName = "Speed";
            this.Speed.HeaderText = "速度";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            // 
            // OverType
            // 
            this.OverType.DataPropertyName = "OverType";
            this.OverType.HeaderText = "超限类型";
            this.OverType.Name = "OverType";
            this.OverType.ReadOnly = true;
            // 
            // OverValueRms
            // 
            this.OverValueRms.DataPropertyName = "OverValueRms";
            this.OverValueRms.HeaderText = "有效值/峰值";
            this.OverValueRms.Name = "OverValueRms";
            this.OverValueRms.ReadOnly = true;
            // 
            // OverValuePeak
            // 
            this.OverValuePeak.DataPropertyName = "OverValuePeak";
            this.OverValuePeak.HeaderText = "轨道冲击指数";
            this.OverValuePeak.Name = "OverValuePeak";
            this.OverValuePeak.ReadOnly = true;
            // 
            // OverLength
            // 
            this.OverLength.DataPropertyName = "OverLength";
            this.OverLength.HeaderText = "超限长度";
            this.OverLength.Name = "OverLength";
            this.OverLength.ReadOnly = true;
            // 
            // OverLevel
            // 
            this.OverLevel.DataPropertyName = "OverLevel";
            this.OverLevel.HeaderText = "偏差等级";
            this.OverLevel.Name = "OverLevel";
            this.OverLevel.ReadOnly = true;
            // 
            // IsValid
            // 
            this.IsValid.DataPropertyName = "IsValid";
            this.IsValid.HeaderText = "是否有效";
            this.IsValid.Name = "IsValid";
            // 
            // 通道ID
            // 
            this.通道ID.DataPropertyName = "ChannelID";
            this.通道ID.HeaderText = "通道ID";
            this.通道ID.Name = "通道ID";
            this.通道ID.Visible = false;
            // 
            // OverValueStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 561);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverValueStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超限值统计";
            this.Resize += new System.EventHandler(this.OverValueStatistics_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverValueRms;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverValuePeak;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 通道ID;
    }
}
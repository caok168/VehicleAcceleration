namespace VehicleAcceleration.Forms.SystemMenu
{
    partial class ShowData
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
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_LineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RunDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompleteState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_LineName,
            this.col_RunDate,
            this.col_RunTime,
            this.CompleteState});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(675, 315);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // col_LineName
            // 
            this.col_LineName.DataPropertyName = "LineName";
            this.col_LineName.HeaderText = "线路编号";
            this.col_LineName.Name = "col_LineName";
            this.col_LineName.ReadOnly = true;
            this.col_LineName.Width = 164;
            // 
            // col_RunDate
            // 
            this.col_RunDate.DataPropertyName = "RunDate";
            this.col_RunDate.HeaderText = "运行日期";
            this.col_RunDate.Name = "col_RunDate";
            this.col_RunDate.ReadOnly = true;
            this.col_RunDate.Width = 120;
            // 
            // col_RunTime
            // 
            this.col_RunTime.DataPropertyName = "RunTime";
            this.col_RunTime.HeaderText = "运行时间";
            this.col_RunTime.Name = "col_RunTime";
            this.col_RunTime.ReadOnly = true;
            this.col_RunTime.Width = 151;
            // 
            // CompleteState
            // 
            this.CompleteState.DataPropertyName = "CompleteState";
            this.CompleteState.HeaderText = "完成状态";
            this.CompleteState.Name = "CompleteState";
            this.CompleteState.ReadOnly = true;
            this.CompleteState.Width = 151;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(227, 344);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确  定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(361, 344);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取  消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ShowData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 390);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加载数据";
            this.Load += new System.EventHandler(this.ShowData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_LineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RunDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RunTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompleteState;
    }
}
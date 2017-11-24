namespace VehicleAcceleration.Forms.ReportPrint
{
    partial class BuildReportWord
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLineName = new System.Windows.Forms.ComboBox();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.cmbSurveyDirection = new System.Windows.Forms.ComboBox();
            this.rtxtResult = new System.Windows.Forms.RichTextBox();
            this.txtRecordPerson = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "记 录 人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "线 路 名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "运行方向";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "检测方向";
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.Location = new System.Drawing.Point(40, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "检测结果处理情况";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "【示例：济南局京沪高铁数据已济南西工务段朱宁】";
            // 
            // cmbLineName
            // 
            this.cmbLineName.FormattingEnabled = true;
            this.cmbLineName.Location = new System.Drawing.Point(141, 55);
            this.cmbLineName.Name = "cmbLineName";
            this.cmbLineName.Size = new System.Drawing.Size(203, 20);
            this.cmbLineName.TabIndex = 7;
            // 
            // cmbDirection
            // 
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(141, 89);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(203, 20);
            this.cmbDirection.TabIndex = 8;
            // 
            // cmbSurveyDirection
            // 
            this.cmbSurveyDirection.FormattingEnabled = true;
            this.cmbSurveyDirection.Location = new System.Drawing.Point(141, 124);
            this.cmbSurveyDirection.Name = "cmbSurveyDirection";
            this.cmbSurveyDirection.Size = new System.Drawing.Size(203, 20);
            this.cmbSurveyDirection.TabIndex = 9;
            // 
            // rtxtResult
            // 
            this.rtxtResult.Location = new System.Drawing.Point(141, 168);
            this.rtxtResult.Name = "rtxtResult";
            this.rtxtResult.Size = new System.Drawing.Size(203, 40);
            this.rtxtResult.TabIndex = 10;
            this.rtxtResult.Text = "";
            // 
            // txtRecordPerson
            // 
            this.txtRecordPerson.Location = new System.Drawing.Point(141, 24);
            this.txtRecordPerson.Name = "txtRecordPerson";
            this.txtRecordPerson.Size = new System.Drawing.Size(203, 21);
            this.txtRecordPerson.TabIndex = 11;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(89, 257);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "确  定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(209, 257);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "取  消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // BuildReportWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 296);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txtRecordPerson);
            this.Controls.Add(this.rtxtResult);
            this.Controls.Add(this.cmbSurveyDirection);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.cmbLineName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildReportWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成日报Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLineName;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.ComboBox cmbSurveyDirection;
        private System.Windows.Forms.RichTextBox rtxtResult;
        private System.Windows.Forms.TextBox txtRecordPerson;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
namespace VehicleAcceleration.Forms.WaveFormProcessing
{
    partial class ScatterDiagram
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
            this.pointChart1 = new VehicleAcceleration.UserControls.PointChart();
            this.SuspendLayout();
            // 
            // pointChart1
            // 
            this.pointChart1.BackColor = System.Drawing.Color.White;
            this.pointChart1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointChart1.Location = new System.Drawing.Point(0, 0);
            this.pointChart1.Name = "pointChart1";
            this.pointChart1.Size = new System.Drawing.Size(1028, 578);
            this.pointChart1.TabIndex = 0;
            // 
            // ScatterDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 578);
            this.Controls.Add(this.pointChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScatterDiagram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "散点图";
            this.Resize += new System.EventHandler(this.ScatterDiagram_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.PointChart pointChart1;
    }
}
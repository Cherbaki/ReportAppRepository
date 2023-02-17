namespace Report
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.RIButton = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(-3, 50);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1480, 791);
            this.MainPanel.TabIndex = 0;
            // 
            // RIButton
            // 
            this.RIButton.Location = new System.Drawing.Point(22, 15);
            this.RIButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RIButton.Name = "RIButton";
            this.RIButton.Size = new System.Drawing.Size(153, 25);
            this.RIButton.TabIndex = 0;
            this.RIButton.Text = "Reporter\'s Information";
            this.RIButton.UseVisualStyleBackColor = true;
            this.RIButton.Click += new System.EventHandler(this.RIButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.Location = new System.Drawing.Point(180, 15);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(153, 25);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 845);
            this.Controls.Add(this.RIButton);
            this.Controls.Add(this.dashboardButton);
            this.Controls.Add(this.MainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private Button RIButton;
        private Button dashboardButton;
        private Pages.reportersInformationControl ReportersInformationControl = new();
        private Pages.MonthsDGV DashboardControl = new();
        public Pages.recordsControl RecordsControl = new();
    }
}
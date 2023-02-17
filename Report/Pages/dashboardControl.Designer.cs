namespace Report.Pages
{
    partial class MonthsDGV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecordsChartPanel = new System.Windows.Forms.Panel();
            this.mothsDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mothsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordsChartPanel
            // 
            this.RecordsChartPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RecordsChartPanel.Location = new System.Drawing.Point(3, 312);
            this.RecordsChartPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RecordsChartPanel.Name = "RecordsChartPanel";
            this.RecordsChartPanel.Size = new System.Drawing.Size(456, 375);
            this.RecordsChartPanel.TabIndex = 0;
            this.RecordsChartPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RecordsChartPanel_Paint);
            // 
            // mothsDGV
            // 
            this.mothsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mothsDGV.Location = new System.Drawing.Point(3, 2);
            this.mothsDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mothsDGV.Name = "mothsDGV";
            this.mothsDGV.RowHeadersWidth = 51;
            this.mothsDGV.Size = new System.Drawing.Size(1381, 306);
            this.mothsDGV.TabIndex = 1;
            this.mothsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mothsDGV_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SPGrigolia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1102, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Items in the moth they created";
            // 
            // MonthsDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mothsDGV);
            this.Controls.Add(this.RecordsChartPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MonthsDGV";
            this.Size = new System.Drawing.Size(1610, 728);
            this.Load += new System.EventHandler(this.MonthsDGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mothsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel RecordsChartPanel;
        private DataGridView mothsDGV;
        private Label label1;
    }
}

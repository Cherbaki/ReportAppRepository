namespace Report.Pages
{
    partial class recordsControl
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
            this.ReportsLB = new System.Windows.Forms.ListBox();
            this.ReportDataTB = new System.Windows.Forms.RichTextBox();
            this.SearchRecordTB = new System.Windows.Forms.TextBox();
            this.SearchRecordSpan = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReportsLB
            // 
            this.ReportsLB.FormattingEnabled = true;
            this.ReportsLB.ItemHeight = 15;
            this.ReportsLB.Location = new System.Drawing.Point(17, 64);
            this.ReportsLB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReportsLB.Name = "ReportsLB";
            this.ReportsLB.Size = new System.Drawing.Size(158, 229);
            this.ReportsLB.TabIndex = 0;
            this.ReportsLB.SelectedIndexChanged += new System.EventHandler(this.ReportsLB_SelectedIndexChanged);
            // 
            // ReportDataTB
            // 
            this.ReportDataTB.Location = new System.Drawing.Point(304, 64);
            this.ReportDataTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReportDataTB.Name = "ReportDataTB";
            this.ReportDataTB.Size = new System.Drawing.Size(582, 367);
            this.ReportDataTB.TabIndex = 1;
            this.ReportDataTB.Text = "";
            // 
            // SearchRecordTB
            // 
            this.SearchRecordTB.Location = new System.Drawing.Point(17, 322);
            this.SearchRecordTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchRecordTB.Name = "SearchRecordTB";
            this.SearchRecordTB.Size = new System.Drawing.Size(158, 23);
            this.SearchRecordTB.TabIndex = 2;
            // 
            // SearchRecordSpan
            // 
            this.SearchRecordSpan.AutoSize = true;
            this.SearchRecordSpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchRecordSpan.ForeColor = System.Drawing.Color.Red;
            this.SearchRecordSpan.Location = new System.Drawing.Point(17, 347);
            this.SearchRecordSpan.Name = "SearchRecordSpan";
            this.SearchRecordSpan.Size = new System.Drawing.Size(116, 15);
            this.SearchRecordSpan.TabIndex = 3;
            this.SearchRecordSpan.Text = "Record is not found";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(179, 320);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(60, 22);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Record By Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select a report";
            // 
            // recordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchRecordSpan);
            this.Controls.Add(this.SearchRecordTB);
            this.Controls.Add(this.ReportDataTB);
            this.Controls.Add(this.ReportsLB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "recordsControl";
            this.Size = new System.Drawing.Size(1009, 476);
            this.Load += new System.EventHandler(this.recordsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox ReportsLB;
        private RichTextBox ReportDataTB;
        private TextBox SearchRecordTB;
        private Label SearchRecordSpan;
        private Button SearchButton;
        private Label label1;
        private Label label2;
    }
}

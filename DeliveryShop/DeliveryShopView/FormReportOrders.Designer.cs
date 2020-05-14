namespace AbstractShopView
{
    partial class FormReportOrders
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
            this.dateTimePickerFirst = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSecond = new System.Windows.Forms.DateTimePicker();
            this.FormReport = new System.Windows.Forms.Button();
            this.FormReportPDF = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // dateTimePickerFirst
            // 
            this.dateTimePickerFirst.Location = new System.Drawing.Point(22, 12);
            this.dateTimePickerFirst.Name = "dateTimePickerFirst";
            this.dateTimePickerFirst.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFirst.TabIndex = 0;
            // 
            // dateTimePickerSecond
            // 
            this.dateTimePickerSecond.Location = new System.Drawing.Point(256, 12);
            this.dateTimePickerSecond.Name = "dateTimePickerSecond";
            this.dateTimePickerSecond.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSecond.TabIndex = 1;
            // 
            // FormReport
            // 
            this.FormReport.Location = new System.Drawing.Point(483, 8);
            this.FormReport.Name = "FormReport";
            this.FormReport.Size = new System.Drawing.Size(91, 23);
            this.FormReport.TabIndex = 2;
            this.FormReport.Text = "Сформировать";
            this.FormReport.UseVisualStyleBackColor = true;
            this.FormReport.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // FormReportPDF
            // 
            this.FormReportPDF.Location = new System.Drawing.Point(647, 8);
            this.FormReportPDF.Name = "FormReportPDF";
            this.FormReportPDF.Size = new System.Drawing.Size(141, 23);
            this.FormReportPDF.TabIndex = 3;
            this.FormReportPDF.Text = "Сформировать в PDF";
            this.FormReportPDF.UseVisualStyleBackColor = true;
            this.FormReportPDF.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AbstractShopView.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(796, 405);
            this.reportViewer1.TabIndex = 3;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.FormReportPDF);
            this.Controls.Add(this.FormReport);
            this.Controls.Add(this.dateTimePickerSecond);
            this.Controls.Add(this.dateTimePickerFirst);
            this.Name = "FormReportOrders";
            this.Text = "FormReportOrders";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerFirst;
        private System.Windows.Forms.DateTimePicker dateTimePickerSecond;
        private System.Windows.Forms.Button FormReport;
        private System.Windows.Forms.Button FormReportPDF;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
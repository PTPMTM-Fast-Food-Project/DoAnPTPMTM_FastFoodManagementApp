namespace GUI
{
    partial class Frm_Report
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fastFoodManagementDBDataSet = new GUI.FastFoodManagementDBDataSet();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDenNgay = new System.Windows.Forms.DateTimePicker();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonWord = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.ordersTableAdapter = new GUI.FastFoodManagementDBDataSetTableAdapters.ordersTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastFoodManagementDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "orders";
            this.ordersBindingSource.DataSource = this.fastFoodManagementDBDataSet;
            // 
            // fastFoodManagementDBDataSet
            // 
            this.fastFoodManagementDBDataSet.DataSetName = "FastFoodManagementDBDataSet";
            this.fastFoodManagementDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(148, 33);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(159, 26);
            this.dateTimePickerTuNgay.TabIndex = 1;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(402, 33);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(159, 26);
            this.dateTimePickerDenNgay.TabIndex = 2;
            // 
            // buttonReport
            // 
            this.buttonReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonReport.Location = new System.Drawing.Point(596, 24);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(115, 49);
            this.buttonReport.TabIndex = 3;
            this.buttonReport.Text = "Thống Kê";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonWord
            // 
            this.buttonWord.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonWord.Location = new System.Drawing.Point(732, 24);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(115, 49);
            this.buttonWord.TabIndex = 4;
            this.buttonWord.Text = "Word";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.Location = new System.Drawing.Point(866, 24);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(115, 49);
            this.buttonExcel.TabIndex = 5;
            this.buttonExcel.Text = "Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến ngày:";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Order";
            reportDataSource1.Value = this.ordersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.Report_Order.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(76, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(905, 540);
            this.reportViewer1.TabIndex = 0;
            // 
            // Frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1103, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.dateTimePickerDenNgay);
            this.Controls.Add(this.dateTimePickerTuNgay);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "Frm_Report";
            this.Text = "Frm_Report";
            this.Load += new System.EventHandler(this.Frm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastFoodManagementDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerTuNgay;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonWord;
        private System.Windows.Forms.Button buttonExcel;
        private FastFoodManagementDBDataSet fastFoodManagementDBDataSet;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private FastFoodManagementDBDataSetTableAdapters.ordersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
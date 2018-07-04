namespace QLKS_Winform
{
    partial class DSDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSDichVu));
            this.DichVuPhongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyKSDataSet = new QLKS_Winform.QuanLyKSDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DichVuPhongTableAdapter = new QLKS_Winform.QuanLyKSDataSetTableAdapters.DichVuPhongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DichVuPhongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DichVuPhongBindingSource
            // 
            this.DichVuPhongBindingSource.DataMember = "DichVuPhong";
            this.DichVuPhongBindingSource.DataSource = this.QuanLyKSDataSet;
            // 
            // QuanLyKSDataSet
            // 
            this.QuanLyKSDataSet.DataSetName = "QuanLyKSDataSet";
            this.QuanLyKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSDichVu";
            reportDataSource1.Value = this.DichVuPhongBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLKS_Winform.DSDichVu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(683, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DichVuPhongTableAdapter
            // 
            this.DichVuPhongTableAdapter.ClearBeforeFill = true;
            // 
            // DSDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSDichVu";
            this.Load += new System.EventHandler(this.DSDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DichVuPhongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DichVuPhongBindingSource;
        private QuanLyKSDataSet QuanLyKSDataSet;
        private QuanLyKSDataSetTableAdapters.DichVuPhongTableAdapter DichVuPhongTableAdapter;
    }
}
namespace QLKS_Winform
{
    partial class DSTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSTaiKhoan));
            this.TaiKhoanNVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyKSDataSet = new QLKS_Winform.QuanLyKSDataSet();
            this.rpvHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TaiKhoanNVTableAdapter = new QLKS_Winform.QuanLyKSDataSetTableAdapters.TaiKhoanNVTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoanNVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TaiKhoanNVBindingSource
            // 
            this.TaiKhoanNVBindingSource.DataMember = "TaiKhoanNV";
            this.TaiKhoanNVBindingSource.DataSource = this.QuanLyKSDataSet;
            // 
            // QuanLyKSDataSet
            // 
            this.QuanLyKSDataSet.DataSetName = "QuanLyKSDataSet";
            this.QuanLyKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpvHoaDon
            // 
            this.rpvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "QLTaiKhoan";
            reportDataSource1.Value = this.TaiKhoanNVBindingSource;
            this.rpvHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvHoaDon.LocalReport.ReportEmbeddedResource = "QLKS_Winform.DSTaiKhoan.rdlc";
            this.rpvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rpvHoaDon.Name = "rpvHoaDon";
            this.rpvHoaDon.ServerReport.BearerToken = null;
            this.rpvHoaDon.Size = new System.Drawing.Size(818, 450);
            this.rpvHoaDon.TabIndex = 0;
            // 
            // TaiKhoanNVTableAdapter
            // 
            this.TaiKhoanNVTableAdapter.ClearBeforeFill = true;
            // 
            // DSTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.rpvHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tài khoản";
            this.Load += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoanNVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvHoaDon;
        private System.Windows.Forms.BindingSource TaiKhoanNVBindingSource;
        private QuanLyKSDataSet QuanLyKSDataSet;
        private QuanLyKSDataSetTableAdapters.TaiKhoanNVTableAdapter TaiKhoanNVTableAdapter;
    }
}
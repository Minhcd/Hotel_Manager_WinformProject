namespace QLKS_Winform
{
    partial class DSPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSPhong));
            this.rpvDSPhong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyKSDataSet = new QLKS_Winform.QuanLyKSDataSet();
            this.PhongKSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PhongKSTableAdapter = new QLKS_Winform.QuanLyKSDataSetTableAdapters.PhongKSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongKSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvDSPhong
            // 
            this.rpvDSPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSPhong";
            reportDataSource1.Value = this.PhongKSBindingSource;
            this.rpvDSPhong.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvDSPhong.LocalReport.ReportEmbeddedResource = "QLKS_Winform.DSPhong.rdlc";
            this.rpvDSPhong.Location = new System.Drawing.Point(0, 0);
            this.rpvDSPhong.Name = "rpvDSPhong";
            this.rpvDSPhong.ServerReport.BearerToken = null;
            this.rpvDSPhong.Size = new System.Drawing.Size(679, 325);
            this.rpvDSPhong.TabIndex = 0;
            // 
            // QuanLyKSDataSet
            // 
            this.QuanLyKSDataSet.DataSetName = "QuanLyKSDataSet";
            this.QuanLyKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PhongKSBindingSource
            // 
            this.PhongKSBindingSource.DataMember = "PhongKS";
            this.PhongKSBindingSource.DataSource = this.QuanLyKSDataSet;
            // 
            // PhongKSTableAdapter
            // 
            this.PhongKSTableAdapter.ClearBeforeFill = true;
            // 
            // DSPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 325);
            this.Controls.Add(this.rpvDSPhong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSPhong";
            this.Load += new System.EventHandler(this.DSPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhongKSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvDSPhong;
        private System.Windows.Forms.BindingSource PhongKSBindingSource;
        private QuanLyKSDataSet QuanLyKSDataSet;
        private QuanLyKSDataSetTableAdapters.PhongKSTableAdapter PhongKSTableAdapter;
    }
}
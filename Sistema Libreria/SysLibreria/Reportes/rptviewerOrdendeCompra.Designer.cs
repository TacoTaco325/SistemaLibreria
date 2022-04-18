namespace SysLibreria.Reportes
{
    partial class rptviewerOrdendeCompra
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.clsOrdenCompraTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.clsOrdenCompraTempBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clsOrdenCompraTempBindingSource
            // 
            this.clsOrdenCompraTempBindingSource.DataSource = typeof(Entidad.clsOrdenCompraTemp);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.clsOrdenCompraTempBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SysLibreria.Reportes.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1261, 680);
            this.reportViewer1.TabIndex = 0;
            // 
            // rptviewerOrdendeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptviewerOrdendeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.rptviewerOrdendeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clsOrdenCompraTempBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource clsOrdenCompraTempBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
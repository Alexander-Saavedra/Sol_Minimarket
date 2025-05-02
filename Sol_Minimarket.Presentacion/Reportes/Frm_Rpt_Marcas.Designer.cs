namespace Sol_Minimarket.Presentacion.Reportes
{
    partial class Frm_Rpt_Marcas
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet_MiniMarket = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarket();
            this.USP_Listado_maBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_Listado_maTableAdapter = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMarketTableAdapters.USP_Listado_maTableAdapter();
            this.uSPListadomaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Txt_p1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_MiniMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_maBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPListadomaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes.Rpt_Marcas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // DataSet_MiniMarket
            // 
            this.DataSet_MiniMarket.DataSetName = "DataSet_MiniMarket";
            this.DataSet_MiniMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_Listado_maBindingSource
            // 
            this.USP_Listado_maBindingSource.DataMember = "USP_Listado_ma";
            this.USP_Listado_maBindingSource.DataSource = this.DataSet_MiniMarket;
            // 
            // USP_Listado_maTableAdapter
            // 
            this.USP_Listado_maTableAdapter.ClearBeforeFill = true;
            // 
            // uSPListadomaBindingSource
            // 
            this.uSPListadomaBindingSource.DataMember = "USP_Listado_ma";
            this.uSPListadomaBindingSource.DataSource = this.DataSet_MiniMarket;
            // 
            // Txt_p1
            // 
            this.Txt_p1.Location = new System.Drawing.Point(12, 56);
            this.Txt_p1.Name = "Txt_p1";
            this.Txt_p1.Size = new System.Drawing.Size(100, 26);
            this.Txt_p1.TabIndex = 2;
            // 
            // Frm_Rpt_Marcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Marcas";
            this.Text = "Frm_Rpt_Marcas";
            this.Load += new System.EventHandler(this.Frm_Rpt_Marcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_MiniMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_Listado_maBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadomaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_Listado_maBindingSource;
        private DataSet_MiniMarket DataSet_MiniMarket;
        private DataSet_MiniMarketTableAdapters.USP_Listado_maTableAdapter USP_Listado_maTableAdapter;
        private System.Windows.Forms.BindingSource uSPListadomaBindingSource;
        public System.Windows.Forms.TextBox Txt_p1;
    }
}
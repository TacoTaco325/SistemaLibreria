using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entidad;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SysLibreria.Reportes
{
    public partial class rptviewerOrdendeCompra : Form
    {
        public List<clsOrdenCompraTemp> datos = new List<clsOrdenCompraTemp>();
        public rptviewerOrdendeCompra()
        {
            InitializeComponent();
        }

        private void rptviewerOrdendeCompra_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
            this.reportViewer1.RefreshReport();
        }
    }
}

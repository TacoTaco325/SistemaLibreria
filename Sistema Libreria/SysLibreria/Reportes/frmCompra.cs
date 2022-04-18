using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria.Reportes
{
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
        }

        public int id;

        private void frmCompra_Load(object sender, EventArgs e)
        {
            ReportedeProveedores rpt = new ReportedeProveedores();
            rpt.SetParameterValue("@id", id);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

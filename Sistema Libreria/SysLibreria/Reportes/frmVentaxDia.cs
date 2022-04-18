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
    public partial class frmVentaxDia : Form
    {
        public frmVentaxDia()
        {
            InitializeComponent();
        }

        public string fecha;

        private void frmVentaxDia_Load(object sender, EventArgs e)
        {
            VentaxFecha rpt = new VentaxFecha();
            rpt.SetParameterValue("@fecha", fecha);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

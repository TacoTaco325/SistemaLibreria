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
    public partial class frmCompraxDia : Form
    {
        public frmCompraxDia()
        {
            InitializeComponent();
        }

        public string fecha;

        private void frmCompraxDia_Load(object sender, EventArgs e)
        {
            CompraxFecha rpt = new CompraxFecha();
            rpt.SetParameterValue("@fecha", fecha);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

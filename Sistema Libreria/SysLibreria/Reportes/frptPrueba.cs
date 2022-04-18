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
    public partial class frptPrueba : Form
    {
        public frptPrueba()
        {
            InitializeComponent();
        }

        private void frptPrueba_Load(object sender, EventArgs e)
        {
            rptPrueba rpt = new rptPrueba();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

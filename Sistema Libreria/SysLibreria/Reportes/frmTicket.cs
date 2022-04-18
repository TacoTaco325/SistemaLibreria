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
    public partial class frmTicket : Form
    {
        public frmTicket()
        {
            InitializeComponent();
        }

        public int id;

        private void frmTicket_Load(object sender, EventArgs e)
        {
            Ticket rpt = new Ticket();
            rpt.SetParameterValue("@id", id);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}

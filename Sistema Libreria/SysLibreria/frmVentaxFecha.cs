using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmVentaxFecha : Form
    {
        string Fecha;

        public frmVentaxFecha()
        {
            InitializeComponent();
        }

        void Abrirpanel(object formhija)
        {
            if (this.pnlPadre.Controls.Count > 0)
            {
                this.pnlPadre.Controls.RemoveAt(0);
            }

            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlPadre.Controls.Add(fh);
            this.pnlPadre.Tag = fh;
            fh.Show();
        }

        private void frmVentaxFecha_Load(object sender, EventArgs e)
        {

        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            Reportes.frmVentaxDia frm = new Reportes.frmVentaxDia();
            Fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            frm.fecha = Fecha;
            Abrirpanel(frm);
        }
    }
}

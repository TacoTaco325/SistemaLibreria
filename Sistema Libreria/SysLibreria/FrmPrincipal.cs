using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Controlador;
using Entidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class FrmPrincipal : Form
    {
        clsUsuarioMgr objUsuMgr = new clsUsuarioMgr();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = "" + clsEmpleado.apellido + ", " + clsEmpleado.nombre + "";
            lblDNI.Text = clsEmpleado.DNI.ToString();
            cargo();
            Abrirpanel(new frmInicio());
        }

        void alerta()
        {
            var alerta = objUsuMgr.AlertaStock();
            if (alerta == true)
            {
                MessageBox.Show("ALERTA ALGUNOS PRODUCTOS TIENEN UN STOCK MENOR A 10");
            }
        }

        void cargo()
        {
            switch (clsEmpleado.idCargo)
            {
                case 1:
                    lblCargo.Text = "ADMINISTRADOR";
                    ptbCargo.Image = Properties.Resources.Admin;
                    alerta();
                    break;
                case 2:
                    lblCargo.Text = "EMPLEADO";
                    ptbCargo.Image = Properties.Resources.Empleado;
                    break;
            }
        }

        void Abrirpanel(object formhija)
        {
            if (this.pnlPadre.Controls.Count>0)
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

        private void btnOrdendeCompra_Click(object sender, EventArgs e)
        {
            if (clsEmpleado.nomcargo=="Administrador")
            {
                Abrirpanel(new frmOdCompra());
            }
            else
            {
                MessageBox.Show("No eres administrador", "Sistema libreria");
            }
            
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmVenta());
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            if (clsEmpleado.nomcargo == "Administrador")
            {
                Abrirpanel(new frmRegistrarCompra());
            }
            else
            {
                MessageBox.Show("No eres administrador", "Sistema libreria");
            }
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmAcceso fra = new FrmAcceso();
            fra.Show();
        }

        int count=0;

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (clsEmpleado.nomcargo == "Administrador")
            {
                Abrirpanel(new frmRegistrarCompra());
                if (count == 0)
                {
                    pnlReportes.Visible = true;
                    count = 1;
                }
                else
                {
                    pnlReportes.Visible = false;
                    count = 0;
                }
            }
            else
            {
                MessageBox.Show("No eres administrador", "Sistema libreria");
            }
            
        }

        private void btnRptCompra_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmCompraxFecha());
            pnlReportes.Visible = false;
        }

        private void btnRptVenta_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmVentaxFecha());
            pnlReportes.Visible = false;
        }

        private void btnLibro_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmLibro());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Abrirpanel(new FrmProveedor());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmInicio());
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Abrirpanel(new frmLibroCat());
        }
    }
}

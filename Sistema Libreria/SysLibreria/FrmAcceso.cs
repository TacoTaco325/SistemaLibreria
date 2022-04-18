using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Entidad;
using Controlador;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class FrmAcceso : Form
    {

        int count;
        int timecount;
        clsUsuarioMgr oUsermgr = null;
        clsUsuario oUsu = null;
        DataTable dtt = null;


        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validar();
        }
        
        void Validar()
        {
            oUsermgr = new clsUsuarioMgr();
            oUsu = new clsUsuario();
            oUsu.usuario = txtUsuario.Text;
            oUsu.cont = txtContraseña.Text;
            var validar = oUsermgr.Validar(oUsu.usuario, oUsu.cont);
            if (validar==true)
            {
                this.Hide();
                FrmSplash f = new FrmSplash();
                f.Show();
            }
            else
            {
                lblError.Visible = true;
                ptbError.Visible = true;
                lblError.Text = "Usuario y/o Contraseña Incorrecta";
                ptbError.Image = Properties.Resources.WarningLabel;
                Limpiar();
                count += 1;
            }
            if (count >= 3)
            {
                lblError.Visible = true;
                ptbError.Visible = true;
                lblError.Text = "Maximo de intentos alcanzado (3)";
                ptbError.Image = Properties.Resources.Errorlabel;
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
                timer1.Start();
            }
        }

        void Limpiar()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnAceptar.PerformClick();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }   
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timecount += 1;
            if (timecount == 100)
            {
                this.Close();
            }
        }

        private void btnNoVer_Click(object sender, EventArgs e)
        {
            btnNoVer.Visible = false;
            btnVer.Visible = true;
            txtContraseña.UseSystemPasswordChar = false;

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            btnVer.Visible = false;
            btnNoVer.Visible = true;
            txtContraseña.UseSystemPasswordChar = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Controlador;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmMortisal : Form
    {
        clsLibroMgr objLibMgr = new clsLibroMgr();
        clsUsuarioMgr objUsuMgr = new clsUsuarioMgr();
        string fecha;
        int count;

        public frmMortisal()
        {
            InitializeComponent();
            Listar();
            fecha = DateTime.Now.ToString();
        }

        private void frmMortisal_Load(object sender, EventArgs e)
        {

        }

        void Listar()
        {
            dgvLibro.DataSource = objLibMgr.ListarCaja();
        }

        void limpiardt()
        {
            if (dgvLibro.RowCount>0)
            {
                pnlSugerencia.Visible = false;
                DataTable dg = (DataTable)dgvLibro.DataSource;
                dg.Clear();
            }
            else
            {
                pnlSugerencia.Visible = true;
            }

        }

        void limpiar()
        {
            txtSugerencia.Clear();
        }

        void Buscar()
        {
            dgvLibro.DataSource = objLibMgr.BuscarLibroCaja(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            ptbMortisal.Image = Properties.Resources.Busqueda;
            limpiardt();
            Buscar();
        }

        private void tmTiempo_Tick(object sender, EventArgs e)
        {
            count += 1;

            if (count == 100)
            {
                ptbMortisal.Image = Properties.Resources.LectorLoad;
                limpiar();
                label1.Visible = false;
            }

        }

        private void btnSugerencia_Click(object sender, EventArgs e)
        {
            count = 0;
            objUsuMgr.NuevaSugerencia(txtSugerencia.Text, fecha);
            ptbMortisal.Image = Properties.Resources.Enviado;
            tmTiempo.Start();
            pnlSugerencia.Visible = false;
            label1.Visible = true;
            label1.Text = "Gracias por su sugerencia";
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "BUSCAR")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.LightGray;
            }
        }

        private void txtSugerencia_Enter(object sender, EventArgs e)
        {
            if (txtSugerencia.Text == "ESCRIBA AQUI SU SUGERENCIA")
            {
                txtSugerencia.Text = "";
                txtSugerencia.ForeColor = Color.LightGray;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmAcceso frm = new FrmAcceso();
            frm.Show();   
        }


    }
}

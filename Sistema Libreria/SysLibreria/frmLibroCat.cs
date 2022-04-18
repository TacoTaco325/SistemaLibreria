using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Entidad;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmLibroCat : Form
    {
        clsCategoriaMgr objCatMgr = new clsCategoriaMgr();
        clsCategoria objCat = new clsCategoria();

        public frmLibroCat()
        {
            InitializeComponent();
            txtID.Enabled = false;
            Listar();
        }

        private void frmLibroCat_Load(object sender, EventArgs e)
        {

        }

        void llenarcampos()
        {
            txtID.Text= (string)dgvCategoria.Rows[dgvCategoria.CurrentRow.Index].Cells[0].Value.ToString();
            txtNombre.Text = (string)dgvCategoria.Rows[dgvCategoria.CurrentRow.Index].Cells[1].Value;
            chkEstado.Checked = (bool)dgvCategoria.Rows[dgvCategoria.CurrentRow.Index].Cells[2].Value;
        }

        void Listar()
        {
            dgvCategoria.DataSource = objCatMgr.Listar();
        }

        void limpiardt()
        {
            DataTable dt = (DataTable)dgvCategoria.DataSource;
            dt.Clear();
        }

        void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            chkEstado.Checked = false;
        }

        void Nuevo()
        {
            objCatMgr.NuevoCat(txtNombre.Text, chkEstado.Checked);
        }

        void Modificar()
        {
            objCatMgr.ModificarCat(Convert.ToInt32(txtID.Text), txtNombre.Text.ToString(), chkEstado.Checked);
        }

        void Eliminar()
        {
            objCatMgr.Eliminar(Convert.ToInt32(txtID.Text));
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarcampos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Nuevo();
            limpiardt();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Modificar();
            limpiardt();
            Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            limpiardt();
            Listar();
        }
    }
}

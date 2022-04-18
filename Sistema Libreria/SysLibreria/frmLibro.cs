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
    public partial class frmLibro : Form
    {
        clsLibro objlibro = new clsLibro();
        clsLibroMgr objlibromanager = new clsLibroMgr();
        int filaactual;
        int op;

        public frmLibro()
        {
            InitializeComponent();
            listar(); 
        }

        private void frmLibro_Load(object sender, EventArgs e)
        {

        }

        #region Voids
        void listar()
        {
            dgvLibro.DataSource = objlibromanager.ListarLiCaAu();
        }

        void EnviarDatos()
        {
            filaactual = dgvLibro.CurrentCell.RowIndex;
            objlibro.idlibro = (int)dgvLibro.Rows[filaactual].Cells[0].Value;
        }

        void limpiardt()
        {
            if (dgvLibro.RowCount > 0)
            {
                DataTable dg = (DataTable)dgvLibro.DataSource;
                dg.Clear();
            }
        }

        void Eliminar()
        {
            objlibro.idlibro = (int)dgvLibro.CurrentRow.Cells["ID"].Value;
            objlibromanager.Eliminar(objlibro.idlibro);
        }

        void BuscarLibro()
        {
            objlibro.NomLibro = txtBuscar.Text;
            dgvLibro.DataSource = objlibromanager.BuscarLibro(objlibro.NomLibro);
        }

        #endregion


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            limpiardt();
            BuscarLibro();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            limpiardt();
            listar();
        }

        private void dgvLibro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvLibro.Columns[e.ColumnIndex].Name=="Stock")
            {
                if (Convert.ToInt32(e.Value) <= 10)
                {
                    e.CellStyle.BackColor = Color.Red;

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            op = 1;
            objlibro.operacion = op;
            FrmLibrosDatos frm = new FrmLibrosDatos(objlibro);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            op = 2;
            objlibro.operacion = op;
            EnviarDatos();
            FrmLibrosDatos frm = new FrmLibrosDatos(objlibro);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Eliminar();
            limpiardt();
            listar();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "BUSCAR")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.LightGray;
            }
        }
    }
}

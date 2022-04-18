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
    public partial class FrmProveedor : Form
    {
        clsProveedorMgr objProMgr = new clsProveedorMgr();
        clsProveedor objProv = new clsProveedor();
        int filaactual;
        int op = 1;


        public FrmProveedor()
        {
            InitializeComponent();
            Listar();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            
        }

        void EnviarDatos()
        {
            filaactual = dgvProveedor.CurrentCell.RowIndex;
            objProv.idpro = (int)dgvProveedor.Rows[filaactual].Cells[0].Value;
            objProv.nomEmp = (String)dgvProveedor.Rows[filaactual].Cells[1].Value;
            objProv.Correo = (String)dgvProveedor.Rows[filaactual].Cells[2].Value;
            objProv.Contacto = (String)dgvProveedor.Rows[filaactual].Cells[3].Value;
            objProv.Ciudad = (String)dgvProveedor.Rows[filaactual].Cells[4].Value;
            objProv.Direccion = (String)dgvProveedor.Rows[filaactual].Cells[5].Value;
            objProv.telefono=(int)dgvProveedor.Rows[filaactual].Cells[6].Value;
            objProv.Porcentaje = (double)dgvProveedor.Rows[filaactual].Cells[7].Value;
            objProv.Estado = (bool)dgvProveedor.Rows[filaactual].Cells[8].Value;
        }

        void Listar()
        {
            dgvProveedor.DataSource = objProMgr.ListarProv();
        }
        
        void limpiardt()
        {
            if (dgvProveedor.RowCount > 0)
            {
                DataTable dg = (DataTable)dgvProveedor.DataSource;
                dg.Clear();
            }
        }

        void Buscar()
        {
            objProv.nomEmp = txtBuscar.Text;
            dgvProveedor.DataSource = objProMgr.Buscar(objProv.nomEmp);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            limpiardt();
            Buscar();
        }
        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            limpiardt();
            Listar();
        }

        void Eliminar()
        {
            int id = int.Parse(dgvProveedor.Rows[dgvProveedor.CurrentRow.Index].Cells[0].Value.ToString());
            objProMgr.EliminarProv(id);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            op = 1;
            objProv.operacion = op;
            FrmProveedorDatos frm = new FrmProveedorDatos(objProv);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Eliminar();
            limpiardt();
            Listar();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "BUSCAR")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.LightGray;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            op = 2;
            objProv.operacion = op;
            EnviarDatos();
            FrmProveedorDatos frm = new FrmProveedorDatos(objProv);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }
    }
}

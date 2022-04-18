using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Controlador;
using Entidad;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmRegistrarCompra : Form
    {
        clsLibroMgr objLibMgr = new clsLibroMgr();
        clsLibro objLib = new clsLibro();
        clsProveedorMgr objProvMgr = new clsProveedorMgr();
        clsUsuarioMgr objUsuMgr = new clsUsuarioMgr();
        int op;
        int filaactual;
        int Conteo;


        public frmRegistrarCompra()
        {
            InitializeComponent();
            Listar();
            llenarCombo();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LimpiarDt();
            Buscar();
        }

        private void frmRegistrarCompra_Load(object sender, EventArgs e)
        {
            tmHora.Start();
        }

        void llenarCombo()
        {
            cboProveedor.DataSource = objProvMgr.ListarProv();
            cboProveedor.DisplayMember = "NombreEmpresa";
            cboProveedor.ValueMember = "idPro";
        }

        void Listar()
        {
            dgvLibros.DataSource = objLibMgr.ListarCaja();
        }

        void LimpiarDt()
        {
            if (dgvLibros.RowCount>0)
            {
                DataTable dg = (DataTable)dgvLibros.DataSource;
                dg.Clear();
            }
            
        }

        void Buscar()
        {
            dgvLibros.DataSource = objLibMgr.BuscarLibroCaja(txtBuscar.Text);
        }

        void LLenarCampos()
        {
            filaactual = dgvLibros.CurrentCell.RowIndex;
            lblID.Text = dgvLibros.Rows[filaactual].Cells[0].Value.ToString();
            lblNombre.Text = dgvLibros.Rows[filaactual].Cells[1].Value.ToString();
            lblPrecio.Text = dgvLibros.Rows[filaactual].Cells[2].Value.ToString();
        }

        string[,] ListaVenta = new string[200, 6];
        int Fila = 0;

        void Agregar()
        {
            if (lblID.Text != "" && txtCantidad.Text != "")
            {
                ListaVenta[Fila, 0] = lblID.Text;
                ListaVenta[Fila, 1] = lblNombre.Text;
                ListaVenta[Fila, 2] = lblPrecio.Text;
                ListaVenta[Fila, 3] = txtCantidad.Text;
                ListaVenta[Fila, 4] = (float.Parse(lblPrecio.Text) * int.Parse(txtCantidad.Text)).ToString();

                dgvNotaCompra.Rows.Add(ListaVenta[Fila, 0], ListaVenta[Fila, 1], ListaVenta[Fila, 2], ListaVenta[Fila, 3], ListaVenta[Fila, 4]);

                Fila++;

                lblNombre.Text = lblPrecio.Text = "...";
                lblID.Text = txtCantidad.Text = "";
                Total();
            }
            else
            {
                
            }
        }

        void Total()
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in dgvNotaCompra.Rows)
            {
                suma += Convert.ToDecimal(row.Cells[4].Value);
            }
            lblCosto.Text = suma.ToString();
        }

        void Comprar()
        {
            Conteo = dgvNotaCompra.RowCount;
            lblHora.Text = Conteo.ToString();
            if (Conteo != 0)
            {
                clsCompra.idPro = Convert.ToInt32(cboProveedor.SelectedValue);
                clsCompra.Costo = float.Parse(lblCosto.Text);
                clsCompra.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                clsCompra.Hora = DateTime.Now.ToString("HH:mm:ss");
                clsCompra.idEmp = clsEmpleado.idEmp;
                objUsuMgr.EjecutaQuery("RC");


                DataTable d = new DataTable();
                d = objUsuMgr.EjecutaQueryID("IDC");
                lblHora.Text = d.Rows[0][0].ToString();
                clsDetalleCompra.idCompra = int.Parse(d.Rows[0][0].ToString());


                for (int i = 0; i < Conteo; i++)
                {
                    clsDetalleCompra.idLibro = int.Parse(dgvNotaCompra.Rows[i].Cells[0].Value.ToString());
                    clsDetalleCompra.PrecioUni = float.Parse(dgvNotaCompra.Rows[i].Cells[2].Value.ToString());
                    clsDetalleCompra.Cantidad = int.Parse(dgvNotaCompra.Rows[i].Cells[3].Value.ToString());
                    clsDetalleCompra.Costo = float.Parse(dgvNotaCompra.Rows[i].Cells[4].Value.ToString());
                    objUsuMgr.EjecutaQuery("ASC");
                    objUsuMgr.EjecutaQuery("RDC");
                }
            }
        }

        void LimpiarFila()
        {
            dgvNotaCompra.Rows.RemoveAt(dgvNotaCompra.CurrentRow.Index);
            lblCosto.Text = "0";
            Total();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LimpiarDt();
            Listar();
        }

        void Limpiar_Detalles()
        {
            dgvNotaCompra.Rows.Clear();
            txtCantidad.Text = "";
            lblCosto.Text = "0";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LLenarCampos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Reportes.frmCompra frm = new Reportes.frmCompra();
            Comprar();
            MessageBox.Show("Compra Registrada Correctamente - Factura Generada Correctamente...", "Libreria Quijote");
            int id = clsDetalleCompra.idCompra;
            frm.id = id;
            frm.Show();
        }

        private void btnNuevoLibro_Click(object sender, EventArgs e)
        {
            op = 3;
            objLib.operacion = op;
            FrmLibrosDatos frm = new FrmLibrosDatos(objLib);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                label1.Visible = true;
                pictureBox1.Visible = true;
            }
            else
            {
                Agregar();
                label1.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LimpiarFila();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar_Detalles();
        }

        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                pictureBox1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
                label1.Visible = false;
            }
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

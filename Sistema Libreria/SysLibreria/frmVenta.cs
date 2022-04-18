using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Controlador;
using Entidad;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmVenta : Form
    {
        clsLibroMgr objLibroMgr = new clsLibroMgr();
        clsUsuarioMgr objUsuMgr = new clsUsuarioMgr();
        int filaactual;
        int Conteo;
        String Pago;
        String Tipo;


        public frmVenta()
        {
            InitializeComponent();
            Listar();
            Tipo ="Boleta";
            Pago = "Efectivo";
        }

        void Listar()
        {
            dgvLibros.DataSource = objLibroMgr.ListarCaja();
        }

        void Limpiardt()
        {
            if (dgvLibros.RowCount>0)
            {
                DataTable dt = (DataTable)dgvLibros.DataSource;
                dt.Clear();
            }
            
        }

        void Buscar()
        {
            dgvLibros.DataSource = objLibroMgr.BuscarLibroCaja(txtBuscar.Text);
        }

        void LLenarCampos()
        {
            filaactual = dgvLibros.CurrentCell.RowIndex;
            lblID.Text= dgvLibros.Rows[filaactual].Cells[0].Value.ToString();
            lblNombre.Text = dgvLibros.Rows[filaactual].Cells[1].Value.ToString();
            lblPrecio.Text = dgvLibros.Rows[filaactual].Cells[2].Value.ToString();
        }

        string[,] ListaVenta = new string[200, 6];
        int Fila = 0;

        void Agregar()
        {
            try
            {
                if (lblID.Text != "" && txtCantidad.Text != "")
                {
                    ListaVenta[Fila, 0] = lblID.Text;
                    ListaVenta[Fila, 1] = lblNombre.Text;
                    ListaVenta[Fila, 2] = lblPrecio.Text;
                    ListaVenta[Fila, 3] = txtCantidad.Text;
                    ListaVenta[Fila, 4] = (float.Parse(lblPrecio.Text) * int.Parse(txtCantidad.Text)).ToString();

                    dgvNotadePedido.Rows.Add(ListaVenta[Fila, 0], ListaVenta[Fila, 1], ListaVenta[Fila, 2], ListaVenta[Fila, 3], ListaVenta[Fila, 4]);

                    Fila++;

                    lblNombre.Text = lblPrecio.Text = "...";
                    lblID.Text = txtCantidad.Text = "";


                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            CostoPagar();
        }

        void CostoPagar()
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in dgvNotadePedido.Rows)
            {
                suma += Convert.ToDecimal(row.Cells[4].Value);
            }
            lblCostoApagar.Text = suma.ToString();
        }

        void LimpiarFila()
        {
            if (dgvNotadePedido.RowCount > 0)
            {
                dgvNotadePedido.Rows.RemoveAt(dgvNotadePedido.CurrentRow.Index);
                lblCostoApagar.Text = "0";
                CostoPagar();
            }
        }

        void Limpiar_Detalles()
        {
            dgvNotadePedido.Rows.Clear();
            txtCliente.Text = "";
            txtEfectivo.Text = "0";
            lblCostoApagar.Text = "0";
            lbldevolucion.Text = "0";
            rbnBoleta.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Limpiardt();
            Buscar();
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LLenarCampos();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbldevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblCostoApagar.Text)).ToString();
            }
            catch
            {

                lbldevolucion.Text = "0";
            }
        }

        void TipoBoleta()
        {
            if (Tipo == "Factura")
            {
                Reportes.frmFactura frm = new Reportes.frmFactura();
                Vender();
                MessageBox.Show("Venta Registrada Correctamente - Facturada Generada Correctamente...", "Sistema Caja");
                DataTable d = new DataTable();
                d = objUsuMgr.EjecutaQueryID("IDB");
                int id = int.Parse(d.Rows[0][0].ToString());
                frm.id = id;
                frm.Show();
            }
            else
            {
                Reportes.frmTicket frm = new Reportes.frmTicket();
                Vender();
                MessageBox.Show("Venta Registrada Correctamente - Ticket Generado Correctamente...", "Libreria Quijote");
                DataTable d = new DataTable();
                d = objUsuMgr.EjecutaQueryID("IDB");
                int id = int.Parse(d.Rows[0][0].ToString());
                frm.id = id;
                frm.Show();
            }
        }

        void Vender()
        {
            Conteo = dgvNotadePedido.RowCount;
            if (Conteo != 0)
            {
                clsBoleta.idEmp = clsEmpleado.idEmp;
                clsBoleta.devolucion = float.Parse(lbldevolucion.Text);
                clsBoleta.Efectivo = float.Parse(txtEfectivo.Text);
                clsBoleta.pago = Pago;
                clsBoleta.tipo = Tipo;
                clsBoleta.cliente = txtCliente.Text;
                clsBoleta.fecha = DateTime.Now.ToString("yyyy-MM-dd");
                clsBoleta.Hora = DateTime.Now.ToString("HH:mm:ss");
                clsBoleta.Costo = float.Parse(lblCostoApagar.Text);
                objUsuMgr.EjecutaQuery("RV");

                DataTable d = new DataTable();
                d = objUsuMgr.EjecutaQueryID("IDB");
                clsDetalleBoleta.idBoleta = int.Parse(d.Rows[0][0].ToString());


                for (int i = 0; i < Conteo; i++)
                {
                    clsDetalleBoleta.idLibro = int.Parse(dgvNotadePedido.Rows[i].Cells[0].Value.ToString()); ;
                    clsDetalleBoleta.precioUni = float.Parse(dgvNotadePedido.Rows[i].Cells[2].Value.ToString());
                    clsDetalleBoleta.Cantidad = int.Parse(dgvNotadePedido.Rows[i].Cells[3].Value.ToString());
                    clsDetalleBoleta.Costo = float.Parse(dgvNotadePedido.Rows[i].Cells[4].Value.ToString());
                    objUsuMgr.EjecutaQuery("ASV");
                    objUsuMgr.EjecutaQuery("RDV");
                }
                Limpiar_Detalles();
                Limpiardt();
                Listar();
            }
        }


        private void rbnFactura_CheckedChanged(object sender, EventArgs e)
        {
            Tipo = "Factura";
        }

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            Tipo = "Boleta";
        }

        private void rbnEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            Pago = "Efectivo";
            txtEfectivo.Enabled = true;
        }

        private void rbnTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            Pago = "Tarjeta";
            txtEfectivo.Text = lblCostoApagar.Text;
            txtEfectivo.Enabled = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }


        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
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

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                pictureBox2.Visible = true;
                label11.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
                label11.Visible = false;
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                pictureBox1.Visible = true;
                label1.Visible = true;
            }

            if (txtEfectivo.Text == "")
            {
                pictureBox3.Visible = true;
                label14.Visible = true;
            }

            if(txtCliente.Text != "" && txtEfectivo.Text != "")
            {
                TipoBoleta();
                pictureBox1.Visible = false;
                label1.Visible = false;
                pictureBox3.Visible = true;
                label14.Visible = true;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                label11.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                Agregar();
                label11.Visible = false;
                pictureBox2.Visible = false;
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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "BUSCAR")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.LightGray;
            }
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            tmHora.Start();
        }

        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblF.Text = DateTime.Now.ToLongDateString();
        }
    }
}

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
using System.Net.Mail;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmOdCompra : Form
    {
        clsProveedorMgr objProvMgr = new clsProveedorMgr();
        clsUsuarioMgr objUsuMgr = new clsUsuarioMgr();
        DataTable dt = null;

        int Conteo;
        string Origen = "elpepelibreria@gmail.com";
        string Contraseña = "libreria123456";

        public frmOdCompra()
        {
            InitializeComponent();
            llenarCombo();
        }

        private void frmOdCompra_Load(object sender, EventArgs e)
        {

        }

        void llenarCombo()
        {
            cboProveedor.DataSource = objProvMgr.ListarProv();
            cboProveedor.DisplayMember = "NombreEmpresa";
            cboProveedor.ValueMember = "idPro";
        }

        void Limpiar()
        {
            txtLibro.Clear();
            txtCantidad.Clear();
            dgvOrden.Rows.Clear();
        }

        void Enviar()
        {
            dt = new DataTable();

            Explorador.ShowDialog();

            int id = Convert.ToInt32(cboProveedor.SelectedValue.ToString());
            dt = objProvMgr.BuscarCorreo(id);

            string Destino = dt.Rows[0][0].ToString();
            string path = Explorador.FileName;

            MailMessage omailmessage = new MailMessage(Origen, Destino, "Este es el Asunto", "hola");
            omailmessage.Attachments.Add(new Attachment(path));

            SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com");
            oSmtpCliente.EnableSsl = true;
            oSmtpCliente.UseDefaultCredentials = false;
            oSmtpCliente.Port = 587;
            oSmtpCliente.Credentials = new System.Net.NetworkCredential(Origen, Contraseña);

            oSmtpCliente.Send(omailmessage);

            oSmtpCliente.Dispose();

        }

        void Guardar()
        {
            Conteo = dgvOrden.RowCount;
            dt = new DataTable();
            int id = Convert.ToInt32(cboProveedor.SelectedValue.ToString());

            if (Conteo != 0)
            {
                try
                {
                    clsOrdenCompra.idPro = id;
                    clsOrdenCompra.idEmp = clsEmpleado.idEmp;
                    clsOrdenCompra.fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    clsOrdenCompra.Hora = DateTime.Now.ToString("HH:mm:ss");
                    objUsuMgr.EjecutaQuery("RO");

                    dt = objUsuMgr.EjecutaQueryID("IDO");
                    clsDetalleOrden.idOC = int.Parse(dt.Rows[0][0].ToString());

                    for (int i = 0; i < Conteo; i++)
                    {
                        clsDetalleOrden.descripcion =dgvOrden.Rows[i].Cells[0].Value.ToString();
                        clsDetalleOrden.Cantidad = int.Parse(dgvOrden.Rows[i].Cells[1].Value.ToString());
                        objUsuMgr.EjecutaQuery("RDO");
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Hay datos en la Grilla","Sistema");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (( e.KeyChar >= 32 && e.KeyChar <= 47) ||( e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.dgvOrden.Rows.Add(txtLibro.Text, txtCantidad.Text);
            txtLibro.Clear();
            txtCantidad.Clear();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            dgvOrden.Rows.RemoveAt(dgvOrden.CurrentRow.Index);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnVPrevia_Click(object sender, EventArgs e)
        {
            Conteo = dgvOrden.RowCount;
            Reportes.rptviewerOrdendeCompra rpt = new Reportes.rptviewerOrdendeCompra();

            for (int i = 0; i < Conteo; i++)
            {
                clsOrdenCompraTemp odc = new clsOrdenCompraTemp();
                odc.Producto = (string)dgvOrden.Rows[i].Cells[0].Value;
                odc.Cantidad = Convert.ToInt32(dgvOrden.Rows[i].Cells[1].Value.ToString());
                rpt.datos.Add(odc);
            }

            rpt.Show();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
            Guardar();
            Limpiar();
        }
    }
}

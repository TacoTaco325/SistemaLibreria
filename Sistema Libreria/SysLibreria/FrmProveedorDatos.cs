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
    public partial class FrmProveedorDatos : Form
    {
        clsProveedor objprov = null;
        clsProveedorMgr objProvMgr = new clsProveedorMgr();
        DataTable dt = new DataTable();
        DataSet ds = null;

        public FrmProveedorDatos(clsProveedor pp)
        {
            InitializeComponent();
            txtID.Enabled = false;
            objprov = pp;
            tipooperacion();
        }

        private void FrmProveedorDatos_Load(object sender, EventArgs e)
        {

        }

        void tipooperacion()
        {
            switch (objprov.operacion)
            {
                case 1:
                    btnAceptar.Text = "Guardar";
                    break;
                case 2:
                    llenarcampos();
                    chkEstado.Enabled = false;
                    btnAceptar.Text = "Actualizar";
                    break;
            }
        }

        void llenarcampos()
        {
            txtID.Text = objprov.idpro.ToString();
            txtNombreEmpresa.Text = objprov.nomEmp.ToString();
            txtCorreo.Text = objprov.Correo.ToString();
            txtContacto.Text = objprov.Contacto.ToString();
            txtCiudad.Text = objprov.Ciudad.ToString();
            txtDireccion.Text = objprov.Direccion.ToString();
            txtTelefono.Text = objprov.telefono.ToString();
            txtPorcentaje.Text = objprov.Porcentaje.ToString();
            chkEstado.Checked = true;
        }

        void operacion()
        {
            switch (objprov.operacion)
            {
                case 1:
                    objProvMgr.NuevoProv(txtNombreEmpresa.Text.ToString(),
                                        txtCorreo.Text.ToString(),
                                        txtContacto.Text.ToString(),
                                        txtCiudad.Text.ToString(),
                                        txtDireccion.Text.ToString(),
                                        Convert.ToInt32(txtTelefono.Text),
                                        Convert.ToDecimal(txtPorcentaje.Text),
                                        chkEstado.Checked);
                    MessageBox.Show("El Proveedor se Grabó correctamente....", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case 2:
                    objProvMgr.ModificarProv(Convert.ToInt32(txtID.Text.ToString()),
                                            txtNombreEmpresa.Text.ToString(),
                                            txtCorreo.Text.ToString(),
                                            txtContacto.Text.ToString(),
                                            txtCiudad.Text.ToString(),
                                            txtDireccion.Text.ToString(),
                                            Convert.ToInt32(txtTelefono.Text),
                                            Convert.ToDecimal(txtPorcentaje.Text),
                                            chkEstado.Checked);
                    MessageBox.Show("El Proveedor se Grabó correctamente....", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            tipooperacion();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

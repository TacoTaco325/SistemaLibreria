using System;
using Entidad;
using Controlador;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class FrmLibrosDatos : Form
    {

        clsLibro objlibro = null;
        clsLibroMgr objlibromanager = new clsLibroMgr();
        DataTable dt = new DataTable();
        DataSet ds = null;

        public FrmLibrosDatos( clsLibro pp)
        {
            InitializeComponent();
            txtID.Enabled = false;
            objlibro = pp;
            LlenarCombo();
            tipooperacion();
        }

        private void FrmLibrosDatos_Load(object sender, EventArgs e)
        {
            
        }

        void LlenarCombo()
        {
            ds=objlibromanager.LlenarCombo();
            cboCategoria.DataSource = ds.Tables[0].DefaultView;
            cboCategoria.DisplayMember = "nombre";
            cboCategoria.ValueMember = "idcat";
            cboAutor.DataSource = ds.Tables[1].DefaultView;
            cboAutor.DisplayMember = "nombre";
            cboAutor.ValueMember = "idautor";
        }

        void operacion()
        {
            switch (objlibro.operacion)
            {
                case 1:
                    objlibromanager.Nuevo(txtNombre.Text,
                                          Convert.ToInt32(cboCategoria.SelectedValue.ToString()),
                                          Convert.ToInt32(txtISBM.Text),
                                          Convert.ToInt32(txtStock.Text),
                                          Convert.ToDecimal(txtPrecio.Text),
                                          Convert.ToInt32(cboAutor.SelectedValue.ToString()),
                                          chkEstado.Checked);
                                          
                    MessageBox.Show("El Libro se Grabó correctamente....", "Aviso", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case 2:
                    objlibromanager.modificar(Convert.ToInt32(txtID.Text),
                                          txtNombre.Text,
                                          Convert.ToInt32(cboCategoria.SelectedValue.ToString()),
                                          Convert.ToInt32(txtISBM.Text),
                                          Convert.ToInt32(txtStock.Text),
                                          Convert.ToDecimal(txtPrecio.Text),
                                          Convert.ToInt32(cboAutor.SelectedValue.ToString()),
                                          chkEstado.Checked);
                    MessageBox.Show("El Libro se Modifico correctamente....", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case 3:
                    objlibromanager.Nuevo(txtNombre.Text,
                                          Convert.ToInt32(cboCategoria.SelectedValue.ToString()),
                                          Convert.ToInt32(txtISBM.Text),
                                          Convert.ToInt32(txtStock.Text),
                                          Convert.ToDecimal(txtPrecio.Text),
                                          Convert.ToInt32(cboAutor.SelectedValue.ToString()),
                                          chkEstado.Checked);

                    MessageBox.Show("El Libro se Grabó correctamente....", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
            }
        }

        void tipooperacion()
        {
            switch (objlibro.operacion)
            {
                case 1:
                    btnAceptar.Text = "Guardar";
                    break;
                case 2:
                    llenarcampos();
                    chkEstado.Enabled=false;
                    btnAceptar.Text = "Actualizar";
                    break;
                case 3:
                    btnAceptar.Text = "Guardar";
                    txtStock.Text = "0";
                    txtStock.Enabled =false;
                    break;
            }
        }

        void llenarcampos()
        {
            txtID.Text = objlibro.idlibro.ToString();
            dt =objlibromanager.ListarLibroDatos(objlibro.idlibro);

            txtNombre.Text = dt.Rows[0][1].ToString();
            cboCategoria.SelectedValue = dt.Rows[0][2].ToString();
            txtISBM.Text = dt.Rows[0][3].ToString();
            txtStock.Text = dt.Rows[0][4].ToString();
            txtPrecio.Text = dt.Rows[0][5].ToString();
            cboAutor.SelectedValue = dt.Rows[0][6].ToString();
            chkEstado.Checked = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void txtISBM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
            }
        }

        private void txtISBM_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            operacion();
        }
    }
}

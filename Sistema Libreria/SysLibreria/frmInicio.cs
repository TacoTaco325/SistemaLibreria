using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Controlador;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class frmInicio : Form
    {
        clsLibroMgr objLibMgr = new clsLibroMgr();

        public frmInicio()
        {
            InitializeComponent();
            listarstock();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            tmHora.Start();
            TotalVentasHoy();
            TotalVentasMes();
        }

        void TotalVentasHoy()
        {
            DataTable dt = new DataTable();
            dt = objLibMgr.TotalVentasHoy(DateTime.Now.ToString("yyyy-MM-dd"));
            lblSumaVenta.Text = dt.Rows[0][0].ToString();
            lblNVenta.Text = dt.Rows[0][1].ToString();
        }

        void TotalVentasMes()
        {
            DataTable dt = new DataTable();
            dt = objLibMgr.TotalVentasMes(DateTime.Now.ToString("MM"));
            lblSumaVentaMes.Text = dt.Rows[0][0].ToString();
            lblNVentaMes.Text = dt.Rows[0][1].ToString();
        }

        void listarstock()
        {
            dgvLibro.DataSource = objLibMgr.LibroStock();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblNVenta_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblSumaVenta_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblNVentaMes_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblSumaVentaMes_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}

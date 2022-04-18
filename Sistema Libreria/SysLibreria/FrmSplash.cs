using System;
using System.Collections.Generic;
using System.ComponentModel;
using Controlador;
using Entidad;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLibreria
{
    public partial class FrmSplash : Form
    {
        int count = 0;

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            lblUsuario.Text=""+clsEmpleado.nombre+" "+clsEmpleado.apellido+"";
            this.Opacity = 0.0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }

            count += 1;

            if (count == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();

                if (clsEmpleado.idCargo == 1 || clsEmpleado.idCargo == 2)
                {
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmMortisal frm = new frmMortisal();
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}

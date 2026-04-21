using System;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            FrmListadoArticulos frm = new FrmListadoArticulos();
            frm.ShowDialog();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

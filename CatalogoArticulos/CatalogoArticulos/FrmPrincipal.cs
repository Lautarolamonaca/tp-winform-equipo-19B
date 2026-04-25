using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var frm = new FrmListadoArticulos();
            frm.ShowDialog();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            var frm = new FrmMarcas();
            frm.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            var frm = new FrmCategorias();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

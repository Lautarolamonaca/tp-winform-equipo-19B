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
    public partial class FrmImagenes : Form
    {
        private Articulo _articulo;

        public FrmImagenes(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
        }

        private void FrmImagenes_Load(object sender, EventArgs e)
        {
            lblArticulo.Text = $"Artículo: {_articulo.Nombre}";
            CargarImagenes();
        }

        private void CargarImagenes()
        {
            lstImagenes.Items.Clear();
            if (_articulo.Imagenes != null)
                foreach (var img in _articulo.Imagenes)
                    lstImagenes.Items.Add(img);
            ActualizarTotal();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Ingrese una URL de imagen.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrl.Focus();
                return;
            }
            Imagen nueva = new Imagen { IdArticulo = _articulo.Id, ImagenUrl = url };
            _articulo.Imagenes.Add(nueva);
            lstImagenes.Items.Add(nueva);
            txtUrl.Clear();
            txtUrl.Focus();
            ActualizarTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Imagen img = lstImagenes.SelectedItem as Imagen;
            if (img == null)
            {
                MessageBox.Show("Seleccione una imagen para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                "¿Desea eliminar la imagen seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _articulo.Imagenes.Remove(img);
                lstImagenes.Items.Remove(img);
                ActualizarTotal();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarTotal()
        {
            lblTotal.Text = $"Total: {lstImagenes.Items.Count} imagen(es)";
        }
    }
}

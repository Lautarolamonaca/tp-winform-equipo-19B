using System;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    public partial class FrmDetalleArticulo : Form
    {
        private Articulo _articulo;

        public FrmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
        }

        private void FrmDetalleArticulo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            lblCodigoVal.Text      = _articulo.Codigo;
            lblNombreVal.Text      = _articulo.Nombre;
            lblDescripcionVal.Text = _articulo.Descripcion;
            lblPrecioVal.Text      = _articulo.Precio.ToString("C2");
            lblMarcaVal.Text       = _articulo.Marca?.Descripcion ?? "-";
            lblCategoriaVal.Text   = _articulo.Categoria?.Descripcion ?? "-";

            lstImagenes.Items.Clear();
            if (_articulo.Imagenes != null)
            {
                foreach (var img in _articulo.Imagenes)
                    lstImagenes.Items.Add(img.ImagenUrl);
            }

            if (lstImagenes.Items.Count == 0)
                lstImagenes.Items.Add("(sin imágenes)");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

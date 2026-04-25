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
            lblCodVal.Text = _articulo.Codigo;
            lblNomVal.Text = _articulo.Nombre;
            lblDescVal.Text = _articulo.Descripcion;
            lblPrecVal.Text = _articulo.Precio.ToString("C2");
            lblMarcVal.Text = _articulo.Marca?.Descripcion ?? "-";
            lblCatVal.Text = _articulo.Categoria?.Descripcion ?? "-";

            lstImagenes.Items.Clear();
            if (_articulo.Imagenes != null)
                foreach (var img in _articulo.Imagenes)
                    lstImagenes.Items.Add(img.ImagenUrl);

            if (lstImagenes.Items.Count == 0)
                lstImagenes.Items.Add("(sin imágenes)");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

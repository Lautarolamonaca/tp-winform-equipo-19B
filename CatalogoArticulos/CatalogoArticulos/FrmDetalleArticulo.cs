using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

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

            // Cargar imagen en el PictureBox
            if (_articulo.Imagenes != null && _articulo.Imagenes.Count > 0)
            {
                CargarImagen(_articulo.Imagenes[0].ImagenUrl);
            }
            else
            {
                CargarImagen(null);
            }

        }

        private void CargarImagen(string url)
        {


            try
            {
                if (!string.IsNullOrEmpty(url))
                    pbimagen.Load(url);
                else
                    pbimagen.Load("https://via.placeholder.com/300");
            }
            catch
            {
                pbimagen.Load("https://via.placeholder.com/300");
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}

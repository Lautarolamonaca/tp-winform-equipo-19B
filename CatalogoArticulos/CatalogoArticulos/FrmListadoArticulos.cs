using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace CatalogoArticulos
{
    public partial class FrmListadoArticulos : Form
    {
 
        private List<Articulo> lista;

        public FrmListadoArticulos()
        {
            InitializeComponent();
        }


        private void FrmListadoArticulos_Load(object sender, EventArgs e)
        {

            dgvArticulos.Columns.Clear();
            dgvArticulos.AutoGenerateColumns = true;

            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            lista = negocio.Listar();

            foreach (Articulo art in lista)
            {
                art.Imagenes = imagenNegocio.ListarPorArticulo(art.Id);
            }

            dgvArticulos.DataSource = lista;
            lblTotal.Text = $"Total: {lista.Count} artículo(s)";

            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Código");
            cboCriterio.Items.Add("Nombre");
            cboCriterio.Items.Add("Marca");
            cboCriterio.Items.Add("Categoría");


        }

        private void CargarImagen(Articulo articulo)
        {
            try
            {
                if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    pbImagenArticulo.Load(articulo.Imagenes[0].ImagenUrl);
                else
                
                pbImagenArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUwCJYSnbBLMEGWKfSnWRGC_34iCCKkxePpg&s");
            }
            catch
            {
                pbImagenArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUwCJYSnbBLMEGWKfSnWRGC_34iCCKkxePpg&s");
            }
        }



        private void CargarArticulos()
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            lista = negocio.Listar();

            foreach (Articulo art in lista)
            {
                art.Imagenes = imagenNegocio.ListarPorArticulo(art.Id);
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = lista;

            lblTotal.Text = $"Total: {lista.Count} artículo(s)";

        }


        private Articulo ObtenerSeleccionado()
        {
            if (dgvArticulos.CurrentRow == null)
                return null;

            return (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
        }

  
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio de búsqueda.");
                return;
            }

            string criterio = cboCriterio.SelectedItem.ToString();
            string texto = txtBuscar.Text.Trim().ToLower();

            List<Articulo> listaFiltrada;

            switch (criterio)
            {
                case "Código":
                    listaFiltrada = lista
                        .Where(a => a.Codigo != null && a.Codigo.ToLower().Contains(texto))
                        .ToList();
                    break;

                case "Nombre":
                    listaFiltrada = lista
                        .Where(a => a.Nombre != null && a.Nombre.ToLower().Contains(texto))
                        .ToList();
                    break;

                case "Marca":
                    listaFiltrada = lista
                        .Where(a => a.Marca != null &&
                                    a.Marca.Descripcion.ToLower().Contains(texto))
                        .ToList();
                    break;

                case "Categoría":
                    listaFiltrada = lista
                        .Where(a => a.Categoria != null &&
                                    a.Categoria.Descripcion.ToLower().Contains(texto))
                        .ToList();
                    break;

                default:
                    listaFiltrada = lista;
                    break;
            }

            dgvArticulos.DataSource = listaFiltrada;
            lblTotal.Text = $"Total: {listaFiltrada.Count} artículo(s)";
        }

    
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                dgvArticulos.DataSource = lista;
                lblTotal.Text = $"Total: {lista.Count} artículo(s)";
            }
        }

   
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = new FrmArticulo();
            frm.ShowDialog();
            CargarArticulos();
        }

 
        private void btnVer_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = ObtenerSeleccionado();
            if (seleccionado == null) return;

            FrmDetalleArticulo frm = new FrmDetalleArticulo(seleccionado);
            frm.ShowDialog();
        }

    
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = ObtenerSeleccionado();
            if (seleccionado == null) return;

            FrmArticulo frm = new FrmArticulo(seleccionado);
            frm.ShowDialog();
            CargarArticulos();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

            Articulo seleccionado = ObtenerSeleccionado();
            if (seleccionado == null)
                return;

            DialogResult confirm = MessageBox.Show(
                $"¿Desea eliminar el artículo '{seleccionado.Nombre}'?\n" +
                "También se eliminarán sus imágenes asociadas.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                // 1️⃣ eliminar imágenes
                imagenNegocio.EliminarPorArticulo(seleccionado.Id);

                // 2️⃣ eliminar artículo
                articuloNegocio.Eliminar(seleccionado.Id);

                // 3️⃣ refrescar listado
                CargarArticulos();

                // 4️⃣ limpiar PictureBox (si lo usás)
                pbImagenArticulo.Image = null;
            }

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {

            Articulo seleccionado = ObtenerSeleccionado();
            if (seleccionado == null)
                return;

            CargarImagen(seleccionado);

        }
    }
}
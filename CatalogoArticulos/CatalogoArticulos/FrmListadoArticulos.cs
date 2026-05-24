using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

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


            EstiloBoton(btnNuevo);
            EstiloBoton(btnEditar);
            EstiloBoton(btnEliminar);
            EstiloBoton(btnBuscar);
            EstiloBoton(btnVer);
            this.BackColor = Color.FromArgb(250, 250, 250);




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
            frm.esEdicion = false;
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
            frm.esEdicion = true;
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

         
                imagenNegocio.EliminarPorArticulo(seleccionado.Id);

       
                articuloNegocio.Eliminar(seleccionado.Id);

         
                CargarArticulos();

            
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

        private void EstiloBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor = Color.FromArgb(0, 120, 215); // azul moderno
            btn.ForeColor = Color.White;

            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btn.TextAlign = ContentAlignment.MiddleCenter; // ✅ centrar texto
            btn.Height = 40; // ✅ altura para que no quede apretado
            btn.Width = 110; // opcional pero mejora proporción

            btn.Cursor = Cursors.Hand;

            // ✅ efecto hover (queda más moderno)
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(28, 151, 234);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(0, 120, 215);
            };
        }

    }
}
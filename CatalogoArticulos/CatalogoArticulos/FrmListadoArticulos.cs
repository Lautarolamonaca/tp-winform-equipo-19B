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
            lista = negocio.Listar();

            dgvArticulos.DataSource = lista;
            lblTotal.Text = $"Total: {lista.Count} artículo(s)";

            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Código");
            cboCriterio.Items.Add("Nombre");
            cboCriterio.Items.Add("Marca");
            cboCriterio.Items.Add("Categoría");

        }


        // ✅ Carga general del listado
        private void CargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            lista = negocio.Listar();

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
            if (seleccionado == null) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Desea eliminar el artículo '{seleccionado.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Eliminar(seleccionado.Id);
                CargarArticulos();
            }
        }
    }
}
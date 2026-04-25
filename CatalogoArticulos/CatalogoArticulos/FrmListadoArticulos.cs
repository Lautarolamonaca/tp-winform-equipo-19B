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
    public partial class FrmListadoArticulos : Form
    {
        private List<Articulo> _articulos = new List<Articulo>();

        public FrmListadoArticulos()
        {
            InitializeComponent();
        }

        private void FrmListadoArticulos_Load(object sender, EventArgs e)
        {
            CargarComboBusqueda();
            CargarArticulos();
        }

        private void CargarComboBusqueda()
        {
            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Todos");
            cboCriterio.Items.Add("Código");
            cboCriterio.Items.Add("Nombre");
            cboCriterio.Items.Add("Marca");
            cboCriterio.Items.Add("Categoría");
            cboCriterio.SelectedIndex = 0;
        }

        private void CargarArticulos()
        {
            _articulos = new List<Articulo>();
            MostrarArticulos(_articulos);
        }

        private void MostrarArticulos(List<Articulo> lista)
        {
            dgvArticulos.Rows.Clear();
            foreach (var a in lista)
            {
                dgvArticulos.Rows.Add(
                    a.Id, a.Codigo, a.Nombre,
                    a.Marca?.Descripcion,
                    a.Categoria?.Descripcion,
                    a.Precio.ToString("C2")
                );
            }
            lblTotal.Text = $"Total: {lista.Count} artículo(s)";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cboCriterio.SelectedItem?.ToString();
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(texto) || criterio == "Todos")
            {
                MostrarArticulos(_articulos);
                return;
            }

            var filtrados = new List<Articulo>();
            foreach (var a in _articulos)
            {
                bool coincide = false;
                switch (criterio)
                {
                    case "Código": coincide = a.Codigo?.ToLower().Contains(texto) == true; break;
                    case "Nombre": coincide = a.Nombre?.ToLower().Contains(texto) == true; break;
                    case "Marca": coincide = a.Marca?.Descripcion.ToLower().Contains(texto) == true; break;
                    case "Categoría": coincide = a.Categoria?.Descripcion.ToLower().Contains(texto) == true; break;
                }
                if (coincide) filtrados.Add(a);
            }
            MostrarArticulos(filtrados);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new FrmArticulo();
            frm.ShowDialog();
            CargarArticulos();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerSeleccionado();
            if (seleccionado == null) return;
            var frm = new FrmDetalleArticulo(seleccionado);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerSeleccionado();
            if (seleccionado == null) return;
            var frm = new FrmArticulo(seleccionado);
            frm.ShowDialog();
            CargarArticulos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerSeleccionado();
            if (seleccionado == null) return;
            DialogResult confirm = MessageBox.Show(
                $"¿Desea eliminar el artículo '{seleccionado.Nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Artículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarArticulos();
            }
        }

        private Articulo ObtenerSeleccionado()
        {
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un artículo de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            int id = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["colId"].Value);
            return _articulos.Find(a => a.Id == id);
        }

        private void FrmListadoArticulos_Load_1(object sender, EventArgs e)
        {

        }
    }
}

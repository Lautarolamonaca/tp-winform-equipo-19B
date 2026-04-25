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
    public partial class FrmCategorias : Form
    {
        private List<Categoria> listarCategoria;
        private bool cargando;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load_1(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            cargando = true;

            var negocio = new CategoriaNegocio();
            listarCategoria = negocio.Listar();

            lstCategorias.DataSource = null;
            lstCategorias.DataSource = listarCategoria;

            if (lstCategorias.Items.Count > 0)
                lstCategorias.SelectedIndex = 0;

            cargando = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstCategorias.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            // Agrega lo seleccionado del ListBox al TextBox
            txtDescripcion.Text = lstCategorias.SelectedItem.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionada = (Categoria)lstCategorias.SelectedItem;
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción.");
                return;
            }

            seleccionada.Descripcion = txtDescripcion.Text.Trim();

            var negocio = new CategoriaNegocio();
            negocio.Modificar(seleccionada);

            txtDescripcion.Clear();
            CargarCategorias();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var nueva = new Categoria();
            nueva.Descripcion = txtDescripcion.Text.Trim();

            var negocio = new CategoriaNegocio();
            negocio.Agregar(nueva);

            MessageBox.Show("Categoría guardada correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            txtDescripcion.Clear();
            CargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionada = (Categoria)lstCategorias.SelectedItem;
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar la categoría '{seleccionada.Descripcion}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var negocio = new CategoriaNegocio();
                negocio.Eliminar(seleccionada.Id);
                CargarCategorias();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

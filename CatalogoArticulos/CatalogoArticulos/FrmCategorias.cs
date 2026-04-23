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
    public partial class FrmCategorias : Form
    {
        private List<Categoria> _categorias = new List<Categoria>();

        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            lstCategorias.DataSource = null;
            lstCategorias.DataSource = _categorias;
            lstCategorias.DisplayMember = "Descripcion";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text.Trim();
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Ingrese una descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }
            Categoria nueva = new Categoria { Descripcion = desc };
            _categorias.Add(nueva);
            txtDescripcion.Clear();
            CargarCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria seleccionada = lstCategorias.SelectedItem as Categoria;
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtDescripcion.Text = seleccionada.Descripcion;
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            Categoria seleccionada = lstCategorias.SelectedItem as Categoria;
            if (seleccionada == null || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Seleccione una categoría e ingrese la descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            seleccionada.Descripcion = txtDescripcion.Text.Trim();
            txtDescripcion.Clear();
            CargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria seleccionada = lstCategorias.SelectedItem as Categoria;
            if (seleccionada == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar la categoría '{seleccionada.Descripcion}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                _categorias.Remove(seleccionada);
                txtDescripcion.Clear();
                CargarCategorias();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
        public partial class FrmMarcas : Form
        {
            private List<Marca> _marcas = new List<Marca>();

            public FrmMarcas()
            {
                InitializeComponent();
            }

            private void FrmMarcas_Load(object sender, EventArgs e)
            {
                CargarMarcas();
            }

            private void CargarMarcas()
            {
                lstMarcas.DataSource = null;
                lstMarcas.DataSource = _marcas;
                lstMarcas.DisplayMember = "Descripcion";
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
                Marca nueva = new Marca { Descripcion = desc };
                _marcas.Add(nueva);
                txtDescripcion.Clear();
                CargarMarcas();
            }

            private void btnEditar_Click(object sender, EventArgs e)
            {
                Marca seleccionada = lstMarcas.SelectedItem as Marca;
                if (seleccionada == null)
                {
                    MessageBox.Show("Seleccione una marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                txtDescripcion.Text = seleccionada.Descripcion;
            }

            private void btnGuardarEdicion_Click(object sender, EventArgs e)
            {
                Marca seleccionada = lstMarcas.SelectedItem as Marca;
                if (seleccionada == null || string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Seleccione una marca e ingrese la descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                seleccionada.Descripcion = txtDescripcion.Text.Trim();
                txtDescripcion.Clear();
                CargarMarcas();
            }

            private void btnEliminar_Click(object sender, EventArgs e)
            {
                Marca seleccionada = lstMarcas.SelectedItem as Marca;
                if (seleccionada == null)
                {
                    MessageBox.Show("Seleccione una marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult confirm = MessageBox.Show(
                    $"¿Eliminar la marca '{seleccionada.Descripcion}'?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    _marcas.Remove(seleccionada);
                    txtDescripcion.Clear();
                    CargarMarcas();
                }
            }

            private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        private void lstMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

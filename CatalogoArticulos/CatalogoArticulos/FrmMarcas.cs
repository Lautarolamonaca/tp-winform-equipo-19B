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
    public partial class FrmMarcas : Form
    {

        private List<Marca> listaMarcas;
        private Marca seleccionada;

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
            var negocio = new MarcaNegocio();
            listaMarcas = negocio.Listar();

            lstMarcas.DataSource = null;
            lstMarcas.DataSource = listaMarcas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("Ingrese una descripción.");
                return;
            }

            var nueva = new Marca();
            nueva.Descripcion = desc;

            var negocio = new MarcaNegocio();
            negocio.Agregar(nueva);

            txtDescripcion.Clear();
            CargarMarcas();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una marca.");
                return;
            }

            seleccionada = (Marca)lstMarcas.SelectedItem;
            txtDescripcion.Text = seleccionada.Descripcion;

        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {

            if (seleccionada == null || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Seleccione una marca e ingrese la descripción.");
                return;
            }

            seleccionada.Descripcion = txtDescripcion.Text.Trim();

            var negocio = new MarcaNegocio();
            negocio.Modificar(seleccionada);

            seleccionada = null;
            txtDescripcion.Clear();
            CargarMarcas();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una marca.");
                return;
            }

            var eliminar = (Marca)lstMarcas.SelectedItem;

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar la marca?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                var negocio = new MarcaNegocio();
                negocio.Eliminar(eliminar.Id);
                CargarMarcas();
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

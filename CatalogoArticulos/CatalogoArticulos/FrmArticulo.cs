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
    public partial class FrmArticulo : Form
    {
        private Articulo articulo;
        

        public FrmArticulo()
        {
            InitializeComponent();
         
        }


        public FrmArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

             
        private void CargarMarcas()
        {
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "Id";
            cboMarca.DataSource = new List<Marca>();
        }

        private void CargarCategorias()
        {
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Id";
            cboCategoria.DataSource = new List<Categoria>();
        }


        private void CargarArticulo()
        {
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();

            cboMarca.SelectedValue = articulo.Marca.Id;
            cboCategoria.SelectedValue = articulo.Categoria.Id;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar campos vacíos
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El Código y el Nombre son obligatorios.");
                return; // Sale del método y no guarda
            }

            // 2. Validar selección de Marca y Categoría
            if (cboMarca.SelectedItem == null || cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una Marca y una Categoría.");
                return;
            }

            // 4. Validar que el precio sea un número 
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            if (!Validar())
                return;

            ArticuloNegocio negocio = new ArticuloNegocio();

            if (articulo == null)
                articulo = new Articulo();

            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Precio = decimal.Parse(txtPrecio.Text);

            articulo.Marca = (Marca)cboMarca.SelectedItem;
            articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

            if (articulo.Id == 0)
            {
                articulo.Id = negocio.Agregar(articulo); 
            }
            else
            {
                negocio.Modificar(articulo);
            }

            MessageBox.Show("Artículo guardado correctamente.");
    

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

  
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }
            if (cboMarca.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una marca.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMarca.Focus();
                return false;
            }
            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();
                return false;
            }
            return true;
        }

      

        private void btnImagenes_Click(object sender, EventArgs e)
        {



            if (articulo == null || articulo.Id == 0)
            {
                MessageBox.Show("Primero debe guardar el artículo para poder agregar imágenes.");
                return;
            }

            FrmImagenes frm = new FrmImagenes(articulo.Id);
            frm.ShowDialog();
            LimpiarFormulario();

        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();

            cboMarca.SelectedIndex = -1;
            cboCategoria.SelectedIndex = -1;

            articulo = null;  
        }


        private void FrmArticulo_Load_1(object sender, EventArgs e)
        {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            cboMarca.DataSource = marcaNegocio.Listar();
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember = "Id";

            cboCategoria.DataSource = categoriaNegocio.Listar();
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Id";


            if (articulo != null)
                CargarArticulo();

        }
    }
}

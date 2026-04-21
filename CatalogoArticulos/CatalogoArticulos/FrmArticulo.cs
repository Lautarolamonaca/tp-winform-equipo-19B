using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    public partial class FrmArticulo : Form
    {
        private Articulo _articulo;
        private bool _esEdicion;

        // Alta
        public FrmArticulo()
        {
            InitializeComponent();
            _articulo  = new Articulo();
            _esEdicion = false;
        }

        // Modificación
        public FrmArticulo(Articulo articulo)
        {
            InitializeComponent();
            _articulo  = articulo;
            _esEdicion = true;
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Text = _esEdicion ? "Modificar Artículo" : "Nuevo Artículo";
            CargarMarcas();
            CargarCategorias();

            if (_esEdicion)
                CargarDatosEnFormulario();
        }

        private void CargarMarcas()
        {
            // Etapa 2: se reemplaza por consulta a BD
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.ValueMember   = "Id";
            cboMarca.DataSource    = new List<Marca>();
        }

        private void CargarCategorias()
        {
            // Etapa 2: se reemplaza por consulta a BD
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember   = "Id";
            cboCategoria.DataSource    = new List<Categoria>();
        }

        private void CargarDatosEnFormulario()
        {
            txtCodigo.Text      = _articulo.Codigo;
            txtNombre.Text      = _articulo.Nombre;
            txtDescripcion.Text = _articulo.Descripcion;
            txtPrecio.Text      = _articulo.Precio.ToString();

            // Seleccionar marca y categoría actuales
            if (_articulo.Marca != null)
                cboMarca.SelectedValue = _articulo.Marca.Id;
            if (_articulo.Categoria != null)
                cboCategoria.SelectedValue = _articulo.Categoria.Id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            _articulo.Codigo      = txtCodigo.Text.Trim();
            _articulo.Nombre      = txtNombre.Text.Trim();
            _articulo.Descripcion = txtDescripcion.Text.Trim();
            _articulo.Precio      = decimal.Parse(txtPrecio.Text.Trim());
            _articulo.Marca       = cboMarca.SelectedItem as Marca;
            _articulo.Categoria   = cboCategoria.SelectedItem as Categoria;

            // Etapa 2: persistencia en BD
            string accion = _esEdicion ? "modificado" : "guardado";
            MessageBox.Show($"Artículo {accion} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            FrmImagenes frm = new FrmImagenes(_articulo);
            frm.ShowDialog();
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
    }
}

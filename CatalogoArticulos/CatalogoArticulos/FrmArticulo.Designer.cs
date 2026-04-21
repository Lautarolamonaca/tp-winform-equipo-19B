using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmArticulo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCodigo      = new TextBox();
            this.txtNombre      = new TextBox();
            this.txtDescripcion = new TextBox();
            this.txtPrecio      = new TextBox();
            this.cboMarca       = new ComboBox();
            this.cboCategoria   = new ComboBox();
            this.btnGuardar     = new Button();
            this.btnCancelar    = new Button();
            this.btnImagenes    = new Button();
            this.lblCodigo      = new Label();
            this.lblNombre      = new Label();
            this.lblDescripcion = new Label();
            this.lblPrecio      = new Label();
            this.lblMarca       = new Label();
            this.lblCategoria   = new Label();
            this.SuspendLayout();

            int labelX  = 20;
            int inputX  = 130;
            int inputW  = 280;
            int rowH    = 35;
            int startY  = 20;

            // Código
            this.lblCodigo.Text     = "Código:";
            this.lblCodigo.Location = new Point(labelX, startY + 4);
            this.lblCodigo.Size     = new Size(100, 20);
            this.txtCodigo.Location = new Point(inputX, startY);
            this.txtCodigo.Size     = new Size(inputW, 24);
            this.txtCodigo.MaxLength = 50;

            // Nombre
            this.lblNombre.Text     = "Nombre:";
            this.lblNombre.Location = new Point(labelX, startY + rowH + 4);
            this.lblNombre.Size     = new Size(100, 20);
            this.txtNombre.Location = new Point(inputX, startY + rowH);
            this.txtNombre.Size     = new Size(inputW, 24);
            this.txtNombre.MaxLength = 50;

            // Descripción
            this.lblDescripcion.Text     = "Descripción:";
            this.lblDescripcion.Location = new Point(labelX, startY + rowH * 2 + 4);
            this.lblDescripcion.Size     = new Size(100, 20);
            this.txtDescripcion.Location = new Point(inputX, startY + rowH * 2);
            this.txtDescripcion.Size     = new Size(inputW, 60);
            this.txtDescripcion.Multiline    = true;
            this.txtDescripcion.MaxLength    = 150;
            this.txtDescripcion.ScrollBars   = ScrollBars.Vertical;

            // Precio
            this.lblPrecio.Text     = "Precio:";
            this.lblPrecio.Location = new Point(labelX, startY + rowH * 2 + 70);
            this.lblPrecio.Size     = new Size(100, 20);
            this.txtPrecio.Location = new Point(inputX, startY + rowH * 2 + 66);
            this.txtPrecio.Size     = new Size(140, 24);

            // Marca
            this.lblMarca.Text     = "Marca:";
            this.lblMarca.Location = new Point(labelX, startY + rowH * 2 + 105);
            this.lblMarca.Size     = new Size(100, 20);
            this.cboMarca.Location = new Point(inputX, startY + rowH * 2 + 101);
            this.cboMarca.Size     = new Size(inputW, 24);
            this.cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;

            // Categoría
            this.lblCategoria.Text     = "Categoría:";
            this.lblCategoria.Location = new Point(labelX, startY + rowH * 2 + 140);
            this.lblCategoria.Size     = new Size(100, 20);
            this.cboCategoria.Location = new Point(inputX, startY + rowH * 2 + 136);
            this.cboCategoria.Size     = new Size(inputW, 24);
            this.cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            // Botón imágenes
            this.btnImagenes.Text     = "Gestionar Imágenes...";
            this.btnImagenes.Location = new Point(inputX, startY + rowH * 2 + 175);
            this.btnImagenes.Size     = new Size(160, 30);
            this.btnImagenes.Click   += new System.EventHandler(this.btnImagenes_Click);

            // Botones guardar / cancelar
            this.btnGuardar.Text     = "Guardar";
            this.btnGuardar.Location = new Point(inputX, startY + rowH * 2 + 225);
            this.btnGuardar.Size     = new Size(90, 32);
            this.btnGuardar.Click   += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.Location = new Point(inputX + 100, startY + rowH * 2 + 225);
            this.btnCancelar.Size     = new Size(90, 32);
            this.btnCancelar.Click   += new System.EventHandler(this.btnCancelar_Click);

            // Formulario
            this.ClientSize    = new Size(450, 330);
            this.Text          = "Artículo";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Load         += new System.EventHandler(this.FrmArticulo_Load);
            this.Controls.AddRange(new Control[] {
                this.lblCodigo,   this.txtCodigo,
                this.lblNombre,   this.txtNombre,
                this.lblDescripcion, this.txtDescripcion,
                this.lblPrecio,   this.txtPrecio,
                this.lblMarca,    this.cboMarca,
                this.lblCategoria, this.cboCategoria,
                this.btnImagenes,
                this.btnGuardar,  this.btnCancelar
            });
            this.ResumeLayout(false);
        }

        private TextBox  txtCodigo;
        private TextBox  txtNombre;
        private TextBox  txtDescripcion;
        private TextBox  txtPrecio;
        private ComboBox cboMarca;
        private ComboBox cboCategoria;
        private Button   btnGuardar;
        private Button   btnCancelar;
        private Button   btnImagenes;
        private Label    lblCodigo;
        private Label    lblNombre;
        private Label    lblDescripcion;
        private Label    lblPrecio;
        private Label    lblMarca;
        private Label    lblCategoria;
    }
}

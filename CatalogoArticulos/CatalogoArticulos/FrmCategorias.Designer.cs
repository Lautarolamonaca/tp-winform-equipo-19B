using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmCategorias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstCategorias     = new ListBox();
            this.txtDescripcion    = new TextBox();
            this.btnAgregar        = new Button();
            this.btnEditar         = new Button();
            this.btnGuardarEdicion = new Button();
            this.btnEliminar       = new Button();
            this.btnCerrar         = new Button();
            this.lblDescripcion    = new Label();
            this.SuspendLayout();

            this.lstCategorias.Location = new Point(10, 10);
            this.lstCategorias.Size     = new Size(250, 200);

            this.lblDescripcion.Text     = "Descripción:";
            this.lblDescripcion.Location = new Point(10, 225);
            this.lblDescripcion.Size     = new Size(80, 20);

            this.txtDescripcion.Location  = new Point(95, 222);
            this.txtDescripcion.Size      = new Size(165, 24);
            this.txtDescripcion.MaxLength = 50;

            this.btnAgregar.Text     = "Agregar";
            this.btnAgregar.Location = new Point(10, 260);
            this.btnAgregar.Size     = new Size(75, 28);
            this.btnAgregar.Click   += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Text     = "Cargar";
            this.btnEditar.Location = new Point(92, 260);
            this.btnEditar.Size     = new Size(75, 28);
            this.btnEditar.Click   += new System.EventHandler(this.btnEditar_Click);

            this.btnGuardarEdicion.Text     = "Guardar";
            this.btnGuardarEdicion.Location = new Point(174, 260);
            this.btnGuardarEdicion.Size     = new Size(75, 28);
            this.btnGuardarEdicion.Click   += new System.EventHandler(this.btnGuardarEdicion_Click);

            this.btnEliminar.Text     = "Eliminar";
            this.btnEliminar.Location = new Point(10, 298);
            this.btnEliminar.Size     = new Size(75, 28);
            this.btnEliminar.Click   += new System.EventHandler(this.btnEliminar_Click);

            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.Location = new Point(174, 298);
            this.btnCerrar.Size     = new Size(75, 28);
            this.btnCerrar.Click   += new System.EventHandler(this.btnCerrar_Click);

            this.ClientSize    = new Size(275, 345);
            this.Text          = "Administrar Categorías";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Load         += new System.EventHandler(this.FrmCategorias_Load);
            this.Controls.AddRange(new Control[] {
                lstCategorias, lblDescripcion, txtDescripcion,
                btnAgregar, btnEditar, btnGuardarEdicion,
                btnEliminar, btnCerrar
            });
            this.ResumeLayout(false);
        }

        private ListBox lstCategorias;
        private TextBox txtDescripcion;
        private Button  btnAgregar;
        private Button  btnEditar;
        private Button  btnGuardarEdicion;
        private Button  btnEliminar;
        private Button  btnCerrar;
        private Label   lblDescripcion;
    }
}

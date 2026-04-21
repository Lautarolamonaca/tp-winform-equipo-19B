using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmImagenes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblArticulo = new Label();
            this.lstImagenes = new ListBox();
            this.txtUrl      = new TextBox();
            this.btnAgregar  = new Button();
            this.btnEliminar = new Button();
            this.btnCerrar   = new Button();
            this.lblUrl      = new Label();
            this.lblTotal    = new Label();
            this.SuspendLayout();

            this.lblArticulo.Location  = new Point(10, 10);
            this.lblArticulo.Size      = new Size(460, 20);
            this.lblArticulo.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.lstImagenes.Location          = new Point(10, 40);
            this.lstImagenes.Size              = new Size(460, 150);
            this.lstImagenes.HorizontalScrollbar = true;

            this.lblTotal.Location = new Point(10, 198);
            this.lblTotal.Size     = new Size(200, 18);

            this.lblUrl.Text     = "URL de imagen:";
            this.lblUrl.Location = new Point(10, 226);
            this.lblUrl.Size     = new Size(100, 20);

            this.txtUrl.Location  = new Point(115, 223);
            this.txtUrl.Size      = new Size(280, 24);
            this.txtUrl.MaxLength = 1000;

            this.btnAgregar.Text     = "Agregar";
            this.btnAgregar.Location = new Point(405, 221);
            this.btnAgregar.Size     = new Size(65, 28);
            this.btnAgregar.Click   += new System.EventHandler(this.btnAgregar_Click);

            this.btnEliminar.Text     = "Eliminar seleccionada";
            this.btnEliminar.Location = new Point(10, 265);
            this.btnEliminar.Size     = new Size(160, 30);
            this.btnEliminar.Click   += new System.EventHandler(this.btnEliminar_Click);

            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.Location = new Point(390, 265);
            this.btnCerrar.Size     = new Size(80, 30);
            this.btnCerrar.Click   += new System.EventHandler(this.btnCerrar_Click);

            this.ClientSize    = new Size(486, 310);
            this.Text          = "Imágenes del Artículo";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Load         += new System.EventHandler(this.FrmImagenes_Load);
            this.Controls.AddRange(new Control[] {
                lblArticulo, lstImagenes, lblTotal,
                lblUrl, txtUrl, btnAgregar,
                btnEliminar, btnCerrar
            });
            this.ResumeLayout(false);
        }

        private Label   lblArticulo;
        private ListBox lstImagenes;
        private TextBox txtUrl;
        private Button  btnAgregar;
        private Button  btnEliminar;
        private Button  btnCerrar;
        private Label   lblUrl;
        private Label   lblTotal;
    }
}

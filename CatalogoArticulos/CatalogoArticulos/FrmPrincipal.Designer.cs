using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnArticulos  = new Button();
            this.btnMarcas     = new Button();
            this.btnCategorias = new Button();
            this.btnSalir      = new Button();
            this.lblTitulo     = new Label();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text      = "Catálogo de Artículos";
            this.lblTitulo.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitulo.Size      = new Size(360, 50);
            this.lblTitulo.Location  = new Point(20, 30);

            // btnArticulos
            this.btnArticulos.Text     = "Gestionar Artículos";
            this.btnArticulos.Size     = new Size(200, 45);
            this.btnArticulos.Location = new Point(100, 110);
            this.btnArticulos.Font     = new Font("Segoe UI", 10F);
            this.btnArticulos.Click   += new System.EventHandler(this.btnArticulos_Click);

            // btnMarcas
            this.btnMarcas.Text     = "Administrar Marcas";
            this.btnMarcas.Size     = new Size(200, 45);
            this.btnMarcas.Location = new Point(100, 170);
            this.btnMarcas.Font     = new Font("Segoe UI", 10F);
            this.btnMarcas.Click   += new System.EventHandler(this.btnMarcas_Click);

            // btnCategorias
            this.btnCategorias.Text     = "Administrar Categorías";
            this.btnCategorias.Size     = new Size(200, 45);
            this.btnCategorias.Location = new Point(100, 230);
            this.btnCategorias.Font     = new Font("Segoe UI", 10F);
            this.btnCategorias.Click   += new System.EventHandler(this.btnCategorias_Click);

            // btnSalir
            this.btnSalir.Text     = "Salir";
            this.btnSalir.Size     = new Size(200, 40);
            this.btnSalir.Location = new Point(100, 300);
            this.btnSalir.Font     = new Font("Segoe UI", 10F);
            this.btnSalir.Click   += new System.EventHandler(this.btnSalir_Click);

            // FrmPrincipal
            this.ClientSize  = new Size(400, 380);
            this.Text        = "Catálogo de Artículos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.AddRange(new Control[] {
                this.lblTitulo, this.btnArticulos,
                this.btnMarcas, this.btnCategorias, this.btnSalir
            });
            this.ResumeLayout(false);
        }

        private Button btnArticulos;
        private Button btnMarcas;
        private Button btnCategorias;
        private Button btnSalir;
        private Label  lblTitulo;
    }
}

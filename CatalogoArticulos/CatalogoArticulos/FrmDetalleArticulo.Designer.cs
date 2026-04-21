using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmDetalleArticulo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCodigo       = new Label();
            this.lblNombre       = new Label();
            this.lblDescripcion  = new Label();
            this.lblPrecio       = new Label();
            this.lblMarca        = new Label();
            this.lblCategoria    = new Label();
            this.lblImagenesTitle = new Label();
            this.lblCodigoVal    = new Label();
            this.lblNombreVal    = new Label();
            this.lblDescripcionVal = new Label();
            this.lblPrecioVal    = new Label();
            this.lblMarcaVal     = new Label();
            this.lblCategoriaVal = new Label();
            this.lstImagenes     = new ListBox();
            this.btnCerrar       = new Button();
            this.SuspendLayout();

            int lx = 20, vx = 130, w = 280, rh = 30, sy = 15;
            Font bold = new Font("Segoe UI", 9F, FontStyle.Bold);

            void Fila(Label lbl, string texto, Label val, int y)
            {
                lbl.Text = texto; lbl.Font = bold;
                lbl.Location = new Point(lx, y + 3); lbl.Size = new Size(105, 20);
                val.Location = new Point(vx, y);     val.Size = new Size(w, 22);
                val.AutoEllipsis = true;
            }

            Fila(lblCodigo,      "Código:",      lblCodigoVal,      sy);
            Fila(lblNombre,      "Nombre:",      lblNombreVal,      sy + rh);
            Fila(lblDescripcion, "Descripción:", lblDescripcionVal, sy + rh * 2);
            Fila(lblPrecio,      "Precio:",      lblPrecioVal,      sy + rh * 3);
            Fila(lblMarca,       "Marca:",       lblMarcaVal,       sy + rh * 4);
            Fila(lblCategoria,   "Categoría:",   lblCategoriaVal,   sy + rh * 5);

            this.lblImagenesTitle.Text     = "Imágenes:";
            this.lblImagenesTitle.Font     = bold;
            this.lblImagenesTitle.Location = new Point(lx, sy + rh * 6 + 5);
            this.lblImagenesTitle.Size     = new Size(105, 20);

            this.lstImagenes.Location      = new Point(lx, sy + rh * 7);
            this.lstImagenes.Size          = new Size(390, 90);
            this.lstImagenes.HorizontalScrollbar = true;

            this.btnCerrar.Text     = "Cerrar";
            this.btnCerrar.Location = new Point(310, sy + rh * 7 + 100);
            this.btnCerrar.Size     = new Size(80, 30);
            this.btnCerrar.Click   += new System.EventHandler(this.btnCerrar_Click);

            this.ClientSize    = new Size(430, sy + rh * 7 + 150);
            this.Text          = "Detalle del Artículo";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.Load         += new System.EventHandler(this.FrmDetalleArticulo_Load);
            this.Controls.AddRange(new Control[] {
                lblCodigo, lblCodigoVal,
                lblNombre, lblNombreVal,
                lblDescripcion, lblDescripcionVal,
                lblPrecio, lblPrecioVal,
                lblMarca, lblMarcaVal,
                lblCategoria, lblCategoriaVal,
                lblImagenesTitle, lstImagenes,
                btnCerrar
            });
            this.ResumeLayout(false);
        }

        private Label   lblCodigo, lblNombre, lblDescripcion, lblPrecio, lblMarca, lblCategoria, lblImagenesTitle;
        private Label   lblCodigoVal, lblNombreVal, lblDescripcionVal, lblPrecioVal, lblMarcaVal, lblCategoriaVal;
        private ListBox lstImagenes;
        private Button  btnCerrar;
    }
}

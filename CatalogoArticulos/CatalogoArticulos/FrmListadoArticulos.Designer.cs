using System.Drawing;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    partial class FrmListadoArticulos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvArticulos  = new DataGridView();
            this.txtBuscar     = new TextBox();
            this.cboCriterio   = new ComboBox();
            this.btnBuscar     = new Button();
            this.btnNuevo      = new Button();
            this.btnVer        = new Button();
            this.btnEditar     = new Button();
            this.btnEliminar   = new Button();
            this.lblBuscar     = new Label();
            this.lblTotal      = new Label();
            this.pnlBusqueda   = new Panel();
            this.pnlBotones    = new Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();

            // Panel búsqueda
            this.pnlBusqueda.Size     = new Size(760, 50);
            this.pnlBusqueda.Location = new Point(10, 10);

            this.lblBuscar.Text     = "Buscar por:";
            this.lblBuscar.Location = new Point(0, 15);
            this.lblBuscar.Size     = new Size(70, 20);

            this.cboCriterio.Location     = new Point(75, 12);
            this.cboCriterio.Size         = new Size(110, 24);
            this.cboCriterio.DropDownStyle = ComboBoxStyle.DropDownList;

            this.txtBuscar.Location = new Point(195, 12);
            this.txtBuscar.Size     = new Size(220, 24);
            this.txtBuscar.KeyDown += new KeyEventHandler(this.txtBuscar_KeyDown);

            this.btnBuscar.Text     = "Buscar";
            this.btnBuscar.Location = new Point(425, 10);
            this.btnBuscar.Size     = new Size(80, 28);
            this.btnBuscar.Click   += new System.EventHandler(this.btnBuscar_Click);

            this.pnlBusqueda.Controls.AddRange(new Control[] {
                this.lblBuscar, this.cboCriterio, this.txtBuscar, this.btnBuscar
            });

            // DataGridView
            this.dgvArticulos.Location           = new Point(10, 70);
            this.dgvArticulos.Size               = new Size(760, 360);
            this.dgvArticulos.ReadOnly           = true;
            this.dgvArticulos.SelectionMode      = DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.MultiSelect        = false;
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.RowHeadersVisible  = false;

            // Columnas
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId",        HeaderText = "ID",        Visible = false });
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCodigo",     HeaderText = "Código",    FillWeight = 60 });
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre",     HeaderText = "Nombre",    FillWeight = 160 });
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMarca",      HeaderText = "Marca",     FillWeight = 80 });
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategoria",  HeaderText = "Categoría", FillWeight = 80 });
            this.dgvArticulos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrecio",     HeaderText = "Precio",    FillWeight = 70 });

            // lblTotal
            this.lblTotal.Text     = "Total: 0 artículo(s)";
            this.lblTotal.Location = new Point(10, 438);
            this.lblTotal.Size     = new Size(200, 20);

            // Panel botones
            this.pnlBotones.Size     = new Size(760, 45);
            this.pnlBotones.Location = new Point(10, 460);

            this.btnNuevo.Text     = "Nuevo";
            this.btnNuevo.Size     = new Size(90, 35);
            this.btnNuevo.Location = new Point(0, 5);
            this.btnNuevo.Click   += new System.EventHandler(this.btnNuevo_Click);

            this.btnVer.Text     = "Ver Detalle";
            this.btnVer.Size     = new Size(90, 35);
            this.btnVer.Location = new Point(100, 5);
            this.btnVer.Click   += new System.EventHandler(this.btnVer_Click);

            this.btnEditar.Text     = "Editar";
            this.btnEditar.Size     = new Size(90, 35);
            this.btnEditar.Location = new Point(200, 5);
            this.btnEditar.Click   += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Text     = "Eliminar";
            this.btnEliminar.Size     = new Size(90, 35);
            this.btnEliminar.Location = new Point(300, 5);
            this.btnEliminar.Click   += new System.EventHandler(this.btnEliminar_Click);

            this.pnlBotones.Controls.AddRange(new Control[] {
                this.btnNuevo, this.btnVer, this.btnEditar, this.btnEliminar
            });

            // Formulario
            this.ClientSize    = new Size(784, 520);
            this.Text          = "Listado de Artículos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load         += new System.EventHandler(this.FrmListadoArticulos_Load);
            this.Controls.AddRange(new Control[] {
                this.pnlBusqueda, this.dgvArticulos, this.lblTotal, this.pnlBotones
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
        }

        private DataGridView dgvArticulos;
        private TextBox      txtBuscar;
        private ComboBox     cboCriterio;
        private Button       btnBuscar;
        private Button       btnNuevo;
        private Button       btnVer;
        private Button       btnEditar;
        private Button       btnEliminar;
        private Label        lblBuscar;
        private Label        lblTotal;
        private Panel        pnlBusqueda;
        private Panel        pnlBotones;
    }
}

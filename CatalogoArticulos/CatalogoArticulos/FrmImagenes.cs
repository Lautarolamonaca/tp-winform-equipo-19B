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
    public partial class FrmImagenes : Form
    {

        private int idArticulo;
        private List<Imagen> listaImagenes;


        public FrmImagenes()
        {

            InitializeComponent();
           

        }

        private void FrmImagenes_Load_1(object sender, EventArgs e)
        {
            CargarImagenes();
        }

        private void CargarImagenes()
        {

            ImagenNegocio negocio = new ImagenNegocio();

            // ✅ TODAS LAS IMÁGENES
            listaImagenes = negocio.Listar();

            lstImagenes.DataSource = null;
            lstImagenes.DataSource = listaImagenes;
            lstImagenes.DisplayMember = "ImagenUrl";

            lblTotal.Text = $"Total: {listaImagenes.Count} imagen(es)";


        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Imagen img = new Imagen();
            img.IdArticulo = idArticulo;
            img.ImagenUrl = txtUrl.Text;

            ImagenNegocio negocio = new ImagenNegocio();
            negocio.Agregar(img);

            txtUrl.Clear();
            CargarImagenes();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (lstImagenes.SelectedItem == null)
                return;

            Imagen seleccionada = (Imagen)lstImagenes.SelectedItem;

            ImagenNegocio negocio = new ImagenNegocio();
            negocio.Eliminar(seleccionada.Id);

            CargarImagenes();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarTotal()
        {
            lblTotal.Text = $"Total: {lstImagenes.Items.Count} imagen(es)";
        }

        private void lstImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lstImagenes.SelectedItem == null)
                return;

            Imagen img = (Imagen)lstImagenes.SelectedItem;

            if (string.IsNullOrWhiteSpace(img.ImagenUrl))
            {
                pictureBox1.Image = null;
                return;
            }

            try
            {
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = img.ImagenUrl;
                pictureBox1.LoadAsync();
            }
            catch
            {
                pictureBox1.Image = null;
            }





        }
    }
}

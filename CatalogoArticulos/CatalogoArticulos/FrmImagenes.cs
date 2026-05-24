using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoArticulos
{
    public partial class FrmImagenes : Form
    {

        private int idArticulo ;
        private List<Imagen> listaImagenes= new List<Imagen>();
        public bool ModoEditar = false;
        private bool cargando = true;



        public FrmImagenes(int idArticulo)
        {

            InitializeComponent();
            this.idArticulo = idArticulo;


        }
        public FrmImagenes()
        {

            InitializeComponent();
            


        }

        private void FrmImagenes_Load_1(object sender, EventArgs e)
        {
            CargarImagenes();

            txtUrl.Clear();
            pictureBox1.Image = null;

        }

        private void CargarImagenes()
        {


            ImagenNegocio negocio = new ImagenNegocio();

            listaImagenes = negocio.ListarPorArticulo(idArticulo);

            lstImagenes.DataSource = null;
            lstImagenes.DataSource = listaImagenes;

            lblTotal.Text = $"Total: {listaImagenes.Count} imagen(es)";

            if (listaImagenes.Count > 0)
            {
                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.LoadAsync(listaImagenes[0].ImagenUrl);
                }
                catch
                {
                    pictureBox1.Image = null;
                }

                // ✅ IMPORTANTE: forzar selección visible
                lstImagenes.SelectedIndex = 0;
                lstImagenes.Refresh(); // 🔥 esto ayuda a que el evento responda bien
            }
            else
            {
                pictureBox1.Image = null;
            }




        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("Ingrese una URL de imagen.");
                return;
            }
            // 3. Validar el largo de la URL (el problema de la imagen gigante)
            if (txtUrl.Text.Length > 1000) 
            {
                MessageBox.Show("El texto es demasiado largo para la base de datos.");
                return;
            }

            Imagen img = new Imagen();
            img.ImagenUrl = txtUrl.Text;
            img.IdArticulo = idArticulo;   

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
            ActualizarTotal();

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

            if (cargando) return;

            if (lstImagenes.SelectedItem == null)
            {
                pictureBox1.Image = null;
                return;
            }

            Imagen img = (Imagen)lstImagenes.SelectedItem;

            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

          
                pictureBox1.ImageLocation = null;
                pictureBox1.Image = null;

                pictureBox1.ImageLocation = img.ImagenUrl;
            }
            catch
            {
                pictureBox1.Image = null;
            }

            if (ModoEditar)
            {
                txtUrl.Text = img.ImagenUrl;
            }


        }
        private void lblArticulo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstImagenes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una imagen de la lista.");
                return;
            }

            try
            {
                // Obtenemos la imagen de la lista
                Imagen seleccionada = (Imagen)lstImagenes.SelectedItem;

                // Le pasamos el nuevo texto del cuadro de texto
                seleccionada.ImagenUrl = txtUrl.Text;

                // Guardamos en DB
                ImagenNegocio negocio = new ImagenNegocio();
                negocio.Modificar(seleccionada);

                CargarImagenes();
                txtUrl.Clear();
                MessageBox.Show("Imagen modificada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar modificar: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Imagen guardados con éxito.");
            this.Close();
        }

        private void lstImagenes_Click(object sender, EventArgs e)
        {

            if (lstImagenes.SelectedItem == null)
                return;

            Imagen img = (Imagen)lstImagenes.SelectedItem;

            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

          
                pictureBox1.ImageLocation = null;
                pictureBox1.Image = null;

                pictureBox1.ImageLocation = img.ImagenUrl;
            }
            catch
            {
                pictureBox1.Image = null;
            }

            if (ModoEditar)
            {
                txtUrl.Text = img.ImagenUrl;
            }

        }
    }
}

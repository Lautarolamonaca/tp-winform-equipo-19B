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
        }

        private void CargarImagenes()
        {

            ImagenNegocio negocio = new ImagenNegocio();
            lstImagenes.DataSource = negocio.Listar();
           
            //listaImagenes = negocio.Listar();

            //lstImagenes.DataSource = null;
            //lstImagenes.DataSource = listaImagenes;
            //lstImagenes.DisplayMember = "ImagenUrl";
                
            lstImagenes.DataSource = negocio.ListarPorArticulo(idArticulo);
                    
            lblTotal.Text = $"Total: {listaImagenes.Count} imagen(es)";
                                 
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


            if (lstImagenes.SelectedItem == null)
                return;

            Imagen img = (Imagen)lstImagenes.SelectedItem;

            // Validar URL
            if (string.IsNullOrWhiteSpace(img.ImagenUrl))
            {
                pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJQeJyzgAzTEVqXiGe90RGBFhfp_4RcJJMQ&s");
                return;
            }

            try
            {
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Load(img.ImagenUrl); // UNA sola carga
            }
            catch
            {
                pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJQeJyzgAzTEVqXiGe90RGBFhfp_4RcJJMQ&s");


            }
        }  
        private void lblArticulo_Click(object sender, EventArgs e)
        {

        }
    }
}

using Accesodatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> Listar()
        {

            List<Imagen> lista = new List<Imagen>();
             AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)datos.Lector["Id"];
                    img.IdArticulo = (int)datos.Lector["IdArticulo"];
                    img.ImagenUrl = datos.Lector["ImagenUrl"].ToString();
                    lista.Add(img);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }

         



        }

        public List<Imagen> ListarPorArticulo(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT Id, IdArticulo, ImagenUrl " +
                    "FROM IMAGENES " +
                    "WHERE IdArticulo = @IdArticulo");

                datos.agregarParametro("@IdArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id = (int)datos.Lector["Id"];
                    img.IdArticulo = (int)datos.Lector["IdArticulo"];
                    img.ImagenUrl = datos.Lector["ImagenUrl"].ToString();

                    lista.Add(img);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


        public void Agregar(Imagen nueva)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)"
                );

                datos.agregarParametro("@IdArticulo", nueva.IdArticulo);
                datos.agregarParametro("@ImagenUrl", nueva.ImagenUrl);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void EliminarPorArticulo(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo"
                );
                datos.agregarParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Modificar(Imagen imagen)
        {
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = @id");
                datos.agregarParametro("@ImagenUrl", imagen.ImagenUrl);
                datos.agregarParametro("@id", imagen.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE Id = @id");
                datos.agregarParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

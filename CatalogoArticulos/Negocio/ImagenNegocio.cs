using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Accesodatos;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> Listar()
        {
            var lista = new List<Imagen>();
            var _articulo = new Articulo();
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id.I, ImagenUrl.I FROM IMAGENES I, ARTICULOS A WHERE IdArticulo.I = @Id.A");
                datos.agregarParametro("@Id.A", _articulo.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.ImagenUrl = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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

        public void Agregar(Imagen nueva)
        {
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (ImagenUrl, IdArticulo) VALUES (@ImagenUrl, @IdArticulo)");
                datos.agregarParametro("@ImagenUrl", nueva.ImagenUrl);
                datos.agregarParametro("@IdArticulo", nueva.IdArticulo);
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

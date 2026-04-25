using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoArticulos
{
    internal class ImagenNegocio
    {
        public List<Imagen> Listar()
        {
            var lista = new List<Imagen>();
            var _articulo = new Articulo();
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES I, ARTICULOS A WHERE I.IdArticulo = A.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Imagen();
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
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
                datos.setearConsulta("INSERT INTO IMAGENES (ImagenUrl, IdArticulo) VALUES (@imagenurl, @idarticulo)");
                datos.agregarParametro("@imagenurl", nueva.ImagenUrl);
                datos.agregarParametro("@idarticulo", nueva.IdArticulo);
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
                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @imagenurl WHERE Id = @id");
                datos.agregarParametro("@imagenurl", imagen.ImagenUrl);
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

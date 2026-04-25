using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoArticulos
{
    internal class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            var lista = new List<Articulo>();
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion, C.Descripcion, A.Precio FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE C.Id = A.IdCategoria AND M.Id = A.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Nombre = (string)datos.Lector["IdMarca"];
                    aux.Nombre = (string)datos.Lector["IdCategoria"];

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

        public void Agregar(Articulo nuevo)
        {
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Articulo (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@codigo, @nombre, @descripcion, @idmarca, @idcategoria, @precio)");
                datos.agregarParametro("@codigo", nuevo.Codigo);
                datos.agregarParametro("@nombre", nuevo.Nombre);
                datos.agregarParametro("@descripcion", nuevo.Descripcion);
                datos.agregarParametro("@idmarca", nuevo.Marca.Id);
                datos.agregarParametro("@idcategoria", nuevo.Categoria.Id);
                datos.agregarParametro("@precio", nuevo.Precio);
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

        public void Modificar(Articulo articulo)
        {
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, Precio = @precio  WHERE Id = @id");
                datos.agregarParametro("@codigo", articulo.Codigo);
                datos.agregarParametro("@nombre", articulo.Nombre);
                datos.agregarParametro("@descripcion", articulo.Descripcion);
                datos.agregarParametro("@idmarca", articulo.Marca.Id);
                datos.agregarParametro("@idcategoria", articulo.Categoria.Id);
                datos.agregarParametro("@precio", articulo.Precio);
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
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
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

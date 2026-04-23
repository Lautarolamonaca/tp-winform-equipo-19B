using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoArticulos
{
    internal class AccesoDatos
    {


        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }

        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("Server=localhost,1433;Database=CATALOGO_P3_DB;User Id=sa;Password=Maycol-123456;TrustServerCertificate=True");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }




    }
}
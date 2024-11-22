using MotorsApi.Models;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotorsApi.BD.CRUD.Read
{
    public class SeguroRead : Conexiondb
    {
        public List<SeguroRequest> ObtenerListaSeguros() //Retorna una lista de los seguros, no muestra id_seguro
        {
            List<SeguroRequest> lista = new List<SeguroRequest>();

            try
            {
                

                //Limpiamos los parámetros solo por si acaso
                cmd.Parameters.Clear();

                //Definimos el tipo de comando que se mandará a la Base de Datos
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "SELECT tipo_seguro, precio, descripcion FROM seguros"; //Definimos el texto que se envía a la Base de Datos

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Hacemos un objeto de tipo SeguroRequest para 
                        SeguroRequest seguro = new SeguroRequest()
                        {
                            tipo_seguro = reader["tipo_seguro"].ToString(),
                            precio = Convert.ToDouble(reader["precio"]),
                            descripcion = reader["descripcion"].ToString()
                        };
                        // Añadimos el Objeto a la lista
                        lista.Add(seguro);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine("Error: " + e); }
            finally { cerrarConexion(); }
            return lista;
        }
    }
}

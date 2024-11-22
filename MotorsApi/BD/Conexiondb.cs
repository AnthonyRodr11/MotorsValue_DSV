using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD
{
    public class Conexiondb
    {
        //Atributos de la clase 
        public MySqlConnection conexion;
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter;
        public DataSet ds;

        //Metodo constructor para inicializar los atributos
        public Conexiondb()
        {
            try
            {
                //cadena de conexion por arreglar
                string cadenaConexion = "server=localhost;Port=3306;user id=root;password=12345678;database=MotorsValue;persistsecurityinfo=True";
                conexion = new MySqlConnection(cadenaConexion);
                cmd = new MySqlCommand();
                cmd.Connection = conexion;
            }
            catch (Exception e)
            {

                Console.WriteLine("No se pudo inicializar la cadena de Conexion ");
            }
        }

        public MySqlConnection getConnection()
        {
            return conexion;
        }

        //Metodo para abrir conexion
        public void abrirConexion()
        {

            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("No pudimos conectarnos a la base de datos");
            }
        }

        //Metodo para cerrar conecion a la bd
        public void cerrarConexion()
        {
            try
            {
                if (conexion.State != ConnectionState.Closed)
                {

                    conexion.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("No pudimos cerrar la conexion a la base de datos");
            }
        }


    }
}

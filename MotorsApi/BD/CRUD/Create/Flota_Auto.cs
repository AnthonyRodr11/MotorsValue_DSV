using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Flota_Auto : Conexiondb
    {

        public int registraAutoflota(Flota_Carro regAuto)
        {
            //declaracion de variables de trabajo
            int insercion = 0;

            try
            {
                // Limpiamos parámetros
                cmd.Parameters.Clear();

                // Asignamos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignamos el nombre del procedimiento almacenado
                cmd.CommandText = "sp_registrarAuto";

                // Asignamos los parámetros con nombres que coincidan con el procedimiento
                cmd.Parameters.Add(new MySqlParameter("@p_placa", regAuto.placa));
                cmd.Parameters.Add(new MySqlParameter("@p_marca", regAuto.marca));
                cmd.Parameters.Add(new MySqlParameter("@p_modelo", regAuto.modelo));
                cmd.Parameters.Add(new MySqlParameter("@p_color", regAuto.color));
                cmd.Parameters.Add(new MySqlParameter("@p_km", regAuto.km));
                cmd.Parameters.Add(new MySqlParameter("@p_transmision", regAuto.transmision));
                cmd.Parameters.Add(new MySqlParameter("@p_tipo_gas", regAuto.tipo_gas));
                cmd.Parameters.Add(new MySqlParameter("@p_carroceria", regAuto.carroceria));
                cmd.Parameters.Add(new MySqlParameter("@p_estado", regAuto.estado));
                cmd.Parameters.Add(new MySqlParameter("@p_descripcion", regAuto.descripcion));
                cmd.Parameters.Add(new MySqlParameter("@p_disponibilidad", regAuto.disponibilidad));
                cmd.Parameters.Add(new MySqlParameter("@p_foto", regAuto.foto));

                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = cmd.ExecuteNonQuery();  

                if (insercion > 0)
                {
                    return insercion;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo registrar el Auto" + e.ToString());
            }
            finally
            {
                cerrarConexion();

            }
            return insercion;
        }


    }
}

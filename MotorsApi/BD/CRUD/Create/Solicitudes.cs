using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Solicitudes : Conexiondb
    {

        //Metodo para cargar tabla Solicitud
        public int registrarSolicitud(Solicitud solicito)
        {

            //declaracion de variables de trabajo
            int insercion = 0;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "sp_solicitudAuto"; //poner nombre posteriormente

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@p_id_usuario", solicito.id_usuario));
                cmd.Parameters.Add(new MySqlParameter("@p_descripcion", solicito.descripcion));
                cmd.Parameters.Add(new MySqlParameter("@p_estado", solicito.estado));
                cmd.Parameters.Add(new MySqlParameter("@p_f_solicitud", solicito.f_solicitud));
                cmd.Parameters.Add(new MySqlParameter("@p_foto", solicito.foto));
                cmd.Parameters.Add(new MySqlParameter("@p_monto", solicito.monto));

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
                Console.WriteLine("No se pudo guardar la solicitud"+e);
            }
            finally
            {
                cerrarConexion();
            }
            return insercion;
        }
    }
}

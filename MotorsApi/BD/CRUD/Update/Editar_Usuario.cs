using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class Editar_Usuario : Conexiondb
    {

        public int EditarUsuario(int id, ActualizarUsuario usuario)
        {

            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.StoredProcedure;

                //Asignamos el cod
                cmd.CommandText = "EditarUsuarioLogin";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@p_id_usuario", id));
                cmd.Parameters.Add(new MySqlParameter("@p_telefono", usuario.telefono));
                cmd.Parameters.Add(new MySqlParameter("@p_contraseña", usuario.contraseña));
                cmd.Parameters.Add(new MySqlParameter("@p_correo", usuario.correo));


                //abrir Conexion
                abrirConexion();

                //validamos si se inserto el auto
                insercion = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (insercion > 0)
                {
                    return insercion;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo registrar el Auto" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return 0;
        }



    }
}

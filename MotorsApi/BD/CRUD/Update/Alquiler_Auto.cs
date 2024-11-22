using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Update
{
    public class Alquiler_Auto : Conexiondb
    {
        //Editamos la tarifa respecto al tipo de auto
        public int EditarTarifa(int id, TarifaRequest tarifas_Alquiler)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.Text;

                //asignamos el cod
                cmd.CommandText = "UPDATE Tarifas_Alquiler SET  tarifaxauto = @tarifaxauto WHERE id_tipo = @id_tipo";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@tarifaxauto", tarifas_Alquiler.tarifaxauto));
                cmd.Parameters.Add(new MySqlParameter("@id_tipo", id));


                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                {
                    return insertedId;

                }
                

            }

            catch (Exception e)
            {
                Console.WriteLine("No se pudo registrar el Auto" + e);

            }
            finally
            {
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;
        }

        //Actualiza el estado en el que se encuentra el veehiculo(Vender, alquilar, subastar)
        public int ActualizarEstado(Update_State flota_Carro)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.Text;

                //asignamos el cod
                cmd.CommandText = "UPDATE Flota_Carro SET estado = @estado WHERE placa = @placa";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@estado", flota_Carro.estado));
                cmd.Parameters.Add(new MySqlParameter("@placa", flota_Carro.placa));


                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                {
                    return insertedId;
                }
                    

            }

            catch (Exception e)
            {
                
                Console.WriteLine("No pudo actualizarce" + e);
            }
            finally
            {
                //Cerramos conexion
                cerrarConexion();
            }
            return 0;
        }

    }
}

using MotorsApi.Models;
using MySql.Data.MySqlClient;

using System.Data;


namespace MotorsApi.BD.CRUD.Create
{
    public class CrearTipoTarifa : Conexiondb
    {
       //Metodo para Crear un Nuevo tipo de auto con su respectiva tarifa 
        public int crearnuevotipo( Tarifas_Alquiler tarifas_Alquiler)
        {
            //declaracion de variables de trabajo
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO Tarifas_Alquiler (tipo_auto,tarifaxauto) VALUES (@tipo_auto,@tarifaxauto)"; 

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@tipo_auto", tarifas_Alquiler.tipo_auto));
                cmd.Parameters.Add(new MySqlParameter("@tarifaxauto", tarifas_Alquiler.tarifaxauto));
               
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
            return insercion = 0;
        }
    }
}

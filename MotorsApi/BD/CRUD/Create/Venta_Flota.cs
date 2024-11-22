using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class Venta_Flota : Conexiondb
    {
        public int registrarVenta(Flota_Venta flota_Venta)
        {
            //declaracion de variable de trabajo 
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO Flota_Venta (placa, precio) VALUES(@placa,@precio)"; //poner nombre posteriormente

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@placa", flota_Venta.placa));
                cmd.Parameters.Add(new MySqlParameter("@precio", flota_Venta.precio));




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


        //Metodo para agregar registro de venta
        public int VenderCarro(int id, Ventas vendido) 
        {
            int insercion;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo codigo 
                cmd.CommandType = CommandType.Text;

                //asignamos el nombre del procedimiento de almacendo
                cmd.CommandText = "INSERT INTO ventas VALUES (@venta_id, @id_cliente, @id_vehiculo, @f_compra, @total)";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@venta_id", id));
                cmd.Parameters.Add(new MySqlParameter("@id_cliente", vendido.id_cliente));
                cmd.Parameters.Add(new MySqlParameter("@id_vehiculo", vendido.id_vehiculo));
                cmd.Parameters.Add(new MySqlParameter("@f_compra", vendido.f_compra));
                cmd.Parameters.Add(new MySqlParameter("@total", vendido.total));




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


        //Metodo para cambiar la disponibilidad de un carro
        public int CambiarDisponibilidad(string placa, bool dispo)
        {
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //asignamos el tipo
                cmd.CommandType = CommandType.Text;

                //asignamos el cod
                cmd.CommandText = "UPDATE Flota_Carro SET disponibilidad = @disponibilidad WHERE placa = @placa";

                //asignamos parametros
                cmd.Parameters.Add(new MySqlParameter("@placa", placa));
                cmd.Parameters.Add(new MySqlParameter("@disponibilidad", dispo));


                //Abrimos conexion
                abrirConexion();

                //Validacion de Actualizacion
                int insertedId = cmd.ExecuteNonQuery();
                if (insertedId > 0)
                {
                    return insertedId;
                }


            }

            catch (Exception e)
            {

                Console.WriteLine("No pudo actualizarse" + e);
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

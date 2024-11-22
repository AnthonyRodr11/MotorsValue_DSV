using System.Data;
using MotorsApi.Models;
using System.Numerics;
using MySql.Data.MySqlClient;
namespace MotorsApi.BD.CRUD.Read
{
    public class Informes : Conexiondb
    {
        //Metodo para retornar la data para el  archivo .txt coon informe de flota
        public string[] infoFlota()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT placa,marca,modelo,color,km,transmision,tipo_gas,carroceria FROM Flota_Carro";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                            reader["placa"].ToString(),
                            reader["marca"].ToString(),
                            reader["modelo"].ToString(),
                            reader["color"].ToString(),
                            reader["km"].ToString(),
                            reader["transmision"].ToString(),
                            reader["tipo_gas"].ToString(),
                            reader["carroceria"].ToString()
                        );

                        // Añadimos la fila a la lista
                        data.Add(row);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }
        
        //Metodo que guarda registros de la tabla ventas
        public async Task<string[]> InfoVentas()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el codigo
                cmd.CommandText = "ObtenerInfoVentas";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        // Comprobamos si algún valor es nulo antes de procesarlo
                        string row = string.Join(";",
                            reader["ID_Venta"]?.ToString() ?? "N/A",    // Usamos "N/A" o un valor por defecto en caso de nulos
                            reader["Nombre_Cliente"]?.ToString() ?? "Desconocido",
                            reader["Fecha_Compra"]?.ToString() ?? "Sin Fecha",
                            reader["Placa"]?.ToString() ?? "Desconocida",
                            reader["Total"]?.ToString() ?? "0.00"
                        );

                        // Añadimos la fila a la lista
                        data.Add(row);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }

        //Metodo que guarda registros de la tabla Alquiler
        public string[] infoAlquiler()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos el codigo
                cmd.CommandText = "SELECT    cod_alquiler,    id_vehiculo,   id_usuario,    tipo_tarifa,    f_retiro,   f_entrega,    total   FROM     Flota_Alquiler;";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                            reader["cod_alquiler"].ToString(),
                            reader["id_vehiculo"].ToString(),
                            reader["id_usuario"].ToString(),
                            reader["tipo_tarifa"].ToString(),
                            reader["f_retiro"].ToString(),
                            reader["f_entrega"].ToString(),
                            reader["total"].ToString()

                        );

                        // Añadimos la fila a la lista
                        data.Add(row);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }

        //Metodo que guarda registro e de la tabla subasta 
        public string[] infoSubastas()
        {
            List<string> data = new List<string>();

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_obtenerSubastas";

                abrirConexion();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                      
                        string row = string.Join(";",
                           reader["cod_subasta"].ToString(),
                           reader["valor_inicial"].ToString(),
                           reader["id_placa"].ToString(),
                           reader["valor_puja"].ToString(),
                           reader["id_usuario"].ToString(),
                           reader["nombre"].ToString(),
                           reader["apellido"].ToString(),
                           reader["estado"].ToString(),
                           reader["t_inicio"].ToString(),
                           reader["t_final"].ToString()
                        );

                        data.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta: " + e.Message);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();
        }




        //Este metodo Guarda todos los registros de la tabla solicitud 
        public string[] infoSolicitudes()
        {
            List<string> data = new List<string>();

            try
            {
                //limpiamos los parametros
                cmd.Parameters.Clear();

                //asignamos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                //asignamos el codigo
                cmd.CommandText = "sp_obtener_solicitudes";

                // Abrimos la conexión
                abrirConexion();

                // Ejecutamos la consulta
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construimos una cadena con los valores separados por ;
                        string row = string.Join(";",
                              reader["id_solicitud"].ToString(),  
                              reader["nombre_cliente"].ToString(), 
                              reader["estado"].ToString(),         
                              reader["f_solicitud"].ToString(),    
                              reader["monto"].ToString()

                        );

                        // Añadimos la fila a la lista
                        data.Add(row);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo realizar la consulta" + e);
            }
            finally
            {
                cerrarConexion();
            }

            return data.ToArray();

        }














    }

}

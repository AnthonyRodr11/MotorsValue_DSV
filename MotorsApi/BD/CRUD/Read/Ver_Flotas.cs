using MotorsApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Read
{
    public class Ver_Flotas : Conexiondb
    {

        //Metodo para devolver una lista segun su estado <Alquiler,venta,Subasta>
        public List<string> tipos_Flota(string estado)
        {
            List<string> autos = new List<string>();
            string data;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT placa, marca, modelo FROM Flota_Carro WHERE estado = @estado";

                // Agregamos el parámetro estado
                cmd.Parameters.AddWithValue("@estado", estado);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Agregamos cada vehiculo a la lista
                        data = $"Placa: {reader["placa"]}, Marca: {reader["marca"]}, Modelo: {reader["modelo"]}";
                        autos.Add(data);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo cargar la lista de autos" + e);
            }
            finally
            {

                cerrarConexion();
            }
            return autos;
        }

        //Metodo para cargar toda la flota
        public List<Flota_Carro> obtenerFlota()
        {
            List<Flota_Carro> autos = new List<Flota_Carro>();
            string data;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT * from  flota_carro";


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //creamos objeto
                        Flota_Carro flota = new Flota_Carro()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            color = reader["color"].ToString(),
                            km = Convert.ToDouble(reader["color"]),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            estado = reader["estado"].ToString(),
                            descripcion = reader["descripcion"].ToString(),
                            disponibilidad = Convert.ToBoolean(reader["disponibilidad"]),
                            foto = reader.ToString()

                        };

                        autos.Add(flota);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo cargar la lista de autos" + e);
            }
            finally
            {

                cerrarConexion();
            }
            return autos;
        }

        //Metodo para cargar toda la flota en venta
        public List<Flota_CarroRequest> ObtenerAutos(string estado)
        {
            List<Flota_CarroRequest> autos = new List<Flota_CarroRequest>();
            string data;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT  placa,  marca,  modelo,  color,  km,   transmision,   tipo_gas,   carroceria,   estado,    descripcion,    foto   FROM Flota_Carro  WHERE estado = @estado";

                // Agregamos el parámetro estado
                cmd.Parameters.AddWithValue("@estado", estado);


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //creamos objeto
                        Flota_CarroRequest flota = new Flota_CarroRequest()
                        {
                            placa = reader["placa"].ToString(),
                            marca = reader["marca"].ToString(),
                            modelo = reader["modelo"].ToString(),
                            color = reader["color"].ToString(),
                            km = Convert.ToDouble(reader["km"]),
                            transmision = reader["transmision"].ToString(),
                            tipo_gas = reader["tipo_gas"].ToString(),
                            carroceria = reader["carroceria"].ToString(),
                            estado = reader["estado"].ToString(),
                            descripcion = reader["descripcion"].ToString(),
                            foto = reader["foto"].ToString()

                        };

                        autos.Add(flota);
                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {

                cerrarConexion();
            }
            return autos;
        }

        public List<Tarifas_Alquiler> ObtenerTarifas()
        {
            List<Tarifas_Alquiler> alquileres = new List<Tarifas_Alquiler>();

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT * from tarifas_alquiler";


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //creamos objeto
                        Tarifas_Alquiler alquiler = new Tarifas_Alquiler()
                        {
                            id_tipo = Convert.ToInt32(reader["id_tipo"]),
                            tipo_auto = reader["tipo_auto"].ToString(),
                            tarifaxauto = Convert.ToDouble(reader["tarifaxauto"])
                        };

                        alquileres.Add(alquiler);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo cargar la lista de autos" + e);
            }
            finally
            {

                cerrarConexion();
            }
            return alquileres;
        }

        //Metodo para obtener la lista de tipo de autos segun carroceria para venta, alquiler, subasta
        public List<string> listaCarroceria(string estado)
        {
            List<string> carroceria = new List<string>();
            string tipo = string.Empty;

            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT DISTINCT carroceria FROM Flota_Carro WHERE estado = @estado";

                // Agregamos el parámetro estado
                cmd.Parameters.AddWithValue("@estado", estado);

                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        tipo = reader["carroceria"].ToString();
                        carroceria.Add(tipo);
                    }

                }
            }
            catch (Exception e)
            {

                throw;

            }
            finally
            {

                cerrarConexion();
            }
            return carroceria;
        }


        //Metodo oferta actual
        public double obtenerOfertaActual(int cod_subasta)
        {

            double valor = 0;
            try
            {
                //Limpiamos parametros
                cmd.Parameters.Clear();

                //Especificamos el tipo de comando
                cmd.CommandType = CommandType.Text;

                //asignamos consulta a realizar
                cmd.CommandText = "SELECT   valor_inicial   FROM Flota_Subasta WHERE cod_subasta = @cod_subasta ";

                //Agregar parametro cos_subasta
                cmd.Parameters.AddWithValue("@cod_subasta", cod_subasta);


                abrirConexion();


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         valor = reader.GetDouble(0);
                    };

                    return valor;

                }
            }
            catch (Exception e) { 
                
                
                throw; }

            finally { cerrarConexion(); }
            return valor;
            
        }

    }
}

            





        

    


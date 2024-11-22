using MySql.Data.MySqlClient;
using System.Data;

namespace MotorsApi.BD.CRUD.Create
{
    public class FlotaAlquilerInsert : Conexiondb
    {

        public int InsertarAlquilado()
        {
            try
            {
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"INSERT INTO (id_vehiculo, id_usuario, tarifa, f_retiro, f_entrega, id_seguro) VALUES 
                                  (@id_vehiculo, @id_usuario, @tarifa, @f_retiro, @f_entrega, @id_seguro)";

                cmd.Parameters.Add(new MySqlParameter("@id_vehiculo", id_vehiculo));
                cmd.Parameters.Add(new MySqlParameter("@id_usuario", id_usuario));
                cmd.Parameters.Add(new MySqlParameter("@tarifa", tarifa));
                cmd.Parameters.Add(new MySqlParameter("@f_retiro", f_retiro));
                cmd.Parameters.Add(new MySqlParameter("@f_entrega", f_entrega));
                cmd.Parameters.Add(new MySqlParameter("@id_seguro", id_seguro));

                var guardar = cmd.ExecuteNonQuery();
                if (guardar > 0)
                    return guardar;
            }
            catch (Exception e){ Console.WriteLine("Error " + e); }
            finally { cerrarConexion(); }

            return 0;
        }

    }
}

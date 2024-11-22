using Org.BouncyCastle.Bcpg.OpenPgp;

namespace MotorsApi.Models
{
    public class Solicitud
    {
        //Atributos de la entidad
        public int id_solicitud { get; set; }
        public int id_usuario { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public DateTime f_solicitud { get; set; }
        public string foto { get; set; }
        public double monto { get; set; }


    }
}

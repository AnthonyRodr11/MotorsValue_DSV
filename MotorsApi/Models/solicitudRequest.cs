namespace MotorsApi.Models
{
    public class solicitudRequest
    {
        //Atributos 
 
        public int id_solicitud { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string estado { get; set; }
        public DateTime f_solicitud { get; set; }
        public double monto { get; set; }


    }
}

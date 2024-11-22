namespace MotorsApi.Models
{
    public class Usuario
    {

        //Atributos de la entidad
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string identificacion { get; set; }
        public string telefono { get; set; }
        public DateTime f_creacion {  get; set; }
        public DateTime f_actualizacion { get; set;}
    }
}

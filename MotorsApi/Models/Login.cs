namespace MotorsApi.Models
{
    public class Login
    {
        //Atributos de la entidad
        public int id_usuario { get; set; }
        public string contraseña  { get; set; }
        public int rol { get; set; }
        public string correo { get; set; }
        
       
    }
}

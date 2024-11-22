using System.Runtime.CompilerServices;

namespace MotorsApi.Models
{
    public class RegistroUsuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string identificacion { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public int rol {  get; set; }
        public string correo { get; set; }
    }
}

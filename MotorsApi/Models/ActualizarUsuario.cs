using System.ComponentModel.DataAnnotations;

namespace MotorsApi.Models
{
    public class ActualizarUsuario
    {
        public string? telefono { set; get; }
        public string? correo { set; get; }
        public string? contraseña {  set; get; }
    }
}

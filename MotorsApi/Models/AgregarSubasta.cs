namespace MotorsApi.Models
{
    public class AgregarSubasta
    {
        public double valor_inicial {  get; set; }
        public string id_placa {  get; set; }
        public DateTime t_inicio { get; set; }
        public DateTime t_final {  get; set; }
    }
}

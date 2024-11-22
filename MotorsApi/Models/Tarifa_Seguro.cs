namespace MotorsApi.Models
{
    public class Tarifa_Seguro
    {
        public int id_seguro {  get; set; }
        public string tipoSeguro { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
    }
}

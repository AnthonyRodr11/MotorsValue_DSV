namespace MotorsApi.Models
{
    public class Flota_Alquiler
    {
        //Atributos de la entidad

        public int cod_alquiler { get; set; }
        public string id_vehiculo { get; set; }
        public int id_usuario { get; set; }
        public int tipo_tarifa { get; set; }
        public DateTime f_retiro { get; set; }
        public DateTime f_entrega  { get; set; }
        public double total { get; set; }
        public string nombreSeguro {  get; set; }
        
    }
}

namespace MotorsApi.Models
{
    public class Flota_Subasta
    {

        //atributos de entidad

        public int cod_subasta {  get; set; }
        public double valor_inicial { get; set; }
        public string id_placa { get; set; }
        public double valor_puja {  get; set; }
        public int id_usuario { get; set; }
        public string estado {  get; set; }
        public DateTime t_inicio {  get; set; }
        public DateTime t_final {  get; set; }

    }
}

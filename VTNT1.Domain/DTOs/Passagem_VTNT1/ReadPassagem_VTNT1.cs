namespace VTNT1.Domain.DTOs.Passagem_VTNT1
{
    public class ReadPassagem_VTNT1
    {
        public decimal TempoPercorrido { get; set; }

        public decimal DistanciaPercorrido { get; set; }

        public ReadPassagemFaseCafe_VTNT1 QuatidadeCafe { get; set; }
    }
}
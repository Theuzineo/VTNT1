namespace VTNT1.Domain.DTOs.Passagem_VTNT1
{
    public class ReadRouteVTNT1
    {
        public decimal TempoPercorrido { get; set; }

        public decimal DistanciaPercorrido { get; set; }

        public ReadRouteFaseCafeVTNT1? QuatidadeCafe { get; set; }
    }
}
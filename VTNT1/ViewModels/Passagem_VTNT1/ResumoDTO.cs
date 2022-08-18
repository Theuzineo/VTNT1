namespace VTNT1.ViewModels.Passagem_VTNT1
{
    public class ResumoDTO
    {
        public int FaseCafeID { get; set; }

        public int Verde { get; set; }

        public int Amarelo { get; set; }

        public int Maduro { get; set; }

        public int Passando { get; set; }

        public int Seco { get; set; }
        public int PassagemID { get; set; }
            
        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public decimal Distancia { get; set; }

        public int Total { get; set; }

    }
}

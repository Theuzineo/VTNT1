using VTNT1.Models;

namespace VTNT1.ViewModels.Passagem_VTNT1
{
    public class CreatePassagem_VTNT1_DTO
    {

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public decimal Distancia { get; set; }

        public CreateFaseCafe_DTO? FaseCafe { get; set; }

    }
}

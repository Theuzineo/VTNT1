using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTNT1.Domain.DTOs.Passagem_VTNT1
{
    public class CreateRouteVTNT1_DTO
    {
        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public decimal Distancia { get; set; }

        public CreateFaseCafe_DTO? FaseCafe { get; set; }
    }
}

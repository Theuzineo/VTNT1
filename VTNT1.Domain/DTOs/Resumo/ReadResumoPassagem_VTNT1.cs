using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTNT1.Domain.DTOs.Resumo
{
    public class ReadResumoPassagem_VTNT1
    {
        public decimal TempoPercorrido { get; set; }

        public decimal DistanciaPercorrido { get; set; }

        public ReadResumoFaseCafe PercentagemCafe { get; set; }
    }
}

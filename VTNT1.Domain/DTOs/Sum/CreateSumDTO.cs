using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTNT1.Domain.DTOs.Resumo
{
    public class CreateSumDTO
    {
        public int FaseCafeID { get; set; }

        public int Verde { get; set; }

        public int Vermelho { get; set; }

        public int Marrom { get; set; }

        public int Chumbinho { get; set; }

        public int PassagemID { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public decimal Distancia { get; set; }

        public int Total { get; set; }
    }
}

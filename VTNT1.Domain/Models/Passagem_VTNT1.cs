using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTNT1.Domain.Models
{
    public class Passagem_VTNT1
    {
        [Key]
        [Required]
        public int PassagemID { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Fim { get; set; }

        [Required]
        public decimal Distancia { get; set; }


        public FaseCafe FaseCafe { get; set; }
        public int FaseCafeID { get; set; }
    }
}

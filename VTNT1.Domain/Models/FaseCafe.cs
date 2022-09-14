using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTNT1.Domain.Models
{
    public class FaseCafe
    {
        [Key]
        [Required]
        public int FaseCafeID { get; set; }

        public int Verde { get; set; }

        public int Vermelho { get; set; }

        public int Marrom { get; set; }

        public int Chumbinho { get; set; }


        public RouteVTNT1 Passagem_VTNT1 { get; set; }
    }
}

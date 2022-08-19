using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTNT1.Models
{
    public class FaseCafe
    {

        [Key]
        [Required]
        public int FaseCafeID { get; set; }

        public int Verde { get; set; }

        public int Amarelo { get; set; }

        public int Maduro { get; set; }

        public int Passado { get; set; }

        public int Seco { get; set; }


        public Passagem_VTNT1 Passagem_VTNT1 { get; set; }

    }
}

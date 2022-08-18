using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTNT1.Models
{
    public class FaseCafe
    {
        public int FaseCafeID { get; set; }

        public int Verde { get; set; }

        public int Amarelo { get; set; }

        public int Maduro { get; set; }

        public int Passando { get; set; }

        public int Seco { get; set; }

        
        [ForeignKey("PassagemID")]
        public int PassagemID { get; set; }

    }
}

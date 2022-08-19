using VTNT1.Domain.DTOs.Resumo;
using VTNT1.Domain.Models;
using VTNT1.Infra.Data;

namespace VTNT1.Services.Services
{
    public class Resumo_VTNT1Service
    {
        private AppDbContext _context;

        public Resumo_VTNT1Service(AppDbContext context)
        {
            _context = context;
        }

        public ReadResumoPassagem_VTNT1 ResumoMensalPassagem_VTNT1(int mes, int ano)
        {
            var date = DateTime.Now;

            var teste = date.Year;

            var list = (from resumo in _context.tb_PassagemsVTNT1
                        join cafe in _context.tb_FasesCafe on resumo.FaseCafeID equals cafe.FaseCafeID
                        where resumo.Inicio.Year.Equals(ano)
                        && resumo.Inicio.Month.Equals(mes)
                        select new CreateResumoDTO
                        {
                            Amarelo = cafe.Amarelo,
                            Maduro = cafe.Maduro,
                            Seco = cafe.Seco,
                            Verde = cafe.Verde,
                            Passando = cafe.Passado,
                            Distancia = resumo.Distancia,
                            Fim = resumo.Fim,
                            Inicio = resumo.Inicio,

                            Total = cafe.Seco + cafe.Amarelo + cafe.Maduro + cafe.Verde + cafe.Passado
                        }).ToList();
            if (list.Count <= 0) return null;


            var resumoMensal = new ReadResumoPassagem_VTNT1()
            {
                DistanciaPercorrido = list.Sum(d => d.Distancia),
                TempoPercorrido = list.Sum(t => t.Fim.Hour - t.Inicio.Hour),
                PercentagemCafe = new ReadResumoFaseCafe()
                {
                    Amarelo = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Amarelo)),
                    Maduro = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Maduro)),
                    Passando = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Passando)),
                    Seco = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Seco)),
                    Verde = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Verde)),
                }
            };


            return resumoMensal;
        }

        //public List<Passagem_VTNT1> ResumoPassagem_VTNT1()
        //{
        //    var resumo = _context.tb_PassagemsVTNT1.ToList();
            
        //    //var readResumo = new ReadResumoPassagem_VTNT1
        //    //{
        //    //    DistanciaPercorrido = resumo.Distancia,
        //    //    TempoPercorrido = resumo.Fim.Hour - resumo.Inicio.Hour,
        //    //    PercentagemCafe = new()
        //    //    {
        //    //        Amarelo = cafe.Amarelo,
        //    //        Verde = cafe.Verde,
        //    //        Maduro = cafe.Maduro,
        //    //        Passando = cafe.Passado,
        //    //        Seco = cafe.Seco
        //    //    }
        //    //};
        //    return resumo;
        //}


        private decimal getPorcentagemCafeMes(decimal total, decimal espc)
        {
            return Math.Round((espc * 100) / total, 2);
        }
    }
}

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

        public ReadResumoPassagem_VTNT1? ResumoMensalPassagem_VTNT1(int mes, int ano)
        {
            var date = DateTime.Now;

            var teste = date.Year;

            var list = (from resumo in _context.tb_PassagemsVTNT1
                        join cafe in _context.tb_FasesCafe on resumo.FaseCafeID equals cafe.FaseCafeID
                        where resumo.Inicio.Year.Equals(ano)
                        && resumo.Inicio.Month.Equals(mes)
                        select new CreateResumoDTO
                        {
                            Verde = cafe.Verde,
                            Vermelho = cafe.Vermelho,
                            Marrom = cafe.Marrom,
                            Chumbinho = cafe.Chumbinho,
                            Distancia = resumo.Distancia,
                            Fim = resumo.Fim,
                            Inicio = resumo.Inicio,

                            Total = cafe.Chumbinho + cafe.Marrom + cafe.Vermelho + cafe.Verde
                        }).ToList();
            if (list.Count <= 0) return null;


            var resumoMensal = new ReadResumoPassagem_VTNT1()
            {
                DistanciaPercorrido = list.Sum(d => d.Distancia),
                TempoPercorrido = list.Sum(t => t.Fim.Hour - t.Inicio.Hour),
                PercentagemCafe = new ReadResumoFaseCafe()
                {
                    Verde = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Verde)),
                    Vermelho = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Vermelho)),
                    Marrom = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Marrom)),
                    Chumbinho = getPorcentagemCafeMes(list.Sum(x => x.Total), list.Sum(d => d.Chumbinho))

                }
            };
            return resumoMensal;
        }

        private decimal getPorcentagemCafeMes(decimal total, decimal espc)
        {
            return Math.Round((espc * 100) / total, 2);
        }
    }
}

using AutoMapper;
using FluentResults;
using System.Linq;
using VTNT1.Data;
using VTNT1.Models;
using VTNT1.ViewModels.Passagem_VTNT1;

namespace VTNT1.Services
{
    public class Passagem_VTNT1Service
    {
        private AppDbContext _context;

        public Passagem_VTNT1Service(AppDbContext context)
        {
            _context = context;
        }

        public Result NovaPassagem_VTNT1(Passagem_VTNT1_DTO passagem)
        {
            _ = new Passagem_VTNT1()
            {
                Inicio = passagem.Inicio,
                Fim = passagem.Fim,
                Distancia = passagem.Distancia,
                FaseCafe = passagem.FaseCafe,
            };

            return Result.Ok();
        }

        public ResumoPassagem_VTNT1 ResumoPassagem_VTNT1(string mes, string ano)
        {
            var list = (from resumo in _context.tb_PassagemsVTNT1
                        join cafe in _context.tb_FasesCafe on  resumo.FaseCafe.FaseCafeID equals cafe.FaseCafeID
                        where resumo.Inicio.Year.Equals(ano)
                        && resumo.Inicio.Month.Equals(mes)
                        select new ResumoDTO
                        {
                            Amarelo = cafe.Amarelo,
                            Maduro = cafe.Maduro,
                            Seco = cafe.Seco,
                            Verde = cafe.Verde,
                            Passando = cafe.Passando,
                            Distancia = resumo.Distancia,
                            Fim = resumo.Fim,
                            Inicio = resumo.Inicio,

                            Total = cafe.Seco + cafe.Amarelo + cafe.Maduro + cafe.Verde + cafe.Passando
                        }).ToList();
            if (list.Count <= 0) return null;


            var resumoMensal = new ResumoPassagem_VTNT1()
            {
                DistanciaPercorrido = list.Sum(d => d.Distancia),
                TempoPercorrido = list.Sum(t => t.Fim.Hour - t.Inicio.Hour),
                PercentagemCafe = new ResumoFaseCafe()
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

        private decimal getPorcentagemCafeMes(int total, int espc)
        {
            return (espc * 100) / total;
        }

    }
}

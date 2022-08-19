using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTNT1.Domain.DTOs.Passagem_VTNT1;
using VTNT1.Domain.DTOs.Resumo;
using VTNT1.Domain.Models;
using VTNT1.Infra.Data;

namespace VTNT1.Services.Services
{
    public class Passagem_VTNT1Service
    {
        private AppDbContext _context;

        public Passagem_VTNT1Service(AppDbContext context)
        {
            _context = context;
        }

        public Result NovaPassagem_VTNT1(CreatePassagem_VTNT1_DTO passagem)
        {
            var VTNT1 = new Passagem_VTNT1()
            {
                Inicio = passagem.Inicio,
                Fim = passagem.Fim,
                Distancia = passagem.Distancia,
                FaseCafe = new FaseCafe()
                {
                    Verde = passagem.FaseCafe.Verde,
                    Amarelo = passagem.FaseCafe.Amarelo,
                    Maduro = passagem.FaseCafe.Maduro,
                    Passado = passagem.FaseCafe.Passando,
                    Seco = passagem.FaseCafe.Seco
                }
            };

            _context.Add(VTNT1);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadResumoPassagem_VTNT1 ResumoPassagem_VTNT1(int mes, int ano)
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

        private decimal getPorcentagemCafeMes(decimal total, decimal espc)
        {
            return Math.Round((espc * 100) / total, 2);
        }

    }
}

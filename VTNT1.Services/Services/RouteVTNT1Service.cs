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
    public class RouteVTNT1Service
    {
        private AppDbContext _context;

        public RouteVTNT1Service(AppDbContext context)
        {
            _context = context;
        }

        public Result NovaPassagem_VTNT1(CreateRouteVTNT1_DTO passagem)
        {
            var VTNT1 = new RouteVTNT1()
            {
                Inicio = passagem.Inicio,
                Fim = passagem.Fim,
                Distancia = passagem.Distancia,
                FaseCafe = new FaseCafe()
                {
                    Verde = passagem.FaseCafe.Verde,
                    Vermelho = passagem.FaseCafe.Vermelho,
                    Marrom = passagem.FaseCafe.Marrom,
                    Chumbinho = passagem.FaseCafe.Chumbinho
                }
            };

            _context.Add(VTNT1);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadRouteVTNT1 UltimaPassagem_VTNT1()
        {
            var passagem = _context.tb_RouteVTNT1.OrderBy(i => i.PassagemID).LastOrDefault();
            var fase = _context.tb_FasesCafe.FirstOrDefault(f => f.FaseCafeID == passagem.FaseCafeID);

            var ultimaPassagem = new ReadRouteVTNT1()
            {
                DistanciaPercorrido = passagem.Distancia,
                TempoPercorrido = passagem.Fim.Hour - passagem.Inicio.Hour,
                QuatidadeCafe = new ReadRouteFaseCafeVTNT1()
                {
                    Verde = passagem.FaseCafe.Verde,
                    Vermelho = passagem.FaseCafe.Vermelho,
                    Marrom = passagem.FaseCafe.Marrom,
                    Chumbinho = passagem.FaseCafe.Chumbinho
                }
            };

            return ultimaPassagem;
        }
    }
}

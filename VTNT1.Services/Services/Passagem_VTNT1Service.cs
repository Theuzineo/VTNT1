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

        public ReadPassagem_VTNT1 UltimaPassagem_VTNT1()
        {
            var passagem = _context.tb_PassagemsVTNT1.OrderBy(i => i.PassagemID).LastOrDefault();
            var fase = _context.tb_FasesCafe.FirstOrDefault(f => f.FaseCafeID == passagem.FaseCafeID);

            var ultimaPassagem = new ReadPassagem_VTNT1()
            {
                DistanciaPercorrido = passagem.Distancia,
                TempoPercorrido = passagem.Fim.Hour - passagem.Inicio.Hour,
                QuatidadeCafe = new ReadPassagemFaseCafe_VTNT1()
                {
                    Verde = passagem.FaseCafe.Verde,
                    Amarelo = passagem.FaseCafe.Amarelo,
                    Maduro = passagem.FaseCafe.Maduro,
                    Passando = passagem.FaseCafe.Passado,
                    Seco = passagem.FaseCafe.Seco
                }
            };

            return ultimaPassagem;
        }
    }
}

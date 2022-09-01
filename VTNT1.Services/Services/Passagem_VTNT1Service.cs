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
                    Vermelho = passagem.FaseCafe.Vermelho,
                    Marrom = passagem.FaseCafe.Marrom,
                    Chumbinho = passagem.FaseCafe.Chumbinho
                }
            };

            _context.Add(VTNT1);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}

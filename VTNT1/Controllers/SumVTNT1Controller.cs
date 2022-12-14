using Microsoft.AspNetCore.Mvc;
using VTNT1.Services.Services;

namespace VTNT1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SumVTNT1Controller : ControllerBase
    {
        private SumVTNT1Service _resumo_VTNT1Service;

        public SumVTNT1Controller(SumVTNT1Service resumo_VTNT1Service)
        {
            _resumo_VTNT1Service = resumo_VTNT1Service;
        }


        //[HttpGet]
        //public IActionResult ResumoPassagem_VTNT1()
        //{
        //    var resultado = _resumo_VTNT1Service.ResumoPassagem_VTNT1();
        //    if (resultado == null) return NotFound();

        //    return Ok(resultado);
        //}


        [HttpGet("{mes}/{ano}")]
        //[Route("api/resumo")]
        public IActionResult ResumoMensalPassagem_VTNT1(int mes, int ano)
        {
            var resultado = _resumo_VTNT1Service.ResumoMensalPassagem_VTNT1(mes, ano);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using VTNT1.Services;
using VTNT1.ViewModels.Passagem_VTNT1;

namespace VTNT1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Passagem_VTNT1Controller : ControllerBase
    {
        private Passagem_VTNT1Service _passagem_VTNT1Service;

        public Passagem_VTNT1Controller(Passagem_VTNT1Service passagem_VTNT1Service)
        {
            _passagem_VTNT1Service = passagem_VTNT1Service;
        }

        [HttpPost]
        public IActionResult NovaPassagem_VTNT1([FromBody] Passagem_VTNT1_DTO passagem)
        {
            _ = _passagem_VTNT1Service.NovaPassagem_VTNT1(passagem);
            return Ok();
        }

        [HttpGet("{mes}/{ano}")]
        public IActionResult ResumoPassagem_VTNT1(string mes, string ano)
        {
            var resultado = _passagem_VTNT1Service.ResumoPassagem_VTNT1(mes, ano);
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }



    }
}

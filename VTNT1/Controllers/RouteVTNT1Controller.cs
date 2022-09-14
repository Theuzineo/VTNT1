using Microsoft.AspNetCore.Mvc;
using VTNT1.Domain.DTOs.Passagem_VTNT1;
using VTNT1.Services.Services;

namespace VTNT1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RouteVTNT1Controller : ControllerBase
    {
        private RouteVTNT1Service _passagem_VTNT1Service;

        public RouteVTNT1Controller(RouteVTNT1Service passagem_VTNT1Service)
        {
            _passagem_VTNT1Service = passagem_VTNT1Service;
        }

        [HttpPost]
        //[Route("api/passagem")]
        public IActionResult NovaPassagem_VTNT1([FromBody] CreateRouteVTNT1_DTO passagem)
        {
            _ = _passagem_VTNT1Service.NovaPassagem_VTNT1(passagem);
            return Ok();
        }

        [HttpGet]
        public IActionResult UltimaPassagem_VTNT1()
        {
            var resultado = _passagem_VTNT1Service.UltimaPassagem_VTNT1();
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }

    }
}

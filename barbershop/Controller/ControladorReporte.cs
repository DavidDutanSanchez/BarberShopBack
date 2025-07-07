using barbershop.Interface;
using barbershop.model;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorReporte : ControllerBase
    {
        private readonly IControladorReporte _servicio;

        public ControladorReporte(IControladorReporte servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ReporteTickets")]
        public async Task<IActionResult> ObtenerReporteTickets([FromQuery] QueryParams qParams)
        {
            var resultado = await _servicio.ObtenerReporteTicketsAsync(qParams);
            return Ok(resultado);
        }   
       
    }
}
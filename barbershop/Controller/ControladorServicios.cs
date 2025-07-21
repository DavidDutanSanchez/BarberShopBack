using barbershop.Dtos;
using barbershop.Interface;
using barbershop.model;
using barbershop.model.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : SistecControllerBase
    {
        private readonly IControladorServicio _personaService;

        public ServiceController(IControladorServicio personaService)
        {
            _personaService = personaService;
        }
        //CRUD Servicios
        [HttpGet("FindAllServicios")]
        public async Task<ActionResult<PaginationDto<Servicios>>> GetAllServicios([FromQuery] QueryParams qParams)
        {
            PaginationDto<Servicios> pagedResult = await _personaService.AllServicios(qParams);
            return Ok(pagedResult);
        }
        [HttpPut("AddServicios")]
        public async Task<IActionResult> AddServicios([FromBody] Servicios servicios)
        {
            string response = await _personaService.AddServicios(servicios);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateServicios")]
        public async Task<ActionResult> UpdateServicios([FromBody] Servicios servicios)
        {
            string response = await _personaService.UpdateServicios(servicios);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteServicios/{id}")]
        public async Task<ActionResult> DeleteServicios([FromRoute] Guid id)
        {
            string response = await _personaService.DeleteServicios(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
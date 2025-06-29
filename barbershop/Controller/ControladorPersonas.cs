using barbershop.Interface;
using barbershop.model;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : SistecControllerBase
    {
        private readonly IControladorPersona _personaService;

        public PersonasController(IControladorPersona personaService)
        {
            _personaService = personaService;
        }

        //CRUD Personas
        [HttpGet("FindAllPersonas")]
        public async Task<ActionResult<PaginationDto<Personas>>> GetAllPersonas([FromQuery] QueryParams qParams)
        {
            PaginationDto<Personas> pagedResult = await _personaService.AllPersonas(qParams);
            return Ok(pagedResult);
        }

        [HttpPut("AddPersona")]
        public async Task<IActionResult> AddPersonas([FromBody] Personas personas)
        {
            string response = await _personaService.AddPersonas(personas);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdatePersona")]
        public async Task<ActionResult> UpdatePersonas([FromBody] Personas persona)
        {
            string response = await _personaService.UpdatePersonas(persona);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeletePersona/{id}")]
        public async Task<ActionResult> DeletePersonas([FromRoute] Guid id)
        {
            string response = await _personaService.DeletePersonas(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
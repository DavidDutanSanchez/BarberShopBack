using barbershop.Interface;
using barbershop.model;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : SistecControllerBase
    {
        private readonly IControladorUsuario _personaService;

        public UsuarioController(IControladorUsuario personaService)
        {
            _personaService = personaService;
        }
        //CRUD Usuarios
        [HttpGet("FindAllUsuarios")]
        public async Task<ActionResult<PaginationDto<Usuarios>>> GetAllUsuarios([FromQuery] QueryParams qParams)
        {
            PaginationDto<Usuarios> pagedResult = await _personaService.AllUsuarios(qParams);
            return Ok(pagedResult);
        }
        [HttpPut("AddUsuarios")]
        public async Task<IActionResult> AddUsuarios([FromBody] Usuarios usuarios)
        {
            string response = await _personaService.AddUsuarios(usuarios);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateUsuarios")]
        public async Task<ActionResult> UpdateUsuarios([FromBody] Usuarios usuarios)
        {
            string response = await _personaService.UpdateUsuarios(usuarios);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteUsuarios/{id}")]
        public async Task<ActionResult> DeleteUsuarios([FromQuery] Guid id)
        {
            string response = await _personaService.DeleteUsuarios(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
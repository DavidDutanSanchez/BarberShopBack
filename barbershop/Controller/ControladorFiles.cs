using barbershop.Interface;
using barbershop.model;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : SistecControllerBase
    {
        private readonly IControladorFile _personaService;

        public FileController(IControladorFile personaService)
        {
            _personaService = personaService;
        }

        //CRUD Files
        [HttpGet("FindAllFiles")]
        public async Task<ActionResult<PaginationDto<Files>>> GetAllFiles([FromQuery] QueryParams qParams)
        {
            PaginationDto<Files> pagedResult = await _personaService.AllFiles(qParams);
            return Ok(pagedResult);
        }

        [HttpPut("AddFiles")]
        public async Task<IActionResult> AddFiles([FromBody] Files files)
        {
            string response = await _personaService.AddFiles(files);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateFiles")]
        public async Task<ActionResult> UpdateFiles([FromBody] Files files)
        {
            string response = await _personaService.UpdateFiles(files);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteFiles/{id}")]
        public async Task<ActionResult> DeleteFiles([FromRoute] Guid id)
        {
            string response = await _personaService.DeleteFiles(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
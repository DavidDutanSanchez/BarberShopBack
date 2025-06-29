using barbershop.Interface;
using barbershop.model;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : SistecControllerBase
    {
        private readonly IControladorTicket _personaService;

        public TicketController(IControladorTicket personaService)
        {
            _personaService = personaService;
        }

        //CRUD TicketsCabecera
        [HttpGet("FindAllTicketsCabecera")]
        public async Task<ActionResult<PaginationDto<TicketsCabecera>>> GetAllTicketCabecera([FromQuery] QueryParams qParams)
        {
            PaginationDto<TicketsCabecera> pagedResult = await _personaService.AllTicketsCabecera(qParams);
            return Ok(pagedResult);
        }
        [HttpPut("AddTicketsCabecera")]
        public async Task<IActionResult> AddTicketsCabecera([FromBody] TicketsCabecera ticketsCabecera)
        {
            string response = await _personaService.AddTicketsCabecera(ticketsCabecera);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateTicketsCabecera")]
        public async Task<ActionResult> UpdateTicketsCabecera([FromBody] TicketsCabecera ticketsCabecera)
        {
            string response = await _personaService.UpdateTicketsCabecera(ticketsCabecera);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteTicketCabecera/{id}")]
        public async Task<ActionResult> DeleteTicketCabecera([FromRoute] Guid id)
        {
            string response = await _personaService.DeleteTicketsCabecera(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        //CRUD TicketsDetalle
        [HttpGet("FindAllTicketsDetalle")]
        public async Task<ActionResult<PaginationDto<TicketsDetalle>>> GetAllTicketDetalle([FromQuery] QueryParams qParams)
        {
            PaginationDto<TicketsDetalle> pagedResult = await _personaService.AllTicketsDetalle(qParams);
            return Ok(pagedResult);
        }
        [HttpPut("AddTicketsDetalle")]
        public async Task<IActionResult> AddTicketsDetalle([FromBody] TicketsDetalle ticketsDetalle)
        {
            string response = await _personaService.AddTicketsDetalle(ticketsDetalle);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateTicketsDetalle")]
        public async Task<ActionResult> UpdateTicketsDetalle([FromBody] TicketsDetalle ticketsDetalle)
        {
            string response = await _personaService.UpdateTicketsDetalle(ticketsDetalle);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteTicketDetalle/{id}")]
        public async Task<ActionResult> DeleteTicketDetalle([FromRoute] Guid id)
        {
            string response = await _personaService.DeleteTicketsDetalle(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
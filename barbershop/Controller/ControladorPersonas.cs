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
        public async Task<ActionResult> DeletePersonas([FromQuery] Guid id)
        {
            string response = await _personaService.DeletePersonas(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
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
        public async Task<ActionResult> DeleteFiles([FromQuery] Guid id)
        {
            string response = await _personaService.DeleteFiles(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        //CRUD Productos
        [HttpGet("FindAllProductos")]
        public async Task<ActionResult<PaginationDto<Productos>>> GetAllProductos([FromQuery] QueryParams qParams)
        {
            PaginationDto<Productos> pagedResult = await _personaService.AllProductos(qParams);
            return Ok(pagedResult);
        }
        [HttpPut("AddProductos")]
        public async Task<IActionResult> AddProductos([FromBody] Productos productos)
        {
            string response = await _personaService.AddProductos(productos);
            return response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response);
        }
        [HttpPost("UpdateProductos")]
        public async Task<ActionResult> UpdateProdcutos([FromBody] Productos productos)
        {
            string response = await _personaService.UpdateProductos(productos);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }

        [HttpDelete("DeleteProductos/{id}")]
        public async Task<ActionResult> DeleteProductos([FromQuery] Guid id)
        {
            string response = await _personaService.DeleteProductos(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
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
        public async Task<ActionResult> DeleteServicios([FromQuery] Guid id)
        {
            string response = await _personaService.DeleteServicios(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
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
        public async Task<ActionResult> DeleteTicketCabecera([FromQuery] Guid id)
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
        public async Task<ActionResult> DeleteTicketDetalle([FromQuery] Guid id)
        {
            string response = await _personaService.DeleteTicketsDetalle(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
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
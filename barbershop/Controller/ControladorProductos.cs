using barbershop.Dtos;
using barbershop.Interface;
using barbershop.model;
using barbershop.model.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : SistecControllerBase
    {
        private readonly IControladorProducto _personaService;

        public ProductoController(IControladorProducto personaService)
        {
            _personaService = personaService;
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
        public async Task<ActionResult> DeleteProductos([FromRoute] Guid id)
        {
            string response = await _personaService.DeleteProductos(id);
            return (ActionResult)(response == "Realizado" ? Ok(response) : (IActionResult)InternalServerError(response));
        }
    }
}
using barbershop.Interface;
using Microsoft.AspNetCore.Mvc;

namespace barbershop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController<TEntity, TKey> : ControllerBase
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repo;

        protected GenericController(IGenericRepository<TEntity> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById([FromRoute] TKey id)
        {
            var entity = await _repo.GetByIdAsync(id!);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create([FromBody] TEntity dto)
        {
            await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = (dto as dynamic)?.Id }, dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update([FromRoute] TKey id, [FromBody] TEntity dto)
        {
            // you might check that dto.Id == id here
            await _repo.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete([FromRoute] TKey id)
        {
            await _repo.DeleteAsync(id!);
            return NoContent();
        }
    }

}
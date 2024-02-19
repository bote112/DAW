using bca.Models;
using bca.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IRepositoryBase<Filme> _repository;

        public FilmeController(IRepositoryBase<Filme> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> Get()
        {
            var filme = await _repository.FindAllAsync();
            return Ok(filme);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> Get(int id)
        {
            var film = await _repository.FindByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Post([FromBody] Filme film)
        {
            if (film == null)
            {
                return BadRequest("Film data is null");
            }
            await _repository.CreateAsync(film);
            return CreatedAtAction(nameof(Get), new { id = film.Id }, film);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Filme film)
        {
            if (film == null)
            {
                return BadRequest("Film data is null");
            }
            var filmToUpdate = await _repository.FindByIdAsync(id);
            if (filmToUpdate == null)
            {
                return NotFound($"Film with Id = {id} not found");
            }
            _repository.Update(film);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filmToDelete = await _repository.FindByIdAsync(id);
            if (filmToDelete == null)
            {
                return NotFound($"Film with Id = {id} not found");
            }
            _repository.Delete(filmToDelete);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

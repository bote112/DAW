using bca.Models;
using bca.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmActorController : ControllerBase
    {
        private readonly IRepositoryBase<FilmActor> _repository;

        public FilmActorController(IRepositoryBase<FilmActor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmActor>>> Get()
        {
            var filmActors = await _repository.FindAllAsync();
            return Ok(filmActors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmActor>> Get(int id)
        {
            var filmActor = await _repository.FindByIdAsync(id);
            if (filmActor == null)
            {
                return NotFound();
            }
            return Ok(filmActor);
        }

        [HttpPost]
        public async Task<ActionResult<FilmActor>> Post([FromBody] FilmActor filmActor)
        {
            if (filmActor == null)
            {
                return BadRequest("FilmActor data is null");
            }
            await _repository.CreateAsync(filmActor);
            return CreatedAtAction(nameof(Get), new { id = filmActor.Id }, filmActor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FilmActor filmActor)
        {
            if (filmActor == null)
            {
                return BadRequest("FilmActor data is null");
            }
            var filmActorToUpdate = await _repository.FindByIdAsync(id);
            if (filmActorToUpdate == null)
            {
                return NotFound($"FilmActor with Id = {id} not found");
            }
            _repository.Update(filmActor);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filmActorToDelete = await _repository.FindByIdAsync(id);
            if (filmActorToDelete == null)
            {
                return NotFound($"FilmActor with Id = {id} not found");
            }
            _repository.Delete(filmActorToDelete);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

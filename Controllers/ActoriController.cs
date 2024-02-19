using bca.Models;
using bca.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoriController : ControllerBase
    {
        private readonly IRepositoryBase<Actori> _repository;

        public ActoriController(IRepositoryBase<Actori> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actori>>> Get()
        {
            var actori = await _repository.FindAllAsync();
            return Ok(actori);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actori>> Get(int id)
        {
            var actor = await _repository.FindByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<Actori>> Post([FromBody] Actori actor)
        {
            if (actor == null)
            {
                return BadRequest("Actor data is null");
            }
            await _repository.CreateAsync(actor);
            return CreatedAtAction(nameof(Get), new { id = actor.Id }, actor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Actori actor)
        {
            if (actor == null)
            {
                return BadRequest("Actor data is null");
            }
            var actorToUpdate = await _repository.FindByIdAsync(id);
            if (actorToUpdate == null)
            {
                return NotFound($"Actor with Id = {id} not found");
            }
            _repository.Update(actor);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actorToDelete = await _repository.FindByIdAsync(id);
            if (actorToDelete == null)
            {
                return NotFound($"Actor with Id = {id} not found");
            }
            _repository.Delete(actorToDelete);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

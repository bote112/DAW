using bca.Data;
using bca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Repositories
{
    public class FilmActorRepository : IRepositoryBase<FilmActor>
    {
        private readonly ApplicationDbContext _context;

        public FilmActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FilmActor>> FindAllAsync()
        {
            return await _context.FilmActors.Include(fa => fa.ActorId).Include(fa => fa.FilmId).ToListAsync();
        }

        public async Task<FilmActor> FindByIdAsync(int id)
        {
            return await _context.FilmActors.FindAsync(id);
        }

        public async Task CreateAsync(FilmActor filmActor)
        {
            _context.FilmActors.Add(filmActor);
            await SaveAsync();
        }

        public void Update(FilmActor filmActor)
        {
            _context.FilmActors.Update(filmActor);
        }

        public void Delete(FilmActor filmActor)
        {
            _context.FilmActors.Remove(filmActor);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

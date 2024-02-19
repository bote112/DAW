using bca.Data;
using bca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Repositories
{
    public class ActorRepository : IRepositoryBase<Actori>
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actori>> FindAllAsync()
        {
            return await _context.Actoris.ToListAsync();
        }

        public async Task<Actori> FindByIdAsync(int id)
        {
            return await _context.Actoris.FindAsync(id);
        }

        public async Task CreateAsync(Actori actor)
        {
            _context.Actoris.Add(actor);
            await SaveAsync();
        }

        public void Update(Actori actor)
        {
            _context.Actoris.Update(actor);
        }

        public void Delete(Actori actor)
        {
            _context.Actoris.Remove(actor);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using bca.Data;
using bca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bca.Repositories
{
    public class FilmeRepository : IRepositoryBase<Filme>
    {
        private readonly ApplicationDbContext _context;

        public FilmeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filme>> FindAllAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> FindByIdAsync(int id)
        {
            return await _context.Filmes.FindAsync(id);
        }

        public async Task CreateAsync(Filme film)
        {
            _context.Filmes.Add(film);
            await SaveAsync();
        }

        public void Update(Filme film)
        {
            _context.Filmes.Update(film);
        }

        public void Delete(Filme film)
        {
            _context.Filmes.Remove(film);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

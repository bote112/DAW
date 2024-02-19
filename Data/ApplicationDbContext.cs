using bca.Models;
using Microsoft.EntityFrameworkCore;

namespace bca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        
        public DbSet<Actori> Actoris { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<FilmActor>()
                .HasKey(fa => fa.Id); 

            modelBuilder.Entity<FilmActor>()
                .HasOne<Actori>(fa => fa.Actor) 
                .WithMany() 
                .HasForeignKey(fa => fa.ActorId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<FilmActor>()
                .HasOne<Filme>(fa => fa.Film)
                .WithMany() 
                .HasForeignKey(fa => fa.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

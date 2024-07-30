using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace ProAgil.Repository
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base (options) {}
        public DbSet<Produto> Produtos {get;set;}
        public DbSet<Categoria> Categorias {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                 .ToTable("Produto");

            modelBuilder.Entity<Categoria>()
                .ToTable("Catalogo");
                
        }
    }
}
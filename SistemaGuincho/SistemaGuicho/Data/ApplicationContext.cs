using Microsoft.EntityFrameworkCore;
using SistemaGuincho.Domain.Produtos;

namespace SistemaGuincho.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Guincho> Guincho{ get; set; }
        public DbSet<Pneu>  Pneu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConectarSQL(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        protected void ConectarSQL(DbContextOptionsBuilder optionsBuilder)
        {
            var ConectionStringSQL = "Data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Guincho;Integrated Security=true";
            optionsBuilder.UseSqlServer(ConectionStringSQL);
        }
    }
}

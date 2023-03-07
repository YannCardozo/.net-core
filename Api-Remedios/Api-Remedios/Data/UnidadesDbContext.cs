using Api_Remedios.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Remedios.Data
{
    public class UnidadesDbContext : DbContext
    {
        public UnidadesDbContext(DbContextOptions<UnidadesDbContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Master;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Unidades> Unidades {get;set;}
    }
}

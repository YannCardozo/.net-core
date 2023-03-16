global using Microsoft.EntityFrameworkCore;
using Api_Remedios.Models;


namespace Api_Remedios.Data
{
    public class RemediosDbContext : DbContext
    {
        public RemediosDbContext(DbContextOptions<RemediosDbContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        public DbSet<Remedios> Remedios => Set<Remedios>();
        public DbSet<Unidades> Unidades => Set<Unidades>();
        public DbSet<Regiao> Regiao => Set<Regiao>();

    }
}

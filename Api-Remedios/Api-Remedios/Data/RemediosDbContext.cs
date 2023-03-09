using Api_Remedios.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Remedios.Data
{
    public class RemediosDbContext : DbContext
    {
        public RemediosDbContext(DbContextOptions<RemediosDbContext> options)
            : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Master;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        public DbSet<Remedios> Remedios { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<Regiao> Regiao { get; set; }

    }
}

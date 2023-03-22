global using Microsoft.EntityFrameworkCore;



namespace Api_Remedios.Data
{
    public class RemediosDbContext : DbContext
    {
        public RemediosDbContext(DbContextOptions<RemediosDbContext> options) : base(options) 
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;TrustServerCertificate=true;");
            //localhost SEMPRE ODONTO optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;TrustServerCertificate=true;");
            //localhost CASA optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        //"Server=*nomeservidor*;Database=*nomeDB*;Trust Server Certificate=true;User ID=*usuario*;password=*senha*";
        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University; Integrated Security=True;";
        public DbSet<Remedios> Remedios => Set<Remedios>();
        public DbSet<Unidades> Unidades => Set<Unidades>();
        public DbSet<Regiao> Regiao => Set<Regiao>();
		public DbSet<Cep> Cep => Set<Cep>();
	}

}

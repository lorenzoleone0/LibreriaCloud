using Libreria.Configurazioni;
using Libreria.Entita;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {
        }

        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Libro> Libri { get; set; }
     
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer("data source= localhost; Initial catalog=Libreria; User Id=progettolibreria; Password=libreria; TrustServerCertificate=True");
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UtenteConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
           
      
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


            base.OnModelCreating(modelBuilder);

        }
    }
}
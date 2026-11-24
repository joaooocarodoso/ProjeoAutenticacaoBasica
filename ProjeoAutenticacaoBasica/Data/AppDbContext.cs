using Microsoft.EntityFrameworkCore;
using ProjeoAutenticacaoBasica.Models;

namespace ProjeoAutenticacaoBasica.Data
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions options) : base(options)
            {
            }


            public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Passagem> Passagens { get; set; }

    }
}

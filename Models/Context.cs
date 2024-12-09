using Microsoft.EntityFrameworkCore;

namespace AgendaLeaf.Models
{
    public class Context : DbContext
    {
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

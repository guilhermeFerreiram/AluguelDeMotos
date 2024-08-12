using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace AluguelDeMotos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<MotoModel> Motos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoModel>()
                .HasIndex(m => m.Placa)
                .IsUnique();
        }

    }
}

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
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<EntregadorModel> Entregadores { get; set; }
        public DbSet<MotoModel> Motos { get; set; }
        public DbSet<LocacaoModel> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoModel>()
                .HasIndex(m => m.Placa)
                .IsUnique();

            modelBuilder.Entity<EntregadorModel>()
                .HasIndex(e => e.Cnpj)
                .IsUnique();

            modelBuilder.Entity<EntregadorModel>()
                .HasIndex(c => c.NumeroCnh)
                .IsUnique();

            modelBuilder.Entity<LocacaoModel>()
                .HasOne(l => l.Usuario)
                .WithOne(e => e.Locacao)
                .HasForeignKey<LocacaoModel>(l => l.UsuarioId);

            modelBuilder.Entity<LocacaoModel>()
                .HasOne(l => l.Moto)
                .WithOne(m => m.Locacao)
                .HasForeignKey<LocacaoModel>(l => l.MotoId);
        }

    }
}

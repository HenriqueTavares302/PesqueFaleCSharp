using Microsoft.EntityFrameworkCore;
using PesqueFaleCSharp.Models;

namespace PesqueFaleCSharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Local> Locais { get; set; } = null!;
        public DbSet<Publicacao> Publicacoes { get; set; } = null!;
        public DbSet<Comentario> Comentarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índices e configurações simples
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Relacionamentos
            modelBuilder.Entity<Publicacao>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Publicacoes)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Publicacao>()
                .HasOne(p => p.Local)
                .WithMany(l => l.Publicacoes)
                .HasForeignKey(p => p.LocalId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Publicacao)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.PublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
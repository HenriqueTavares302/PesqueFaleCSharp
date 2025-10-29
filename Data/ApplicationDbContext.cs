using Microsoft.EntityFrameworkCore;
using PesqueFaleCSharp.Models;

namespace PesqueFaleCSharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pescador> Pescadores { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Local> Locais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento: Local -> Publicações (1:N)
            modelBuilder.Entity<Publicacao>()
                .HasOne(p => p.Local)
                .WithMany(l => l.Publicacoes)
                .HasForeignKey(p => p.LocalId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relacionamento: Pescador -> Publicações (1:N)
            modelBuilder.Entity<Publicacao>()
                .HasOne<Pescador>()
                .WithMany()
                .HasForeignKey(p => p.UsuarioId) // agora representa o PescadorId
              .OnDelete(DeleteBehavior.NoAction); // mantém cascade aqui (opcional)

            // Relacionamento: Publicação -> Comentários (1:N)
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Publicacao)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.PublicacaoId)
                 .OnDelete(DeleteBehavior.NoAction);

            // Relacionamento: Pescador -> Comentários (1:N)
            modelBuilder.Entity<Comentario>()
                .HasOne<Pescador>()
                .WithMany()
                .HasForeignKey(c => c.UsuarioId) // agora representa o PescadorId
                // Alterado para evitar múltiplos caminhos em cascade
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace PesqueFaleCSharp.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public int PublicacaoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Conteudo { get; set; } = null!;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Navegação
        public Publicacao Publicacao { get; set; } = null!;
        public Pescador Usuario { get; set; } = null!;
    }
}
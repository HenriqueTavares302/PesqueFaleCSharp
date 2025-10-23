using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PesqueFaleCSharp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = null!;

        // Armazene hash/salt em vez de senha em texto puro
        [Required]
        [MaxLength(200)]
        public string SenhaHash { get; set; } = null!;

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(250)]
        public string? FotoUrl { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        // Navegação
        public ICollection<Publicacao> Publicacoes { get; set; } = new List<Publicacao>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
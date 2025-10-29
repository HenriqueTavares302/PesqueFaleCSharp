using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PesqueFaleCSharp.Models
{
    public class Publicacao
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        // Opcional: publica��o pode referenciar um Local
        public int? LocalId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Conteudo { get; set; } = null!;

        [MaxLength(500)]
        public string? ImagemUrl { get; set; }

        public DateTime DataPublicacao { get; set; } = DateTime.UtcNow;

        public int Curtidas { get; set; } = 0;

        // Navega��o
        public Pescador Usuario { get; set; } = null!;
        public Local? Local { get; set; }
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
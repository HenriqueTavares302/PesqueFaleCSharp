using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PesqueFaleCSharp.Models
{
    public class Local
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; } = null!;

        [MaxLength(100)]
        public string? Cidade { get; set; }

        [MaxLength(50)]
        public string? Estado { get; set; }

        // Ex: "rio", "lago", "pesqueiro"
        [MaxLength(50)]
        public string? Tipo { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [MaxLength(1000)]
        public string? Descricao { get; set; }

        // Avaliação média e número de avaliações (calcule/update via lógica de app)
        public double AvaliacaoMedia { get; set; } = 0.0;
        public int NumeroAvaliacoes { get; set; } = 0;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        // Navegação
        public ICollection<Publicacao> Publicacoes { get; set; } = new List<Publicacao>();
    }
}
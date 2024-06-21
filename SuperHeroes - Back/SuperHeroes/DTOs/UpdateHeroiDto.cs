using SuperHeroes.Models;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.DTOs
{
    public class UpdateHeroiDto
    {
        [MaxLength(120, ErrorMessage = "Nome deve ter no máximo 120 caracteres!")]
        public string Nome { get; set; }

        [MaxLength(120, ErrorMessage = "NomeHeroi deve ter no máximo 120 caracteres!")]
        public string NomeHeroi { get; set; }

        public DateTime DataNascimento { get; set; }

        public double Altura { get; set; }

        public double Peso { get; set; }

        public virtual ICollection<CreateSuperpoderDto> Superpoderes { get; set; }
    }
}

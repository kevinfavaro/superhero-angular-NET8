using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.DTOs
{
    public class CreateHeroiDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(120, ErrorMessage = "Nome deve ter no máximo 120 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome é obrigatório")]
        [MaxLength(120, ErrorMessage = "NomeHeroi deve ter no máximo 120 caracteres!")]
        public string NomeHeroi { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Altura é obrigatório")]
        [Range(1, 99999)]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório")]
        [Range(1, 99999)]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Informe 1 ou mais superpoderes")]
        public virtual ICollection<CreateSuperpoderDto> Superpoderes { get; set; }
    }
}

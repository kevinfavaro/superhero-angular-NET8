using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.DTOs
{
    public class CreateSuperpoderDto
    {
        [Required(ErrorMessage = "Informe 1 ou mais superpoderes")]
        public int Id { get; set; }
    }
}

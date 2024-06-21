namespace SuperHeroes.Models
{
    public class Herois
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public virtual ICollection<HeroisSuperpoderes> Superpoderes { get; set; }
    }
}

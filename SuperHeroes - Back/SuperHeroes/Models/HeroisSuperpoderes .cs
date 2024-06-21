namespace SuperHeroes.Models
{
    public class HeroisSuperpoderes
    {

        public int? HeroiId { get; set; }
        public virtual Herois Heroi { get; set; }
        public int? SuperpoderId { get; set; }
        public virtual Superpoderes Superpoder { get; set; }

    }
}

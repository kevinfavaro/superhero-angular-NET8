using SuperHeroes.Models;

namespace SuperHeroes.Interfaces
{
    public interface ISuperpoder
    {
        Task<IList<Superpoderes>> ListarSuperpoderes();
    }
}

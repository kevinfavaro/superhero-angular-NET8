using Microsoft.EntityFrameworkCore;
using SuperHeroes.Configuracao;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Repositorios
{
    public class RepositorioSuperpoderes : ISuperpoder
    {
        private readonly DbContextOptions<ContextDb> _OptionsBuilder;

        public RepositorioSuperpoderes()
        {
            _OptionsBuilder = new DbContextOptions<ContextDb>();
        }

        public async Task<IList<Superpoderes>> ListarSuperpoderes()
        {
            using var banco = new ContextDb(_OptionsBuilder);
            return await
                banco.Superpoderes
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
